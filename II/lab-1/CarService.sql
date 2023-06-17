CREATE DATABASE CarService;

GO

USE CarService;

CREATE TABLE Customer (
  customerID INT PRIMARY KEY,
  customerName VARCHAR(50),
  email VARCHAR(50),
  phone VARCHAR(20)
);

CREATE TABLE Vehicle (
  VIN INT PRIMARY KEY,
  make VARCHAR(50),
  model VARCHAR(50),
  vehicleYear INT
);

CREATE TABLE Invoice (
  customerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
  VIN INT FOREIGN KEY REFERENCES Vehicle(VIN)
  CONSTRAINT pkInvoice PRIMARY KEY(customerID, VIN),
  totalCost DECIMAL(8, 2),
  paymentStatus VARCHAR(20)
);

CREATE TABLE Repair (
  repairID INT PRIMARY KEY,
  customerID INT,
  VIN INT,
  FOREIGN KEY(customerID, VIN) REFERENCES Invoice(customerID, VIN)
  ON UPDATE CASCADE
  ON DELETE SET NULL,
  repairName VARCHAR(50),
  repairDescription VARCHAR(250),
  price DECIMAL(8, 2)
);

CREATE TABLE Appointment (
  customerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
  VIN INT FOREIGN KEY REFERENCES Vehicle(VIN),
  repairID INT FOREIGN KEY REFERENCES Repair(repairID)
  CONSTRAINT pkAppointment PRIMARY KEY(customerID, VIN, repairID),
  appointmentDate DATETIME
);

CREATE TABLE Payment (
  paymentID INT PRIMARY KEY,
  customerID INT,
  VIN INT,
  FOREIGN KEY(customerID, VIN) REFERENCES Invoice(customerID, VIN)
  ON UPDATE CASCADE
  ON DELETE SET NULL,
  amount DECIMAL(8, 2),
  paymentDate DATETIME
);

CREATE TABLE Part (
  partID INT PRIMARY KEY,
  partName VARCHAR(50),
  supplier VARCHAR(50),
  totalQuantity INT
);

CREATE TABLE Register (
  VIN INT FOREIGN KEY (VIN) REFERENCES Vehicle(VIN),
  partID INT FOREIGN KEY REFERENCES Part(partID)
  CONSTRAINT pkRegister PRIMARY KEY(VIN, partID),
  quantity INT
);

CREATE TABLE Employee (
  employeeID INT PRIMARY KEY,
  employeeName VARCHAR(50),
  email VARCHAR(50),
  phone VARCHAR(20),
  jobRole VARCHAR(50)
);

CREATE TABLE Timesheet (
  employeeID INT FOREIGN KEY REFERENCES Employee(employeeID),
  repairID INT FOREIGN KEY REFERENCES Repair(repairID)
  CONSTRAINT pkTimesheet PRIMARY KEY(employeeID, repairID),
  timesheetDate DATETIME,
  startTime DATETIME,
  endTime DATETIME
);
