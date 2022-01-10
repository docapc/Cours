/*Pour chaque client avec un 'Main Office' à Dallas, retrouvez la première ligne de l'adresse de livraison. 
Si aucune adresse n'existe, laissez là vide. N'ayez qu'une seule ligne par client.*/

--SELECT *
--FROM SalesLT.Customer as c

--SELECT *
--FROM SalesLT.Address as p

--SELECT c.FirstName, c.LastName, a.City, a.AddressLine1 
SELECT c.FirstName, c.LastName, MAX(a.AddressLine1) -- tricky mais sa marche...
FROM SalesLT.Customer as c
JOIN SalesLT.CustomerAddress as ca ON c.CustomerID = ca.CustomerID
JOIN SalesLT.Address as a ON ca.AddressID = a.AddressID
WHERE a.City = 'Dallas'
GROUP BY c.FirstName, c.LastName
--HAVING a.City = 'Dallas'

