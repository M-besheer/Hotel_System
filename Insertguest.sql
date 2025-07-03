
CREATE PROCEDURE InsertGuest
    @GuestID INT,
    @First_Name NVARCHAR(50),
    @Last_Name NVARCHAR(50),
    @Email NVARCHAR(100),
    @Phone_Number NVARCHAR(20),
    @Street_Name NVARCHAR(100),
    @Flat_No NVARCHAR(10),
    @City NVARCHAR(50),
    @GFloor NVARCHAR(10),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the GuestID already exists
    IF EXISTS (SELECT 1 FROM Guest WHERE GuestID = @GuestID)
    BEGIN
        SET @Result = 0; -- GuestID already exists
    END
    ELSE
    BEGIN
        -- Insert the new guest record
        INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
        VALUES (@GuestID, @First_Name, @Last_Name, @Email, @Phone_Number, @Street_Name, @Flat_No, @City, @GFloor);

        SET @Result = @GuestID; -- Return the GuestID
    END
END;

