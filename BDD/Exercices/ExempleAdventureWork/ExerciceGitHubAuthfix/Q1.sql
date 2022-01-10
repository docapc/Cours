/*Retrouver le prénom et l'adresse email du client qui a pour nom de compagnie, 'Bike World' */
SELECT FirstName, EmailAddress
FROM SalesLT.Customer
WHERE CompanyName = 'Bike World'
