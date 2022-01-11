/*Retrouver les companies dont les clients ont command�s pour plus de 10.000$ (en incluant le sous-total, les taxes et les frais de transport) */
SELECT c.CompanyName, sum(sah.SubTotal+sah.TaxAmt+sah.Freight) as total
FROM SalesLT.Customer as c, SalesLT.SalesOrderHeader as sah
WHERE c.CustomerID = sah.CustomerID 
GROUP BY c.CompanyName
HAVING sum(sah.SubTotal+sah.TaxAmt+sah.Freight)> 10000
