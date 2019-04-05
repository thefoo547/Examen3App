USE Northwind
GO

/*1. Seleccionar a todos los clientes que hayan realizado más de 5 órdenes por año.
     presentar el detalle de las cantidad por año. Ordenar por año
     Presentar:
     Nombre Compañía - Año - Cantidad
        Empresa X      1998     6
        Empresa X      1997     7
        Empresa X      1996     9
        Empresa Y      1998     8
        Empresa Y      1997     9
        Empresa Y      1996     10     */

ALTER PROCEDURE sp_Company_Orders_byYear
AS
	SELECT c.CompanyName as [Nombre Compañía],
	YEAR(o.OrderDate) as Año,
	COUNT(o.OrderID) as [Cantidad de Órdenes] FROM Customers c 
	INNER JOIN Orders o ON o.CustomerID=c.CustomerID
	GROUP BY c.CompanyName, YEAR(o.OrderDate)
	ORDER BY Año;

/*    Realizar un procedimiento almacenado que reciba como parámetro el año.
      Calcular la cantidad de órdenes y recaudaciones hechas para todos los empleados para
      un determinado año. Aplicar una comisión del 25 % en caso que la cantidad de órdenes
      supere el promedio de ese año. Promedio=(Cantidad de órdenes / Número de Empleados)
      de lo contrario solo aplicar el 10%
        Ejemplo: Suponiendo que la media de órdenes para ese año fue de 11, 
                 se aplicaría el 25% de comisión de la recaudación.

       IdEmpleado   -   Primer Nombre  -    Cantidad de órdenes  -  Recaudación - Comisión
            4             Alfred                   18                 10254        2563.5
         


   */

CREATE PROCEDURE sp_comisiones
@yr int
AS
	CREATE TABLE #tabla_comision(
	Employee_ID int primary key,
	[Nombre Empleado] varchar(50),
	[Cantidad de Órdenes] int,
	[Recaudación Total] money,
	Comisión money
	);

	insert into #tabla_comision SELECT e.EmployeeID as Employee_ID,
	(e.FirstName+' '+e.LastName) as [Nombre Empleado],
	COUNT(distinct o.OrderID) AS [Cantidad de Órdenes], 
	SUM((od.Quantity*od.UnitPrice)-(od.Quantity*od.UnitPrice*od.Discount)) as [Recaudación Total], 
	0 as Comisión FROM Employees e 
	INNER JOIN Orders o ON o.EmployeeID=e.EmployeeID
	INNER JOIN [Order Details] od ON od.OrderID=o.OrderID
	WHERE YEAR(o.OrderDate)=@yr
	GROUP BY e.EmployeeID, (e.FirstName+' '+e.LastName);

	DECLARE @avg_oqty int;
	SELECT @avg_oqty=AVG([Cantidad de Órdenes]) FROM #tabla_comision;

	UPDATE #tabla_comision SET Comisión=round([Recaudación Total]*0.25, 2) WHERE [Cantidad de Órdenes]>@avg_oqty;
	UPDATE #tabla_comision SET Comisión=round([Recaudación Total]*0.1,2) WHERE [Cantidad de Órdenes]<=@avg_oqty;

	select * from #tabla_comision;
	drop table #tabla_comision;

--creacion de login para la conexión con la aplicación
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

