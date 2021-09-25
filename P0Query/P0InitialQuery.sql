DROP TABLE Orders;
DROP TABLE Users;

CREATE TABLE Users
(
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Address VARCHAR(200) NOT NULL,
    City VARCHAR(100) NOT NULL,
    State CHAR(2) NOT NULL
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Users(CustomerID) NOT NULL,
    DateOrder DATETIME NOT NULL
);

INSERT INTO Users (Name, Email, Address, City, State) VALUES 
('Siavash Nezhad' , 'siavash1996@yahoo.com' , '2110 Aztec Thrush Drive' , 'Katy' , 'TX'),
('Chaddington Longbottom' , 'iamcringe247@hotmail.com' , '21 Jump Street' , 'Springfield' , 'MO'),
('Sarah Nezhad' , 'sarahnezhad@yahoo.com' , '2110 Aztec Thrush Drive' , 'Katy' , 'TX'),
('Shahin Nezhad' , 'shahinnejad@hotmail.com' , '7514 Old Bridge Court' , 'Sugar Land' , 'TX');

SELECT * FROM Users;