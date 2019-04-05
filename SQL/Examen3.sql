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

CREATE PROCEDURE sp_Company_Orders_byYear
AS
	SELECT c.CompanyName as [Nombre Compa��a],
	YEAR(o.OrderDate) as A�o,
	COUNT(o.OrderID) FROM Customers c 
	INNER JOIN Orders o ON o.CustomerID=c.CustomerID
	GROUP BY c.CompanyName, YEAR(o.OrderDate)
	ORDER BY A�o;

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