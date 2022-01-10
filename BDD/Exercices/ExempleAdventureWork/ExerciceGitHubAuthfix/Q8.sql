/*Retrouver la description du produit avec l'identifiant 736 pour la langue française. */

SELECT p.ProductID, p.Name, pd.Description, pmpd.Culture
FROM SalesLT.Product as p
--JOIN SalesLT.ProductModel as pm ON p.ProductModelID = pm.ProductModelID
JOIN SalesLT.ProductModelProductDescription as pmpd ON p.ProductModelID = pmpd.ProductModelID
JOIN SalesLT.ProductDescription as pd ON pmpd.ProductDescriptionID = pd.ProductDescriptionID
WHERE p.ProductID = 736 and pmpd.Culture = 'fr'