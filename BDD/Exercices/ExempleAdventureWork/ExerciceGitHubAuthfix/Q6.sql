/*Une « commande d'article unique » est une commande client pour laquelle un seul article est commandé. 
Affichez le SalesOrderID et le UnitPrice pour chaque commande d'article unique. */

--SELECT * 
SELECT sod.SalesOrderID, SUM(sod.UnitPrice) as price, COUNT(sod.UnitPrice) as Count_price--, sod.ProductID
FROM SalesLT.SalesOrderDetail as sod
--JOIN SalesLT.SalesOrderDetail as soh ON soh.SalesOrderID = sod.SalesOrderID
WHERE sod.OrderQty = 1 
GROUP BY sod.SalesOrderID--, sod.UnitPrice
HAVING COUNT(sod.ProductID) = 1