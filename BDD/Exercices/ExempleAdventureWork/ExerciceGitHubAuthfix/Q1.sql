/*Retrouver le prénom et l'adresse email du client qui a pour nom de compagnie, 'Bike World' */
SELECT FirstName, EmailAddress
FROM SalesLT.Customer
WHERE CompanyName = 'Bike World'

/*Correction : 
Si on a qu'une seule table dans le from on est pas obligé de mettre la table associée
dans le nom des champs au niveau du select.
*/
SELECT c.FirstName as Prénom, c.EmailAddress
FROM [SalesLT].[Customer] as c
WHERE CompanyName = 'Bike World'