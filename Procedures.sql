CREATE PROCEDURE MakeReservation
    @GuestID BIGINT,
    @CheckIn DATE,
    @CheckOut DATE,
    @Meals NVARCHAR(100),
    @BookingDate DATE,
    @RoomNumber INT,
    @BranchID INT,
    @Price DECIMAL
AS
BEGIN
    SET NOCOUNT ON;

    -- Step 1: Insert into Reservation
    INSERT INTO Reservation (GuestID, Check_In, Check_Out, Meals, BookingDate, Price)
    VALUES (@GuestID, @CheckIn, @CheckOut, @Meals, @BookingDate, @Price);

    -- Get the new Reservation ID
    DECLARE @ReservationID INT = SCOPE_IDENTITY();

    -- Step 2: Insert into Room_Reserve
    INSERT INTO Room_Reserve (ReservationIDRR, Room_NumberRR, BranchIDRR)
    VALUES (@ReservationID, @RoomNumber, @BranchID);

    -- Step 3: Mark Room as Occupied (do NOT change Resident_No!)
    UPDATE Room
    SET Occupied = 1
    WHERE Room_Number = @RoomNumber AND Branch_ID = @BranchID;

    -- Step 4: Insert Payment
    INSERT INTO Payment (ReservationIDP, Payment_Date, Price)
    VALUES (@ReservationID, @BookingDate, @Price);
END;
GO

CREATE TYPE dbo.RoomListType AS TABLE
(
    RoomNumber INT      NOT NULL,
    BranchID   INT      NOT NULL
);
GO
ALTER PROCEDURE MakeReservation
    @GuestID     BIGINT,
    @CheckIn     DATE,
    @CheckOut    DATE,
    @Meals       NVARCHAR(100),
    @BookingDate DATE,
    @Rooms       dbo.RoomListType READONLY,   -- ← your list of (RoomNumber,BranchID)
    @Price       DECIMAL
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) Create the Reservation
    INSERT INTO Reservation (GuestID, Check_In, Check_Out, Meals, BookingDate, Price)
    VALUES (@GuestID, @CheckIn, @CheckOut, @Meals, @BookingDate, @Price);

    DECLARE @ReservationID INT = SCOPE_IDENTITY();

    -- 2) Bulk‐insert into Room_Reserve
    INSERT INTO Room_Reserve (ReservationIDRR, Room_NumberRR, BranchIDRR)
    SELECT @ReservationID, RoomNumber, BranchID
      FROM @Rooms;

    -- 3) Mark all those rooms occupied
    UPDATE R
    SET R.Occupied = 1
    FROM Room AS R
    JOIN @Rooms AS RL
      ON R.Room_Number = RL.RoomNumber
     AND R.Branch_ID   = RL.BranchID;

    -- 4) Record payment (same single payment record)
    INSERT INTO Payment (ReservationIDP, Payment_Date, Price)
    VALUES (@ReservationID, @BookingDate, @Price);
END;
GO
