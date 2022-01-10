/*Retrouver combien de produits avec la cat�gorie 'Cranksets' ont �t� vendues � une adresse � Londres. */

--SELECT *
--FROM SalesLT.Product as p

--SELECT *
--FROM SalesLT.ProductCategory as pc
--ORDER BY pc.Name

--SELECT p.Name, pc.Name, c.FirstName, c.LastName, a.AddressID, a.City, sod.SalesOrderID, sod.ProductID, sod.OrderQty -- d�tail
SELECT SUM(sod.OrderQty) -- quantit� total de produit vendu
--SELECT p.ProductId--COUNT(DISTINCT p.ProductID) -- nombre de produit diff�rents (r�f�rence) qui ont �t� vendus � Londres
FROM SalesLT.Product as p
JOIN SalesLT.ProductCategory pc ON p.ProductCategoryID = pc.ProductCategoryID
JOIN SalesLT.SalesOrderDetail as sod ON p.ProductID = sod.ProductID
JOIN SalesLT.SalesOrderHeader as soh ON sod.SalesOrderID = soh.SalesOrderID
JOIN SalesLT.Customer as c ON soh.CustomerID = c.CustomerID
JOIN SalesLT.CustomerAddress as ca ON c.CustomerID = ca.CustomerID
JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
WHERE pc.Name = 'Cranksets' and a.City = 'London'