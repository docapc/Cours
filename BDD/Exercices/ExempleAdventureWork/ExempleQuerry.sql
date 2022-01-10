--SELECT FirstName as Prenom, EmailAddress as mail -- on peut utiliser des wildcard et/ou des alias via as
--SELECT * 
--FROM SalesLT.Customer
--WHERE FirstName LIKE '%don%' OR LastName LIKE '%arr%'

--Exemple un peu plus complexe avec fonction d'aggrégat pour calcul
--SELECT TOP(10) ListPrice, Color
--FROM SalesLT.Product
--ORDER BY ListPrice ASC -- ou DESC

-- Exemple de groupe by (avec fonction d'aggrégat obligatoire)
--SELECT ProductCategoryID,  SUM(ListPrice) 
--FROM SalesLT.Product
--GROUP BY ProductCategoryID

-- Exemple de Jointure
SELECT SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.ProductCategory.Name -- Name va lier à ce qu'il y a en dessous
FROM SalesLT.Product
JOIN SalesLT.ProductCategory ON SalesLT.ProductCategory.ProductCategoryID = SalesLT.Product.ProductCategoryID

-- Même chose avec alias (pour les clefs et pour les Nom de colonnes)
SELECT p.ProductID, p.Name as ProductName, c.Name as CategoryName -- Name va lier à ce qu'il y a en dessous
FROM SalesLT.Product as p
JOIN SalesLT.ProductCategory as c ON c.ProductCategoryID = p.ProductCategoryID
