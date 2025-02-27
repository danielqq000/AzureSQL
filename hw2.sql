-- 1
SELECT COUNT(*)
FROM Production.Product;
-- 2
SELECT COUNT(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL;
-- 3
SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID;
-- 4
SELECT COUNT(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;
-- 5
SELECT SUM(Quantity)
FROM Production.ProductInventory
-- 6
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100;
-- 7
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;
-- 8
SELECT AVG(Quantity)
FROM Production.ProductInventory
WHERE LocationID = 10;
-- 9
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf;
-- 10
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf;
-- 11
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class;
-- 12
SELECT CR.Name AS Country, SP.Name AS Province
FROM Person.CountryRegion CR
JOIN Person.StateProvince SP ON CR.CountryRegionCode = SP.CountryRegionCode;
-- 13
SELECT CR.Name AS Country, SP.Name AS Province
FROM Person.CountryRegion CR
JOIN Person.StateProvince SP ON CR.CountryRegionCode = SP.CountryRegionCode
WHERE CR.Name = 'Germany' OR CR.Name = 'Canada';
-- 14
SELECT DISTINCT P.ProductName AS Product
FROM Products P
JOIN [Order Details] OD ON P.ProductID = OD.ProductID
JOIN Orders O ON OD.OrderID = O.OrderID
WHERE O.OrderDate >= DATEADD(YEAR, -27, GETDATE());
-- 15
SELECT TOP 5 O.ShipPostalCode AS ZipCode, SUM(OD.Quantity) AS TotalQuantitySold
FROM Orders O
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
GROUP BY O.ShipPostalCode
ORDER BY TotalQuantitySold DESC;
-- 16
SELECT TOP 5 O.ShipPostalCode AS ZipCode, SUM(OD.Quantity) AS TotalQuantitySold
FROM Orders O
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
WHERE O.OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY O.ShipPostalCode
ORDER BY TotalQuantitySold DESC;
-- 17
SELECT C.City, COUNT(C.CustomerID) AS NumberOfCustomers
FROM Customers C
GROUP BY C.City;
-- 18
SELECT C.City, COUNT(C.CustomerID) AS NumberOfCustomers
FROM Customers C
GROUP BY C.City
HAVING COUNT(C.CustomerID) > 2;
-- 19
SELECT C.CompanyName, O.OrderDate
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
WHERE O.OrderDate > '1998-01-01';
-- 20
SELECT C.CompanyName, MAX(O.OrderDate) AS MostRecentOrderDate
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
GROUP BY C.CompanyName
-- 21
SELECT C.CompanyName, COUNT(OD.ProductID) AS TotalProductsBought
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
GROUP BY C.CompanyName;
-- 22
SELECT C.CustomerID, SUM(OD.Quantity) AS TotalProductsBought
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
GROUP BY C.CustomerID
HAVING SUM(OD.Quantity) > 100;
-- 23
SELECT DISTINCT S.CompanyName AS SupplierCompanyName, SH.CompanyName AS ShippingCompanyName
FROM Suppliers S
JOIN Products P ON S.SupplierID = P.SupplierID
JOIN Shippers SH ON P.SupplierID = SH.ShipperID;
-- 24
SELECT O.OrderDate, P.ProductName
FROM Orders O
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID
ORDER BY O.OrderDate;
-- 25
SELECT E1.FirstName + ' ' + E1.LastName AS Employee1Name, 
       E2.FirstName + ' ' + E2.LastName AS Employee2Name
FROM Employees E1
JOIN Employees E2 ON E1.Title = E2.Title AND E1.EmployeeID < E2.EmployeeID;
-- 26
SELECT E.FirstName + ' ' + E.LastName AS ManagerName
FROM Employees E
JOIN Employees E2 ON E.EmployeeID = E2.ReportsTo
GROUP BY E.EmployeeID, E.FirstName, E.LastName
HAVING COUNT(E2.EmployeeID) > 2;
-- 27
SELECT C.City, C.CompanyName AS Name, C.ContactName, 'Customer' AS Type
FROM Customers C
UNION ALL
SELECT S.City, S.CompanyName AS Name, S.ContactName, 'Supplier' AS Type
FROM Suppliers S;
