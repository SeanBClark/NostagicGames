--INSERT INTO Products (CategoryID, Name, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES (1, 'A', 'B', 'S', 0, 0, 'S', 'p')
--delete from Products where AmountAvailable = 0
--select * from Products
--INSERT INTO Customer (Email, Password) VALUES ('aron.oss@gmail.com', 'Abcdefg123');
--DELETE FROM Customer WHERE State IS NULL;
--SELECT * FROM Customer
--SELECT Email, Password FROM Customer WHERe Email = 'ab@gmail.com' AND UserID = 12
--DELETE FROM Customer WHERE FirstName IS NULL
SELECT * FROM Customer
--SELECT * FROM Admin
SELECT ProductID, Name, type, platform, price, Description, ImageFile FROM Products