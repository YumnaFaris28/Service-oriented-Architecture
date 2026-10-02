USE NWSDB_WaterBilling;
GO

-- Update or insert Customer 1
IF EXISTS (SELECT 1 FROM Customers WHERE CustomerId = 1)
BEGIN
    UPDATE Customers 
    SET CustomerName = 'Hana Himly', AccountNumber = 'NWS-10001', CustomerAddress = 'No. 45, Galle Road, Colombo 03' 
    WHERE CustomerId = 1;
END
ELSE
BEGIN
    SET IDENTITY_INSERT Customers ON;
    INSERT INTO Customers (CustomerId, CustomerName, CustomerAddress, AccountNumber) 
    VALUES (1, 'Hana Hilmy', 'No. 45, Galle Road, Colombo 03', 'NWS-10001');
    SET IDENTITY_INSERT Customers OFF;
END

-- Update or insert Customer 2
IF EXISTS (SELECT 1 FROM Customers WHERE CustomerId = 2)
BEGIN
    UPDATE Customers 
    SET CustomerName = 'Ajmal Rizwan', AccountNumber = 'NWS-10002', CustomerAddress = 'No. 12, Peradeniya Road, Kandy' 
    WHERE CustomerId = 2;
END
ELSE
BEGIN
    SET IDENTITY_INSERT Customers ON;
    INSERT INTO Customers (CustomerId, CustomerName, CustomerAddress, AccountNumber) 
    VALUES (2, 'Ajmal Rizwan', 'No. 12, Peradeniya Road, Kandy', 'NWS-10002');
    SET IDENTITY_INSERT Customers OFF;
END

-- Update or insert Customer 3
IF EXISTS (SELECT 1 FROM Customers WHERE CustomerId = 3)
BEGIN
    UPDATE Customers 
    SET CustomerName = 'Uzmna Badhusha', AccountNumber = 'NWS-10003', CustomerAddress = 'No. 88, Matara Road, Galle' 
    WHERE CustomerId = 3;
END
ELSE
BEGIN
    SET IDENTITY_INSERT Customers ON;
    INSERT INTO Customers (CustomerId, CustomerName, CustomerAddress, AccountNumber) 
    VALUES (3, 'Uzmna Badhusha', 'No. 88, Matara Road, Galle', 'NWS-10003');
    SET IDENTITY_INSERT Customers OFF;
END

-- Update or insert WaterBill 101
IF EXISTS (SELECT 1 FROM WaterBills WHERE BillId = 101)
BEGIN
    UPDATE WaterBills 
    SET CustomerId = 1, AccountNumber = 'NWS-10001', Amount = 2450.50, DueDate = '2026-10-31', Status = 'Pending' 
    WHERE BillId = 101;
END
ELSE
BEGIN
    SET IDENTITY_INSERT WaterBills ON;
    INSERT INTO WaterBills (BillId, AccountNumber, CustomerId, Amount, DueDate, Status) 
    VALUES (101, 'NWS-10001', 1, 2450.50, '2026-10-31', 'Pending');
    SET IDENTITY_INSERT WaterBills OFF;
END

-- Update or insert WaterBill 102
IF EXISTS (SELECT 1 FROM WaterBills WHERE BillId = 102)
BEGIN
    UPDATE WaterBills 
    SET CustomerId = 2, AccountNumber = 'NWS-10002', Amount = 1875.00, DueDate = '2026-10-25', Status = 'Pending' 
    WHERE BillId = 102;
END
ELSE
BEGIN
    SET IDENTITY_INSERT WaterBills ON;
    INSERT INTO WaterBills (BillId, AccountNumber, CustomerId, Amount, DueDate, Status) 
    VALUES (102, 'NWS-10002', 2, 1875.00, '2026-10-25', 'Pending');
    SET IDENTITY_INSERT WaterBills OFF;
END

-- Update or insert WaterBill 103
IF EXISTS (SELECT 1 FROM WaterBills WHERE BillId = 103)
BEGIN
    UPDATE WaterBills 
    SET CustomerId = 3, AccountNumber = 'NWS-10003', Amount = 3200.75, DueDate = '2026-11-05', Status = 'Pending' 
    WHERE BillId = 103;
END
ELSE
BEGIN
    SET IDENTITY_INSERT WaterBills ON;
    INSERT INTO WaterBills (BillId, AccountNumber, CustomerId, Amount, DueDate, Status) 
    VALUES (103, 'NWS-10003', 3, 3200.75, '2026-11-05', 'Pending');
    SET IDENTITY_INSERT WaterBills OFF;
END
GO

