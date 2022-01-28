/*Combien de produits avec un prix > 1000$ ont été vendues */
--SELECT OrderQty, UnitPrice, UnitPriceDiscount -- Pour voir les produit en eux même
--SELECT SUM(OrderQty) -- tout les produit vendue
SELECT COUNT(DISTINCT ProductID) -- toutes les références de produit qui ont été en ventes
FROM SalesLT.SalesOrderDetail
WHERE UnitPrice > 1000 

/*Correction */
SELECT SUM(sod.OrderQty) as Quantity
FROM [SalesLT].[SalesOrderDetail] as sod
WHERE sod.UnitPrice > 1000


