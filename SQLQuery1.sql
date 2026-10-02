UPDATE Customers SET CustomerName = 'Bilal waseem', CustomerAddress = 'No. 45, Galle Road, Colombo 03', AccountNumber = 'NWSDB-COL-1001' WHERE CustomerId = 1;
UPDATE WaterBills SET AccountNumber = 'NWSDB-COL-1001', Status = 'Pending' WHERE BillId = 101;

UPDATE Customers SET CustomerName = 'Hana Hilmy', CustomerAddress = 'No. 12, Peradeniya Road, Kandy', AccountNumber = 'NWSDB-KDY-1002' WHERE CustomerId = 2;
UPDATE WaterBills SET AccountNumber = 'NWSDB-KDY-1002', Status = 'Pending' WHERE BillId = 102;

UPDATE Customers SET CustomerName = 'Ajmal Rizwan', CustomerAddress = 'No. 88, Matara Road, Galle', AccountNumber = 'NWSDB-GAL-1003' WHERE CustomerId = 3;
UPDATE WaterBills SET AccountNumber = 'NWSDB-GAL-1003', Status = 'Paid' WHERE BillId = 103;

IF NOT EXISTS (SELECT 1 FROM Customers WHERE AccountNumber = 'NWSDB-KDY-1001')
BEGIN
    SET IDENTITY_INSERT Customers ON;
    INSERT INTO Customers (CustomerId, CustomerName, CustomerAddress, AccountNumber) VALUES (4, 'Yumna Faris', 'No. 6, Aruppola, Kandy', 'NWSDB-KDY-1001');
    SET IDENTITY_INSERT Customers OFF;
END

IF NOT EXISTS (SELECT 1 FROM WaterBills WHERE AccountNumber = 'NWSDB-KDY-1001')
BEGIN
    SET IDENTITY_INSERT WaterBills ON;
    INSERT INTO WaterBills (BillId, AccountNumber, CustomerId, Amount, DueDate, Status) VALUES (104, 'NWSDB-KDY-1001', 4, 3450.00, '2026-09-30', 'Paid');
    SET IDENTITY_INSERT WaterBills OFF;
END

IF NOT EXISTS (SELECT 1 FROM Customers WHERE AccountNumber = 'NWSDB-BAD-1003')
BEGIN
    SET IDENTITY_INSERT Customers ON;
    INSERT INTO Customers (CustomerId, CustomerName, CustomerAddress, AccountNumber) VALUES (5, 'Uzman Badhussha', 'No. 88, Badulla', 'NWSDB-BAD-1003');
    SET IDENTITY_INSERT Customers OFF;
END

IF NOT EXISTS (SELECT 1 FROM WaterBills WHERE AccountNumber = 'NWSDB-BAD-1003')
BEGIN
    SET IDENTITY_INSERT WaterBills ON;
    INSERT INTO WaterBills (BillId, AccountNumber, CustomerId, Amount, DueDate, Status) VALUES (105, 'NWSDB-BAD-1003', 5, 4200.00, '2026-10-05', 'Paid');
    SET IDENTITY_INSERT WaterBills OFF;
END
GO

