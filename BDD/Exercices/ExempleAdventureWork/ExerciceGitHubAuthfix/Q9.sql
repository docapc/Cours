/*En utilisant le SubTotal value dans SaleOrderHeader, listez les commandes de la plus petite à la plus grande. 
Pour chaque commande, listez le nom de la compagnie, le sous total et le poids total de la commande */

--SELECT soh.SalesOrderID, c.CompanyName, soh.SubTotal, sod.ProductId, sod.OrderQty, p.Weight
SELECT soh.SalesOrderID, c.CompanyName, soh.SubTotal, SUM(p.Weight*sod.OrderQty) as TotalWeight
FROM SalesLT.SalesOrderHeader as soh
JOIN SalesLT.Customer as c ON soh.CustomerID = c.CustomerID
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
GROUP BY soh.SalesOrderID, c.CompanyName, soh.SubTotal
ORDER BY soh.SubTotal
--ORDER BY soh.SalesOrderID