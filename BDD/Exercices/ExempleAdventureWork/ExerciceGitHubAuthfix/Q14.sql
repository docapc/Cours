/*Retrouvez combien de commandes sont dans les intervals suivants : 0-99, 100-999, 1000-9999, 10000 */
/*Note Perso : je considère ces chiffres comme étant des totaux dues (Money) par commande*/
SELECT DISTINCT -- ou Bien TOP(1)
(SELECT COUNT(soh.SalesOrderID) FROM SalesLT.SalesOrderHeader as soh WHERE soh.TotalDue BETWEEN 0 AND 99) as I0_to_99, 
(SELECT COUNT(soh.SalesOrderID) FROM SalesLT.SalesOrderHeader as soh WHERE soh.TotalDue BETWEEN 100 AND 999) as I100_to_999,
(SELECT COUNT(soh.SalesOrderID) FROM SalesLT.SalesOrderHeader as soh WHERE soh.TotalDue BETWEEN 1000 AND 9999) as I1000_to_9999,
(SELECT COUNT(soh.SalesOrderID) FROM SalesLT.SalesOrderHeader as soh WHERE soh.TotalDue > 10000) as IOver10000, 
(SELECT COUNT(soh.SalesOrderID) FROM SalesLT.SalesOrderHeader as soh) as TotalNumber
FROM SalesLT.SalesOrderHeader

--version colonne par colonne
SELECT COUNT(soh.SalesOrderID) as I0_to_99
FROM SalesLT.SalesOrderHeader as soh 
WHERE soh.TotalDue BETWEEN 0 AND 99

SELECT COUNT(soh.SalesOrderID) as I100_to_999
FROM SalesLT.SalesOrderHeader as soh 
WHERE soh.TotalDue BETWEEN 100 AND 999

SELECT COUNT(soh.SalesOrderID) as I1000_to_9999
FROM SalesLT.SalesOrderHeader as soh 
WHERE soh.TotalDue BETWEEN 1000 AND 9999

SELECT COUNT(soh.SalesOrderID) as IOver10000
FROM SalesLT.SalesOrderHeader as soh 
WHERE soh.TotalDue > 10000