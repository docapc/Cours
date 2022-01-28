/*1- Lister les SalesOrderNumber pour les clients "Good Toys" et "Bike World"*/
SELECT soh.SalesOrderNumber, c.CompanyName 
FROM SalesLT.Customer as c
LEFT JOIN SalesLT.SalesOrderHeader as soh ON c.CustomerID = soh.CustomerID
WHERE c.CompanyName IN ('Good Toys', 'Bike World')
ORDER BY c.CompanyName

/*2 - Lister le nom des produits et les quantités commandées par la société "Futuristic Bikes"*/
SELECT p.Name, sod.OrderQty
FROM SalesLT.Product as p
INNER JOIN SalesLT.SalesOrderDetail as sod ON p.ProductID = sod.ProductID
INNER JOIN SalesLT.SalesOrderHeader as soh ON sod.SalesOrderID = soh.SalesOrderID
INNER JOIN SalesLT.Customer as c ON soh.CustomerID = c.CustomerID
WHERE c.CompanyName = 'Futuristic Bikes'

/*3 - Lister les noms et addresses des entreprises qui contiennent le mot 'Bike' (en lettres majuscules ou non) ou
le mot 'Cycle' (en lettres majuscules ou non). Lister d'abord les entreprises qui contiennent le mot 'Bike'.*/
SELECT c.CompanyName
FROM SalesLT.Customer as c 
WHERE c.CompanyName LIKE '%Bike%'
GROUP BY c.CompanyName
ORDER BY c.CompanyName

SELECT c.CompanyName, a.AddressLine1, a.AddressLine2, a.City
FROM SalesLT.Customer as c 
INNER JOIN SalesLT.CustomerAddress as ca ON c.CustomerID = ca.CustomerID
INNER JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
WHERE c.CompanyName LIKE '%Bike%' OR c.CompanyName LIKE '%bike'
OR c.CompanyName LIKE '%Cycle%' OR c.CompanyName LIKE '%cycle'
ORDER BY c.CompanyName

/*4 -Lister le nombre de commandes par région (en commencant par celui qui a fait le plus de commande).*/
SELECT a.CountryRegion, COUNT(soh.SalesOrderID) as OrderByCountryRegion
FROM SalesLT.SalesOrderHeader as soh
INNER JOIN SalesLT.Customer as c ON c.CustomerID = soh.CustomerID
INNER JOIN SalesLT.CustomerAddress as ca ON c.CustomerID = ca.CustomerID
INNER JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
GROUP BY a.CountryRegion
ORDER BY COUNT(soh.SalesOrderID) DESC

/* 5- Lister le meilleur client par région.*/
--SELECT TT.CountryRegion, c.CustomerID, TT.Total
--FROM (SELECT tt.CountryRegion as CountryRegion, MAX(tt.Total) as Total
--	FROM 
--		(SELECT a.CountryRegion as CountryRegion, c.CustomerID as CID, SUM(soh.TotalDue) as Total
--		FROM SalesLT.Address as a
--		INNER JOIN SalesLT.CustomerAddress as ca ON a.AddressID = ca.AddressID
--		INNER JOIN SalesLT.Customer as c ON ca.CustomerID = c.CustomerID
--		INNER JOIN SalesLT.SalesOrderHeader as soh ON c.CustomerID = soh.CustomerID
--		GROUP BY c.CustomerID, a.CountryRegion -- pour faire la somme de commandes par client et avoir le meilleur client
--		) as tt
--	--INNER JOIN SalesLT.Customer as c ON tt.CID = c.CustomerID
--	GROUP BY tt.CountryRegion) as TT 
--INNER JOIN SalesLT.Address as a ON TT.CountryRegion = a.CountryRegion 
--INNER JOIN SalesLT.CustomerAddress as ca ON a.AddressID = ca.AddressID
--INNER JOIN SalesLT.Customer as c ON ca.CustomerID = c.CustomerID
--INNER JOIN SalesLT.SalesOrderHeader as soh ON c.CustomerID = soh.CustomerID
--WHERE 


--SELECT tt.CountryRegion, tt.CID, MAX(tt.Total) as Total
--FROM 
--	(SELECT a.CountryRegion as CountryRegion, c.CustomerID as CID, SUM(soh.TotalDue) as Total
--	FROM SalesLT.Address as a
--	INNER JOIN SalesLT.CustomerAddress as ca ON a.AddressID = ca.AddressID
--	INNER JOIN SalesLT.Customer as c ON ca.CustomerID = c.CustomerID
--	INNER JOIN SalesLT.SalesOrderHeader as soh ON c.CustomerID = soh.CustomerID
--	GROUP BY c.CustomerID, a.CountryRegion -- pour faire la somme de commandes par client et avoir le meilleur client
--	) as tt
----INNER JOIN SalesLT.Customer as c ON tt.CID = c.CustomerID
--GROUP BY tt.CountryRegion, tt.CID
--ORDER BY MAX(tt.Total) DESC

-- Ici le classement des customers 
--SELECT c.CustomerID, a.CountryRegion, SUM(soh.TotalDue)
--FROM SalesLT.Customer as c
--INNER JOIN SalesLT.CustomerAddress as ca ON c.CustomerID = ca.CustomerID
--INNER JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
--INNER JOIN SalesLT.SalesOrderHeader as soh ON c.CustomerID = soh.CustomerID
--GROUP BY c.CustomerID, a.CountryRegion
--ORDER BY SUM(soh.TotalDue) DESC

--SELECT a.CountryRegion, c.CustomerID, SUM(soh.TotalDue)
--FROM SalesLT.Address as a
--INNER JOIN SalesLT.CustomerAddress as ca ON a.AddressID = ca.AddressID
--INNER JOIN SalesLT.Customer as c ON ca.CustomerID = c.CustomerID
--INNER JOIN SalesLT.SalesOrderHeader as soh ON c.CustomerID = soh.CustomerID
--GROUP BY c.CustomerID, a.CountryRegion
--ORDER BY SUM(soh.TotalDue) DESC

/*Correction de la foutu question 5
MAX direct au lieu de Sum car il n'y a en fait qu'une seule commande par
customer...*/
-- version Bourrin avec Where sur TotalDue
SELECT c.CompanyName, a.StateProvince, soh.TotalDue
FROM SalesLT.Customer as c
INNER JOIN SalesLT.CustomerAddress as ca on c.CustomerID = ca.CustomerID
INNER JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
INNER JOIN SalesLT.SalesOrderHeader as soh on c.CustomerID = soh.CustomerID
WHERE soh.TotalDue IN
(
	SELECT MAX(soh.TotalDue)
	FROM [SalesLT].[SalesOrderHeader] as soh
	INNER JOIN SalesLT.CustomerAddress as ca ON soh.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
	Group BY a.StateProvince
)
ORDER BY soh.TotalDue DESC
