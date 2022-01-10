/*Pour chaque vente, retrouvez le SalesOrderID et le sous-total, calculé à partir des 3 façons suivantes : 
depuis le SalesOrderHeader, la somme des OrderQtyUnitPrice et la somme des OrderQtyListPrice */

SELECT soh.SalesOrderID, soh.SubTotal, SUM(sod.UnitPrice*sod.OrderQty) as OrderQtyUnitPrice, SUM(sod.OrderQty*p.ListPrice) as  OrderQtyListPrice
FROM SalesLT.SalesOrderHeader as soh
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID

GROUP BY soh.SalesOrderID, soh.SubTotal
ORDER BY soh.SalesOrderID

SELECT sod.SalesOrderID, soh.SubTotal, sod.UnitPrice, sod.OrderQty, sod.LineTotal, p.ProductId, p.ListPrice, p.StandardCost
FROM SalesLT.SalesOrderHeader as soh
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
-- Ne colle pas du tout au niveau des résultats de calculs, rien n'est cohérent...