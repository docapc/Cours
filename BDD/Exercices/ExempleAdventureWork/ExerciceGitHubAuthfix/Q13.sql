/*Retrouvez l'article le plus vendu, par valeur.*/

-- List les produits par valeur totale rapportée (puis TOP 1 pour avoir le max)
SELECT TOP(1) sod.ProductID, p.Name, MAX(sod.UnitPrice) as UnitPrice, SUM(sod.OrderQty) as QttTot, SUM(sod.UnitPrice*sod.OrderQty) as MoneyByProduct
FROM SalesLT.Product as p
JOIN SalesLT.SalesOrderDetail as sod ON p.ProductId = sod.ProductID
GROUP BY sod.ProductID, p.Name
ORDER BY MoneyByProduct DESC 
