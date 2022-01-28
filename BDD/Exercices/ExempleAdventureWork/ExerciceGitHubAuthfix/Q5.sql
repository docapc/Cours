/*Retrouver le nombre de chaussettes de courses, commandées par la société 'Riding Cycles'*/
--SELECT *
--FROM SalesLT.ProductCategory 

--SELECT *
--FROM SalesLT.Product

--SELECT *
--FROM SalesLT.ProductModel
--SELECT SUM(sod.OrderQty) -- le nombre de chaussettes
SELECT p.Name, soh.OrderDate, sod.OrderQty, sod.SalesOrderID, soh.SalesOrderID , c.CompanyName -- le détail
FROM 
	 SalesLT.SalesOrderDetail as sod,
	 SalesLT.Customer as c,  
	 SalesLT.ProductCategory as pc,
	 SalesLT.Product as p, 
	 SalesLT.SalesOrderHeader as soh
WHERE  -- on peut aussi remplacer la cascade de from where avec par des join en cascade
	pc.Name = 'Socks'
and pc.ProductCategoryID = p.ProductCategoryID
and p.Name LIKE '%racing%' -- OR p.Name LIKE '%sports%'
and p.ProductID = sod.ProductID
and c.CustomerID = soh.CustomerID
and soh.SalesOrderID = sod.SalesOrderID
and c.CompanyName = 'Riding Cycles'

/*Correction 
Note le as est facultatif!*/
SELECT *
FROM [SalesLT].[Product] as p
WHERE p.Name like '%Sock%'

SELECT SUM(sod.OrderQty)
FROM [SalesLT].[Customer] as c
INNER JOIN [SalesLT].[SalesOrderHeader] as soh ON c.CustomerID = soh.CustomerID
INNER JOIN [SalesLT].[SalesOrderDetail] as sod ON soh.SalesOrderID = sod.SalesOrderID
INNER JOIN [SalesLT].[Product] as p ON sod.ProductID = p.ProductID
WHERE c.CompanyName like 'Riding Cycles'
AND p.Name like '%Racing Socks%'
