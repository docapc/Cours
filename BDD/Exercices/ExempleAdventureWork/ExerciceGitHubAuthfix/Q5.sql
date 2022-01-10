/*Retrouver le nombre de chaussettes de courses, command�es par la soci�t� 'Riding Cycles'*/
--SELECT *
--FROM SalesLT.ProductCategory 

--SELECT *
--FROM SalesLT.Product

--SELECT *
--FROM SalesLT.ProductModel
--SELECT SUM(sod.OrderQty) -- le nombre de chaussettes
SELECT p.Name, soh.OrderDate, sod.OrderQty, sod.SalesOrderID, soh.SalesOrderID , c.CompanyName -- le d�tail
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
and soh.SalesOrderID = sod.SalesOrderIDl
and c.CompanyName = 'Riding Cycles'