DROP TABLE Orders;
DROP TABLE Users;

CREATE TABLE Users
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Address1 VARCHAR(200) NOT NULL,
    Address2 VARCHAR(100),
    City VARCHAR(100) NOT NULL,
    State CHAR(2) NOT NULL
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(ID) NOT NULL,
    DateOrder DATETIME NOT NULL
);

INSERT INTO Users (Name, Email, Address1, City, State) VALUES 
('Siavash Nezhad' , 'siavash1996@yahoo.com' , '2110 Aztec Thrush Drive' , 'Katy' , 'TX'),
('Chaddington Longbottom' , 'iamcringe247@hotmail.com' , '21 Jump Street' , 'Springfield' , 'MO'),
('Sarah Nezhad' , 'sarahnezhad@yahoo.com' , '2110 Aztec Thrush Drive' , 'Katy' , 'TX'),
('Shahin Nezhad' , 'shahinnejad@hotmail.com' , '7514 Old Bridge Court' , 'Sugar Land' , 'TX');

SELECT * FROM Users;