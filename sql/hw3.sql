-- 1
SELECT DISTINCT E.City
FROM Employees E
JOIN Customers C ON E.City = C.City;
-- 2
SELECT DISTINCT C.City
FROM Customers C
LEFT JOIN Employees E ON C.City = E.City
WHERE E.City IS NULL;
-- 3
SELECT P.ProductName, SUM(OD.Quantity) AS Total
FROM Products P
JOIN [Order Details] OD ON P.ProductID = OD.ProductID
GROUP BY P.ProductName;
-- 4
SELECT C.City, SUM(OD.Quantity) AS Total
FROM Customers C
JOIN Orders O On C.CustomerID = O.CustomerID
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
GROUP By C.City;
-- 5
SELECT City 
FROM Customers 
GROUP BY City 
HAVING COUNT(CustomerID) >= 2;
-- 6
SELECT C.City
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
GROUP BY C.City
HAVING COUNT(DISTINCT OD.ProductID) >= 2;
-- 7
SELECT DISTINCT C.CustomerID
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
WHERE C.City <> O.ShipCity;
-- 8
SELECT TOP 5 P.ProductName, 
       AVG(P.UnitPrice) AS AvgPrice,
       (SELECT TOP 1 C.City 
        FROM Orders O
        JOIN Customers C ON O.CustomerID = C.CustomerID
        JOIN [Order Details] OD ON O.OrderID = OD.OrderID
        WHERE OD.ProductID = P.ProductID
        GROUP BY C.City
        ORDER BY SUM(OD.Quantity) DESC
        ) AS TopOrderingCity,
       SUM(OD.Quantity) AS TotalOrdered
FROM Products P
JOIN [Order Details] OD ON P.ProductID = OD.ProductID
GROUP BY P.ProductID, P.ProductName
ORDER BY TotalOrdered DESC;
-- 9
SELECT DISTINCT E.City
FROM Employees E
LEFT JOIN Orders O ON E.City = O.ShipCity
WHERE O.ShipCity IS NULL;
-- 10
WITH EmployeeCity AS (
    SELECT TOP 1 E.City
    FROM Employees E
    JOIN Orders O ON E.EmployeeID = O.EmployeeID
    GROUP BY E.City
    ORDER BY COUNT(O.OrderID) DESC
),
ProductCity AS (
    SELECT TOP 1 O.ShipCity
    FROM Orders O
    JOIN [Order Details] OD ON O.OrderID = OD.OrderID
    GROUP BY O.ShipCity
    ORDER BY SUM(OD.Quantity) DESC
)
SELECT EC.City
FROM EmployeeCity EC
JOIN ProductCity PC ON EC.City = PC.ShipCity;
-- 11
SELECT DISTINCT *;



