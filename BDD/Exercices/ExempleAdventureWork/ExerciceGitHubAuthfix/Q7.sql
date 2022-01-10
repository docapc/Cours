/*Retrouvez le nom du produit et le nom de la compagnie pour les clients ayant commandés le produit 'Racing Socks' */
--SELECT * 
--FROM SalesLT.Customer

SELECT c.CustomerID, c.FirstName, c.CompanyName, p.Name 
FROM SalesLT.Customer as c
JOIN SalesLT.SalesOrderHeader as soh ON c.CustomerID = soh.CustomerID 
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
WHERE p.Name LIKE '%Racing Socks%'

