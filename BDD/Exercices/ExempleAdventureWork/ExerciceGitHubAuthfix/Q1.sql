/*Retrouver le pr�nom et l'adresse email du client qui a pour nom de compagnie, 'Bike World' */
SELECT FirstName, EmailAddress
FROM SalesLT.Customer
WHERE CompanyName = 'Bike World'

/*Correction : 
Si on a qu'une seule table dans le from on est pas oblig� de mettre la table associ�e
dans le nom des champs au niveau du select.
*/
SELECT c.FirstName as Pr�nom, c.EmailAddress
FROM [SalesLT].[Customer] as c
WHERE CompanyName = 'Bike World'