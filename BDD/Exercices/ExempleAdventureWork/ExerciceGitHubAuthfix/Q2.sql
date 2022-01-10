/*Retrouver les noms de compagnies qui ont pour ville 'Dallas' */
SELECT customer.CompanyName
FROM SalesLT.Customer as customer, SalesLT.CustomerAddress as ca, SalesLT.Address as address
WHERE customer.CustomerID = ca.CustomerID and address.AddressID = ca.AddressID and address.City = 'Dallas' 



