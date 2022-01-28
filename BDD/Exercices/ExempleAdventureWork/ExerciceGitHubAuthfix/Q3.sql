/*Combien de produits avec un prix > 1000$ ont �t� vendues */
--SELECT OrderQty, UnitPrice, UnitPriceDiscount -- Pour voir les produit en eux m�me
--SELECT SUM(OrderQty) -- tout les produit vendue
SELECT COUNT(DISTINCT ProductID) -- toutes les r�f�rences de produit qui ont �t� en ventes
FROM SalesLT.SalesOrderDetail
WHERE UnitPrice > 1000 

/*Correction */
SELECT SUM(sod.OrderQty) as Quantity
FROM [SalesLT].[SalesOrderDetail] as sod
WHERE sod.UnitPrice > 1000


