--Can Uncoment the drop login once user is created to avoid compiling erros, added a user for use in connection string
--DROP LOGIN NostalgicGamesDBUser
--CREATE LOGIN NostalgicUser WITH PASSWORD = 'ABC123', DEFAULT_DATABASE = NostalgicGamesDB
--CREATE database NostalgicGamesDB

-- Drops all tables before creating new ones to avoid compiling errors
DROP TABLE OrderDetails
DROP TABLE Orders
DROP TABLE Admin
DROP TABLE Customer
DROP TABLE Products
--DROP TABLE Payment
DROP TABLE Category

--cateogry table to store the different types of categories a product can have 
CREATE TABLE Category (
CategoryID INT IDENTITY(1,1) PRIMARY KEY, -- the identity tag creates an ID starting from 1, and then going up by one for each new creation 
CategoryName VARCHAR(30) NOT NULL,
Description TEXT
)

-- payment table created to store payment information
--CREATE TABLE Payment (
--PaymentID INT IDENTITY(1,1) PRIMARY KEY,
--CardNo INT Unique NOT NULL,
--NameOnCard VARCHAR(70) NOT NULL,
--ExpiryDate DATE NOT NULL,
--CVV INT NOT NULL,
--)

-- Products table to store products that will be available on the site
CREATE TABLE Products (
ProductID INT PRIMARY KEY IDENTITY(1,1),
CategoryID INT NOT NULL, -- category fk to show what category the product belongs to 
Name VARCHAR(30) NOT NULL,
Type VARCHAR(20) NOT NULL,
Platform VARCHAR(40) NOT NULL,
AmountAvailable INT NOT NULL DEFAULT 0,
Price DECIMAL NOT NULL DEFAULT 0, -- setting default amounts of price and amount available to 0
Description TEXT,
ImageFile VARCHAR(300),
FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON UPDATE CASCADE ON DELETE NO ACTION,
)

CREATE TABLE Customer (
UserID INT PRIMARY KEY IDENTITY(1,1),
--PaymentID INT UNIQUE, --has payment ID as a foreign key so the admin can refer back to what type of payment the user is using to pay for items in the payments table
FirstName VARCHAR(30),
--MiddleName VARCHAR(30),
LastName VARCHAR(35),
StreetNo VARCHAR(8),
Street VARCHAR(30),
Suburb VARCHAR(40),
Postcode VARCHAR(10),
State VARCHAR(5),
Status VARCHAR(20) NOT NULL DEFAULT 'Active',
Country VARCHAR(30),
Email VARCHAR(255) UNIQUE NOT NULL,
Phone VARCHAR(30),
Password VARCHAR(40) NOT NULL,
DateJoined DATE NOT NULL DEFAULT GETDATE(),
--FOREIGN KEY (PaymentID) REFERENCES Payment(PaymentID) ON UPDATE CASCADE ON DELETE NO ACTION,
CHECK (Status IN ('Active', 'Suspended')) -- checking to make sure the status is either active or suspended 
)

CREATE TABLE Admin ( --stores details of who the admins are on the site
UserID INT IDENTITY(1,1) PRIMARY KEY,
AdminNo CHAR(5) Unique NOT NULL, -- a number given to an admin before registration so they are able to validate their admin status
Password VARCHAR(40) NOT NULL,
FirstName VARCHAR(30),
MiddleName VARCHAR(30),
LastName VARCHAR(35),
Email VARCHAR(30),
Phone VARCHAR(30),	
)

CREATE TABLE Orders ( --stores orders made by users in the database
OrderID INT IDENTITY(1,1) PRIMARY KEY, 
UserID INT,
PaymentID INT,
OrderStatus VARCHAR(15) NOT NULL DEFAULT 'Not Shipped',
PayStatus VARCHAR(10) NOT NULL DEFAULT 'Unpaid',
Total INT NOT NULL,
FOREIGN KEY (userID) REFERENCES Customer(UserID) ON UPDATE CASCADE ON DELETE NO ACTION, --originally had payment ID as a FK, but decided to put it on user so admin can just refer to user to get payment details
FOREIGN KEY (PaymentID) REFERENCES Payment(PaymentID) ON UPDATE CASCADE ON DELETE NO ACTION,
CHECK (OrderStatus IN ('Not Shipped', 'Shipped')),
CHECK (PayStatus IN ('Unpaid', 'Paid')), --checks to validate input
)

--stores the order id and what products were purchased in that order, has orderID and ProductID as FK to be able to store an order with multiple products
CREATE TABLE OrderDetails (
OrderID INT,
ProductID INT,
Quantity INT DEFAULT 0,
DateOrdered DATE NOT NULL DEFAULT GETDATE(),
OrderTotal INT DEFAULT 0 NOT NULL,
ShippingAdress VARCHAR(200),
PRIMARY KEY (OrderID, ProductID),
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON UPDATE CASCADE ON DELETE NO ACTION 
)
--INSERT INTO Customer (FirstName, LastName, StreetNo, Street, Suburb, Postcode, State, Status, Country, Email, Phone) VALUES ('J', 'J', '1', 'john street', 'jesmond', '2337', 'NSW', 'Active', 'Australia', 'jack', '20')
INSERT INTO Category (CategoryName, Description) VALUES ('Platform', 'Its a platform');
INSERT INTO Category (CategoryName, Description) VALUES ('Controller', 'Its a Controller');
--INSERT INTO Products (CategoryID, Name, type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES (1, 'James', 'f', 'f', 0, 0, 'f', 'f');
--INSERT INTO Orders (OrderStatus, PayStatus) VALUES ('Shipped', 'Paid');
INSERT INTO Category (CategoryName, Description) VALUES ('Peripherals', 'Its a Peripheral');
INSERT INTO Category (CategoryName, Description) VALUES ('Game', 'Its a Game');

INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES ('Call of Duty: 2', 4, 'Windows Platform', 'PC', 7, 23.00, 'Call of Duty 2 is a first-person shooter video game developed by Infinity Ward and published by Activision in most regions of the world. It is the second installment of the Call of Duty series. Announced by Activision on April 7, 2005, the game was released on October 25, 2005, for Microsoft Windows and on November 22, 2005,[2] as a launch title for the Xbox 360. Other versions were eventually released for OS X, mobile phones, and Pocket PCs.', 'Call_of_Duty_2_Box.jpg');
INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES ('Adventure Island', 4, 'NES Game', 'NES', 23, 100.00, 'Hudsons Adventure Island[a] is a side-scrolling platform game produced by Hudson Soft that was released in Japan for the Famicom and MSX on September 12, 1986. It was released in North America for the Nintendo Entertainment System on September 1988 and in the PAL region in 1992 under the title of Adventure Island Classic.', 'Adventureisland.jpg');
INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES ('NES Controller', 2, 'NES Controller', 'NES', 2, 34.00, 'Controller for NES game console', '9200000061822270.jpg');
INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES ('Dreamcast console', 1, '', 'Dreamcast', 23, 234.00, 'Full Dreamcast console', 's-l640.jpg');
INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES ('Jetset Radio', 4, 'Dreamcast Game', 'Dreamcast', 23, 234.00, 'et Set Radio,[a] titled Jet Grind Radio on the first North American release, is an action game developed by Smilebit and published by Sega for the Dreamcast in 2000. The player controls one of a gang of youths who skate the streets of a fictionalized Tokyo on inline skates, spraying graffiti and evading the authorities. It was one of the first games to use cel-shaded visuals, giving it a cartoon-like appearance.', '71LEOKRqYkL._SX342_.jpg');
INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES ('NES Super Scope', 3, 'Rocket Scope', 'NES', 23, 234.99, 'The Super Scope, sold as the Nintendo Scope in Europe and Australia,[1][2] is a first party light gun peripheral for the Super Nintendo Entertainment System. The successor to the NES Zapper, the Super Scope was released in North America and the PAL region in 1992, followed by a limited release in Japan in 1993 due to a lack of consumer demand. The peripheral consists of two devices: the wireless light gun itself, called the Transmitter, and a Receiver that connects to the second controller port of the Super NES console. The Transmitter has two action buttons, a pause button, a power switch and is powered by six AA batteries.', '95cc3038055e70b9dddfe9b80471905b.jpg');



INSERT INTO Customer (Email, Password) VALUES('johnwick@gmail.com', 'Password1#')
INSERT INTO Customer (Email, Password) VALUES('garfield@gmail.com', 'Password1#')
INSERT INTO Customer (Email, Password) VALUES('rick@gmail.com', 'Password1#')
INSERT INTO Customer (Email, Password) VALUES('morty@gmail.com', 'Password1#')

INSERT INTO Admin(AdminNo, Password) VALUES (12345, 'Password1#')

SELECT * FROM Products
SELECT * FROM Category
SELECT * FROM Customer
SELECT * FROM Admin

;
