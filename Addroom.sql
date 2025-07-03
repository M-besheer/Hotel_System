
CREATE PROCEDURE AddRoomAndUpdateBranchCount
    @Room_Number NVARCHAR(50),
    @Branch_ID INT,
    @Price_Per_Night DECIMAL(18, 2),
    @RoomView NVARCHAR(50),
    @Room_Type NVARCHAR(50),
    @Result BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insert the new room
        INSERT INTO Room (Room_Number, Branch_ID, Price_Per_Night, Occupied, RoomView, Room_Type)
        VALUES (@Room_Number, @Branch_ID, @Price_Per_Night, 0, @RoomView, @Room_Type);

        -- Update the room count for the specified branch
        UPDATE Branch
        SET Room_Count = Room_Count + 1
        WHERE BranchID = @Branch_ID;

        -- Commit the transaction
        COMMIT TRANSACTION;

        SET @Result = 1; -- Indicate success
    END TRY
    BEGIN CATCH
        -- Rollback the transaction in case of error
        ROLLBACK TRANSACTION;

        SET @Result = 0; -- Indicate failure
    END CATCH
END;
