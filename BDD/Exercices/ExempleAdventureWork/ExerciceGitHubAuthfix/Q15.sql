/*Retrouvez les trois villes les plus importantes. Affichez la répartition de la 
catégorie de produits de premier niveau par rapport à chaque ville. */
-- Ville importante = ville avec le plus de Chiffres d'affaire fait (on pourrait prendre avec le plus de client)
-- Produit de premiers niveaux : produit ayant un ParentProductCategory le plus bas mais non nulle ( = 1)
--		ProductCategoryId/Name : 5/Mountain Bikes, 6/Road Bikes, 7/Touring Bikes
-- Répartition de catégorie de premier niveau : nb de produit dans chaque catégorie de niveau1
-- Ou bien plus compliqué Répartition de catégorie de premier niveau : (nb de produit de niveau1/nb tot de produit)*100

--Il nous faut des variables pour ce genre de choses!!! ou une autre table

--SELECT *
--FROM SalesLT.Address

--SELECT *
--FROM SalesLT.ProductCategory

--Retrouve les trois villes les plus importantes
--SELECT p.ProductID, p.Name, a.City, SUM(sod.UnitPrice*sod.OrderQty) as MoneyByProduct
SELECT TOP(3) a.City as TopCities, SUM(sod.UnitPrice*sod.OrderQty) as MoneyByCity
FROM SalesLT.CustomerAddress as ca
JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
JOIN SalesLT.SalesOrderHeader as soh ON ca.CustomerID = soh.CustomerID
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
GROUP BY  a.City
ORDER BY MoneyByCity DESC 

--SELECT a.City, pc.ParentProductCategoryID, pc.Name, pc.ProductCategoryID--,SUM(sod.UnitPrice*sod.OrderQty) as MoneyByCity
--SELECT a.City, pc.ProductCategoryID, pc.Name, pc.ProductCategoryID--,SUM(sod.UnitPrice*sod.OrderQty) as MoneyByCity
SELECT 
(SELECT COUNT(pc.Name)
FROM SalesLT.CustomerAddress as ca
JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
JOIN SalesLT.SalesOrderHeader as soh ON ca.CustomerID = soh.CustomerID
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
JOIN SalesLT.ProductCategory as pc ON p.ProductCategoryID = pc.ProductCategoryID 
WHERE pc.Name = 'Mountain Bikes'
GROUP BY a.City
HAVING a.City in ('London','Woolston','Union City')
					) as Mountain_Bikes
FROM SalesLT.Address
--(SELECT COUNT(pc.Name)
--FROM SalesLT.CustomerAddress as ca
--JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
--JOIN SalesLT.SalesOrderHeader as soh ON ca.CustomerID = soh.CustomerID
--JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
--JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
--JOIN SalesLT.ProductCategory as pc ON p.ProductCategoryID = pc.ProductCategoryID 
--WHERE pc.Name = 'Road Bikes'
--GROUP BY a.City
--HAVING a.City in ('London', 'Woolston', 'Union City')
--) as Road_Bikes

--(SELECT a.City, COUNT(pc.Name) as Mountain_Bikes
--FROM SalesLT.CustomerAddress as ca
--JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
--JOIN SalesLT.SalesOrderHeader as soh ON ca.CustomerID = soh.CustomerID
--JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
--JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
--JOIN SalesLT.ProductCategory as pc ON p.ProductCategoryID = pc.ProductCategoryID 
--WHERE pc.Name = 'Touring Bikes'
--GROUP BY a.City
--HAVING a.City in ('London', 'Woolston', 'Union City')) as Touring_Bikes


SELECT a.City, COUNT(pc.Name) as Mountain_Bikes
FROM SalesLT.CustomerAddress as ca
JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
JOIN SalesLT.SalesOrderHeader as soh ON ca.CustomerID = soh.CustomerID
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
JOIN SalesLT.ProductCategory as pc ON p.ProductCategoryID = pc.ProductCategoryID 
WHERE pc.Name = 'Mountain Bikes' and a.City in ('London', 'Woolston', 'Union City')
GROUP BY a.City
--HAVING a.City in ('London', 'Woolston', 'Union City')


SELECT COUNT(*) as Road_Bikes
FROM SalesLT.CustomerAddress as ca
JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
JOIN SalesLT.SalesOrderHeader as soh ON ca.CustomerID = soh.CustomerID
JOIN SalesLT.SalesOrderDetail as sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN SalesLT.Product as p ON sod.ProductID = p.ProductID
JOIN SalesLT.ProductCategory as pc ON p.ProductCategoryID = pc.ProductCategoryID 
WHERE pc.Name = 'Road Bikes' 
GROUP BY a.City
HAVING a.City in ('London', 'Woolston', 'Union City')