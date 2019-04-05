USE Northwind
GO

/*1. Seleccionar a todos los clientes que hayan realizado m�s de 5 �rdenes por a�o.
     presentar el detalle de las cantidad por a�o. Ordenar por a�o
     Presentar:
     Nombre Compa��a - A�o - Cantidad
        Empresa X      1998     6
        Empresa X      1997     7
        Empresa X      1996     9
        Empresa Y      1998     8
        Empresa Y      1997     9
        Empresa Y      1996     10     */

ALTER PROCEDURE sp_Company_Orders_byYear
AS
	SELECT c.CompanyName as [Nombre Compa��a],
	YEAR(o.OrderDate) as A�o,
	COUNT(o.OrderID) as [Cantidad de �rdenes] FROM Customers c 
	INNER JOIN Orders o ON o.CustomerID=c.CustomerID
	GROUP BY c.CompanyName, YEAR(o.OrderDate)
	ORDER BY A�o;

/*    Realizar un procedimiento almacenado que reciba como par�metro el a�o.
      Calcular la cantidad de �rdenes y recaudaciones hechas para todos los empleados para
      un determinado a�o. Aplicar una comisi�n del 25 % en caso que la cantidad de �rdenes
      supere el promedio de ese a�o. Promedio=(Cantidad de �rdenes / N�mero de Empleados)
      de lo contrario solo aplicar el 10%
        Ejemplo: Suponiendo que la media de �rdenes para ese a�o fue de 11, 
                 se aplicar�a el 25% de comisi�n de la recaudaci�n.

       IdEmpleado   -   Primer Nombre  -    Cantidad de �rdenes  -  Recaudaci�n - Comisi�n
            4             Alfred                   18                 10254        2563.5
         


   */

CREATE PROCEDURE sp_comisiones
@yr int
AS
	CREATE TABLE #tabla_comision(
	Employee_ID int primary key,
	[Nombre Empleado] varchar(50),
	[Cantidad de �rdenes] int,
	[Recaudaci�n Total] money,
	Comisi�n money
	);

	insert into #tabla_comision SELECT e.EmployeeID as Employee_ID,
	(e.FirstName+' '+e.LastName) as [Nombre Empleado],
	COUNT(distinct o.OrderID) AS [Cantidad de �rdenes], 
	SUM((od.Quantity*od.UnitPrice)-(od.Quantity*od.UnitPrice*od.Discount)) as [Recaudaci�n Total], 
	0 as Comisi�n FROM Employees e 
	INNER JOIN Orders o ON o.EmployeeID=e.EmployeeID
	INNER JOIN [Order Details] od ON od.OrderID=o.OrderID
	WHERE YEAR(o.OrderDate)=@yr
	GROUP BY e.EmployeeID, (e.FirstName+' '+e.LastName);

	DECLARE @avg_oqty int;
	SELECT @avg_oqty=AVG([Cantidad de �rdenes]) FROM #tabla_comision;

	UPDATE #tabla_comision SET Comisi�n=round([Recaudaci�n Total]*0.25, 2) WHERE [Cantidad de �rdenes]>@avg_oqty;
	UPDATE #tabla_comision SET Comisi�n=round([Recaudaci�n Total]*0.1,2) WHERE [Cantidad de �rdenes]<=@avg_oqty;

	select * from #tabla_comision;
	drop table #tabla_comision;

--creacion de login para la conexi�n con la aplicaci�n
create login NwindAdmin with password='NwindAdmin.1234';
create user NwindAdmin for LOGIN NwindAdmin;
EXEC sp_addrolemember 'db_owner', 'NwindAdmin';

--inicio de sesion para la aplicacion
CREATE TABLE sysuser(
	usr_id INTEGER PRIMARY KEY IDENTITY(0,1),
	usrname VARCHAR(25),
	pswd VARCHAR(100),
	rol VARCHAR(30)
);

CREATE PROCEDURE log_in
@usrname Varchar(25), @pswd Varchar(100)
As
	if exists (select * from sysuser where usrname=@usrname and decryptbypassphrase(@pswd,pswd) = @pswd)
	Begin
		Select 'GRANTED'
	end
	Else
	Begin
		Select 'DENIED'
	End

CREATE PROCEDURE sp_in_sysuser
@usrname VARCHAR(25), @pswd VARCHAR(100), @rol VARCHAR(30)
AS
	INSERT INTO sysuser VALUES(@usrname, ENCRYPTBYPASSPHRASE(@pswd, @pswd), @rol);


EXEC sp_in_sysuser 'Admin', 'Admin', 'SysAdmin';
EXEC sp_in_sysuser 'User1', 'Abc.123', 'FullUser';

exec log_in 'Admin', 'Admin';

