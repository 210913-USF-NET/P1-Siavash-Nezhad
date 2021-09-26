DROP TABLE [Order];
DROP TABLE Customer;
DROP TABLE LineItem;
DROP TABLE StoreFront;
DROP TABLE Inventory;
DROP TABLE Product;

CREATE TABLE Customer
(
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Address VARCHAR(200) NOT NULL,
    City VARCHAR(100) NOT NULL,
    State VARCHAR(2) NOT NULL
);

CREATE TABLE [Order]
(
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID) NOT NULL,
    DateOrder DATETIME NOT NULL
);

CREATE TABLE LineItem
(
    LineItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES [Order](OrderID) NOT NULL,
    StoreID INT FOREIGN KEY REFERENCES StoreFront(StoreID) NOT NULL,
    ProductID INT FOREIGN KEY REFERENCES Product(ProductID) NOT NULL,
    Quantity INT NOT NULL
);

CREATE TABLE StoreFront
(
    StoreID INT PRIMARY KEY IDENTITY(1,1),
    Address VARCHAR(150) NOT NULL
);

CREATE TABLE Inventory
(
    InventoryID INT PRIMARY KEY IDENTITY(1,1),
    StoreID INT FOREIGN KEY REFERENCES StoreFront(StoreID) NOT NULL,
    ProductID INT FOREIGN KEY REFERENCES Product(ProductID) NOT NULL,
    Quantity INT NOT NULL
);

CREATE TABLE Product
(
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    DiscFormat VARCHAR(40) NOT NULL,
    DiscCap INT NOT NULL,
    Color VARCHAR(30) NOT NULL,
    Price DECIMAL(2,2) NOT NULL
);

/*INSERT INTO Customer (Name, Email, Address, City, State) VALUES 
('Siavash Nezhad' , 'siavash1996@yahoo.com' , '2110 Aztec Thrush Drive' , 'Katy' , 'TX'),
('Chaddington Longbottom' , 'iamcringe247@hotmail.com' , '21 Jump Street' , 'Springfield' , 'MO'),
('Sarah Nezhad' , 'sarahnezhad@yahoo.com' , '2110 Aztec Thrush Drive' , 'Katy' , 'TX'),
('Shahin Nezhad' , 'shahinnejad@hotmail.com' , '7514 Old Bridge Court' , 'Sugar Land' , 'TX');*/

/*SELECT * FROM Customer;*/