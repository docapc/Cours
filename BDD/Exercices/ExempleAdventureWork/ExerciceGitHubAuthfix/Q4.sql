/*Retrouver les companies dont les clients ont commandés pour plus de 10.000$ (en incluant le sous-total, les taxes et les frais de transport) */
SELECT c.CompanyName, sum(sah.SubTotal+sah.TaxAmt+sah.Freight) as total
FROM SalesLT.Customer as c, SalesLT.SalesOrderHeader as sah
WHERE c.CustomerID = sah.CustomerID 
GROUP BY c.CompanyName
HAVING sum(sah.SubTotal+sah.TaxAmt+sah.Freight)> 10000

/*Correction */
SELECT c.CompanyName, SUM(sod.TotalDue) as Total
FROM [SalesLT].[Customer] as c
INNER JOIN [SalesLT].[SalesOrderHeader] as sod ON c.CustomerID = sod.CustomerID
GROUP BY c.CompanyName
HAVING SUM(sod.TotalDue)>10000