/*Retrouver les noms de compagnies qui ont pour ville 'Dallas'
Attention en théorie il faudrait aussi tester l'adresse type dans la table
CustomerAdress (main adress ou shipping). Sinon on met un distinct*/
SELECT DISTINCT customer.CompanyName
FROM SalesLT.Customer as customer, SalesLT.CustomerAddress as ca, SalesLT.Address as address
WHERE customer.CustomerID = ca.CustomerID and address.AddressID = ca.AddressID and address.City = 'Dallas' 

/*Correction : 
il est aussi possible de mettre des c.* pour ne renvoyer qu'une partie des champs
*/
SELECT c.CompanyName, a.City
FROM [SalesLT].[Customer] as c
INNER JOIN [SalesLT].[CustomerAddress] as ca ON c.CustomerID = ca.CustomerID	
INNER JOIN [SalesLT].[Address] as a ON ca.AddressID = a.AddressID
WHERE a.City = 'Dallas'

