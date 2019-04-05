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

CREATE PROCEDURE sp_Company_Orders_byYear
AS
	SELECT c.CompanyName as [Nombre Compañía],
	YEAR(o.OrderDate) as Año,
	COUNT(o.OrderID) FROM Customers c 
	INNER JOIN Orders o ON o.CustomerID=c.CustomerID
	GROUP BY c.CompanyName, YEAR(o.OrderDate)
	ORDER BY Año;

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