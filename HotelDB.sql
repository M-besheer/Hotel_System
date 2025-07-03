Use HotelD

CREATE TABLE Branch (
    BranchID INT PRIMARY KEY,
    Location NVARCHAR(255),
    Room_Count INT,
);

-- Create Guest table
CREATE TABLE Guest (
    GuestID bigINT PRIMARY KEY,
    First_Name NVARCHAR(50),
    Last_Name NVARCHAR(50),
    Email NVARCHAR(100),
    Phone_Number NVARCHAR(20),
    Street_Name NVARCHAR(100),
    Flat_No NVARCHAR(10),
    City NVARCHAR(50),
    GFloor NVARCHAR(10)
);

-- Create Staff table
CREATE TABLE Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    First_Name NVARCHAR(50),
    Last_Name NVARCHAR(50),
    Email NVARCHAR(100),
    Phone_Number NVARCHAR(20),
    StaffRole NVARCHAR(50),
    Street_Name NVARCHAR(100),
    Flat_No NVARCHAR(10),
    City NVARCHAR(50),
    SFloor NVARCHAR(10),
    BranchID INT,
	Manager_ID INT,
	Job_Status NVARCHAR(20),
    FOREIGN KEY (BranchID) REFERENCES Branch(BranchID)
);

-- Create Room table
CREATE TABLE Room (
    Room_Number INT PRIMARY KEY,
    Branch_ID INT,
    Price_Per_Night DECIMAL,
    Occupied BIT DEFAULT 0,
    RoomView NVARCHAR(50),
    Room_Type NVARCHAR(50),
    Resident_No INT,
    FOREIGN KEY (Branch_ID) REFERENCES Branch(BranchID)
);

-- Create Reservation table
CREATE TABLE Reservation (
    ReservationID INT IDENTITY(1,1)  PRIMARY KEY,
    GuestID bigINT,
    Check_In DATE,
    Check_Out DATE,
    Meals NVARCHAR(100) ,
    BookingDate DATE,
    Price DECIMAL,
    FOREIGN KEY (GuestID) REFERENCES Guest(GuestID)
);

-- Create Room-Reserve table
CREATE TABLE Room_Reserve (
    ReservationIDRR INT,
    Room_NumberRR INT,
    BranchIDRR INT,
    PRIMARY KEY (ReservationIDRR, Room_NumberRR),
    FOREIGN KEY (ReservationIDRR) REFERENCES Reservation(ReservationID),
    FOREIGN KEY (Room_NumberRR) REFERENCES Room(Room_Number),
    FOREIGN KEY (BranchIDRR) REFERENCES Branch(BranchID)
);

-- Create Payment table
CREATE TABLE Payment (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    ReservationIDP INT,
    Payment_Date DATE,
    Price DECIMAL,
    FOREIGN KEY (ReservationIDP) REFERENCES Reservation(ReservationID)
);

-----------------------------------------------------------------------------------------------------------------
--											-------INSERTIONS-------
-----------------------------------------------------------------------------------------------------------------

INSERT INTO Branch (BranchID, Location, Room_Count)
VALUES
(1, 'Downtown', 15),
(2, 'Seaside', 15),
(3, 'Mountain View', 15),
(4, 'Lakeside', 15),
(5, 'City Center', 15);
-- ========================
-- Guests for Branch 1 (Downtown)
-- ========================
INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
VALUES
-- Egyptian IDs starting with 2 (born in 1900s)
(3050126, 'Ahmed', 'Mohamed', 'ahmed.mohamed@example.com', '01001234567', 'Nile Corniche', '12A', 'Cairo', 'Third'),
(2990521, 'Fatma', 'Ali', 'fatma.ali@example.com', '01112345678', 'Tahrir Square', '5B', 'Cairo', 'Second'),
(2971115, 'Mahmoud', 'Hassan', 'mahmoud.hassan@example.com', '01223456789', 'Garden City', '8C', 'Cairo', 'First'),
(2950823, 'Aya', 'Ibrahim', 'aya.ibrahim@example.com', '01534567890', 'Zamalek', '3D', 'Cairo', 'Ground'),
(2901228, 'Omar', 'Khalid', 'omar.khalid@example.com', '01045678901', 'Dokki', '10E', 'Giza', 'Third'),

-- Egyptian IDs starting with 3 (born in 2000s)
(3010521, 'Mariam', 'Samy', 'mariam.samy@example.com', '01156789012', 'Maadi', '7F', 'Cairo', 'Second'),
(3020813, 'Youssef', 'Adel', 'youssef.adel@example.com', '01267890123', 'Heliopolis', '9G', 'Cairo', 'First'),
(3031122, 'Nour', 'Wael', 'nour.wael@example.com', '01578901234', 'Nasr City', '2H', 'Cairo', 'Ground'),
(3040215, 'Karim', 'Tarek', 'karim.tarek@example.com', '01089012345', '6th October', '11I', 'Giza', 'Third'),
(3051003, 'Hana', 'Sherif', 'hana.sherif@example.com', '01190123456', 'New Cairo', '4J', 'Cairo', 'Second'),

-- Additional guests
(2960309, 'Ramy', 'Fawzy', 'ramy.fawzy@example.com', '01201234567', 'Agouza', '6K', 'Giza', 'First'),
(2980715, 'Dalia', 'Nasser', 'dalia.nasser@example.com', '01512345678', 'Mohandessin', '1L', 'Giza', 'Ground'),
(3000912, 'Khaled', 'Farouk', 'khaled.farouk@example.com', '01023456789', 'Harram', '12M', 'Giza', 'Third'),
(2991215, 'Salma', 'Rashad', 'salma.rashad@example.com', '01134567890', 'Sheikh Zayed', '5N', '6th October', 'Second'),
(3010403, 'Amir', 'Hamdy', 'amir.hamdy@example.com', '01245678901', 'Rehab', '8O', 'Cairo', 'First');

-- Rooms for Branch 1
INSERT INTO Room (Room_Number, Branch_ID, Price_Per_Night, Occupied, RoomView, Room_Type, Resident_No)
VALUES
(101, 1, 120.00, 1, 'City View', 'Standard', 1),
(102, 1, 120.00, 1, 'City View', 'Standard', 2),
(103, 1, 150.00, 1, 'City View', 'Deluxe', 5),
(104, 1, 150.00, 1, 'Garden View', 'Deluxe', 4),
(105, 1, 120.00, 1, 'City View', 'Standard', 6),
(106, 1, 180.00, 1, 'City View', 'Suite', 6),
(107, 1, 120.00, 1, 'Garden View', 'Standard', 3),
(108, 1, 150.00, 1, 'City View', 'Deluxe', 3),
(109, 1, 150.00, 1, 'Garden View', 'Deluxe', 4),
(110, 1, 180.00, 1, 'City View', 'Suite', 5),
(111, 1, 120.00, 0, 'Garden View', 'Standard', 2),
(112, 1, 150.00, 0, 'City View', 'Deluxe', 3),
(113, 1, 180.00, 0, 'Garden View', 'Suite', 2),
(114, 1, 200.00, 0, 'Panoramic View', 'Premium', 5),
(115, 1, 120.00, 0, 'City View', 'Standard', 4);

-- ========================
-- Guests for Branch 2 (Seaside)
-- ========================
INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
VALUES
(2980613, 'Laila', 'Hussein', 'laila.hussein@example.com', '01011223344', 'Beach Road', '15A', 'Alexandria', 'Ground'),
(2970922, 'Tamer', 'Ashraf', 'tamer.ashraf@example.com', '01122334455', 'San Stefano', '7B', 'Alexandria', 'First'),
(3000315, 'Yasmin', 'Magdy', 'yasmin.magdy@example.com', '01233445566', 'Miami', '3C', 'Alexandria', 'Second'),
(3020510, 'Hassan', 'Raouf', 'hassan.raouf@example.com', '01544556677', 'Stanley', '9D', 'Alexandria', 'Third'),
(2951115, 'Nadia', 'Fathi', 'nadia.fathi@example.com', '01055667788', 'Sidi Gaber', '12E', 'Alexandria', 'Ground'),

(3010722, 'Karim', 'Bassem', 'karim.bassem@example.com', '01166778899', 'Gleem', '5F', 'Alexandria', 'First'),
(3031015, 'Farida', 'Hany', 'farida.hany@example.com', '01277889900', 'Roushdy', '8G', 'Alexandria', 'Second'),
(2991209, 'Adel', 'Mounir', 'adel.mounir@example.com', '01588990011', 'Louran', '2H', 'Alexandria', 'Third'),
(3040222, 'Dina', 'Osman', 'dina.osman@example.com', '01099001122', 'Mandara', '10I', 'Alexandria', 'Ground'),
(2960801, 'Samir', 'Zaki', 'samir.zaki@example.com', '01100112233', 'Victoria', '4J', 'Alexandria', 'First'),

(3000915, 'Hala', 'Kamal', 'hala.kamal@example.com', '01211223344', 'Saba Pasha', '6K', 'Alexandria', 'Second'),
(3021103, 'Waleed', 'Nagy', 'waleed.nagy@example.com', '01522334455', 'Bolkly', '1L', 'Alexandria', 'Third'),
(2970207, 'Mona', 'Said', 'mona.said@example.com', '01033445566', 'Camp Caesar', '11M', 'Alexandria', 'Ground'),
(2990415, 'Ihab', 'Lotfy', 'ihab.lotfy@example.com', '01144556677', 'Smouha', '7N', 'Alexandria', 'First'),
(3010609, 'Rania', 'Adel', 'rania.adel@example.com', '01255667788', 'Kafr Abdo', '3O', 'Alexandria', 'Second');

-- Updated Rooms for Branch 2 with Resident_No from 1 to 6 for all rooms
INSERT INTO Room (Room_Number, Branch_ID, Price_Per_Night, Occupied, RoomView, Room_Type, Resident_No)
VALUES
(201, 2, 150.00, 1, 'Ocean View', 'Standard', 2),
(202, 2, 150.00, 1, 'Ocean View', 'Standard', 1),
(203, 2, 180.00, 1, 'Ocean View', 'Deluxe', 3),
(204, 2, 180.00, 1, 'Pool View', 'Deluxe', 2),
(205, 2, 150.00, 1, 'Ocean View', 'Standard', 4),
(206, 2, 220.00, 1, 'Ocean View', 'Suite', 6),
(207, 2, 150.00, 1, 'Pool View', 'Standard', 2),
(208, 2, 180.00, 1, 'Ocean View', 'Deluxe', 3),
(209, 2, 180.00, 1, 'Pool View', 'Deluxe', 1),
(210, 2, 220.00, 1, 'Ocean View', 'Suite', 5),
(211, 2, 150.00, 1, 'Pool View', 'Standard', 2),
(212, 2, 180.00, 1, 'Ocean View', 'Deluxe', 4),
(213, 2, 220.00, 1, 'Pool View', 'Suite', 6),
(214, 2, 250.00, 1, 'Panoramic Ocean View', 'Premium', 3),
(215, 2, 150.00, 1, 'Ocean View', 'Standard', 1);
-- ========================
-- Guests for Branch 3 (Mountain View)
-- ========================
INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
VALUES
(2970512, 'Sherif', 'Gamal', 'sherif.gamal@example.com', '01011224455', 'St. Catherine', '14A', 'Sharm El Sheikh', 'Ground'),
(2990623, 'Nermin', 'Reda', 'nermin.reda@example.com', '01122335566', 'Naama Bay', '6B', 'Sharm El Sheikh', 'First'),
(3010715, 'Bassem', 'Wael', 'bassem.wael@example.com', '01233446677', 'Hadaba', '2C', 'Sharm El Sheikh', 'Second'),
(3030822, 'Lobna', 'Sherif', 'lobna.sherif@example.com', '01544557788', 'Nabq Bay', '10D', 'Sharm El Sheikh', 'Third'),
(2950915, 'Hany', 'Fouad', 'hany.fouad@example.com', '01055668899', 'Ras Um Sid', '13E', 'Sharm El Sheikh', 'Ground'),

(3001022, 'Dalia', 'Hatem', 'dalia.hatem@example.com', '01166779900', 'Sharks Bay', '5F', 'Sharm El Sheikh', 'First'),
(3021115, 'Amgad', 'Samir', 'amgad.samir@example.com', '01277880011', 'Montaza', '9G', 'Sharm El Sheikh', 'Second'),
(2981209, 'Heba', 'Adel', 'heba.adel@example.com', '01588991122', 'Peace Road', '1H', 'Sharm El Sheikh', 'Third'),
(3040215, 'Osama', 'Karim', 'osama.karim@example.com', '01099002233', 'El Fanar', '11I', 'Sharm El Sheikh', 'Ground'),
(2960301, 'Soha', 'Nader', 'soha.nader@example.com', '01100113344', 'El Salam', '4J', 'Sharm El Sheikh', 'First'),

(3010405, 'Tarek', 'Hisham', 'tarek.hisham@example.com', '01211224455', 'El Pasha', '7K', 'Sharm El Sheikh', 'Second'),
(3030503, 'Mireille', 'Fouad', 'mireille.fouad@example.com', '01522335566', 'Il Mercato', '2L', 'Sharm El Sheikh', 'Third'),
(2970607, 'Hussein', 'Sami', 'hussein.sami@example.com', '01033446677', 'Soho Square', '12M', 'Sharm El Sheikh', 'Ground'),
(2990715, 'Dina', 'Hassan', 'dina.hassan@example.com', '01144557788', 'Old Market', '8N', 'Sharm El Sheikh', 'First'),
(3010809, 'Ayman', 'Ramy', 'ayman.ramy@example.com', '01255668899', 'Hai En Nur', '3O', 'Sharm El Sheikh', 'Second');
-- Updated Rooms for Branch 3 with Resident_No from 1 to 6 for all rooms
INSERT INTO Room (Room_Number, Branch_ID, Price_Per_Night, Occupied, RoomView, Room_Type, Resident_No)
VALUES
(301, 3, 130.00, 1, 'Mountain View', 'Standard', 2),
(302, 3, 130.00, 1, 'Mountain View', 'Standard', 1),
(303, 3, 160.00, 1, 'Mountain View', 'Deluxe', 3),
(304, 3, 160.00, 1, 'Garden View', 'Deluxe', 2),
(305, 3, 130.00, 1, 'Mountain View', 'Standard', 4),
(306, 3, 200.00, 1, 'Mountain View', 'Suite', 6),
(307, 3, 130.00, 1, 'Garden View', 'Standard', 2),
(308, 3, 160.00, 1, 'Mountain View', 'Deluxe', 3),
(309, 3, 160.00, 1, 'Garden View', 'Deluxe', 1),
(310, 3, 200.00, 1, 'Mountain View', 'Suite', 5),
(311, 3, 130.00, 1, 'Garden View', 'Standard', 2),
(312, 3, 160.00, 1, 'Mountain View', 'Deluxe', 4),
(313, 3, 200.00, 1, 'Garden View', 'Suite', 6),
(314, 3, 230.00, 1, 'Panoramic Mountain View', 'Premium', 3),
(315, 3, 130.00, 1, 'Mountain View', 'Standard', 1);

-- ========================
-- Guests for Branch 4 (Lakeside)
-- ========================
INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
VALUES
(2960418, 'Nader', 'Fawzy', 'nader.fawzy@example.com', '01011225566', 'Lake View', '16A', 'Fayoum', 'Ground'),
(2980528, 'Samia', 'Adel', 'samia.adel@example.com', '01122336677', 'Palm Street', '8B', 'Fayoum', 'First'),
(3000618, 'Fares', 'Hussein', 'fares.hussein@example.com', '01233447788', 'Oasis Road', '4C', 'Fayoum', 'Second'),
(3020728, 'Hoda', 'Magdy', 'hoda.magdy@example.com', '01544558899', 'Waterfall', '12D', 'Fayoum', 'Third'),
(2940818, 'Kamal', 'Nasser', 'kamal.nasser@example.com', '01055669900', 'Bird Street', '15E', 'Fayoum', 'Ground'),

(3010928, 'Mai', 'Sherif', 'mai.sherif@example.com', '01166770011', 'Tunis Village', '7F', 'Fayoum', 'First'),
(3031018, 'Ashraf', 'Samir', 'ashraf.samir@example.com', '01277881122', 'Qarun Lake', '11G', 'Fayoum', 'Second'),
(2971108, 'Nagwa', 'Hany', 'nagwa.hany@example.com', '01588992233', 'Wadi El Rayan', '3H', 'Fayoum', 'Third'),
(3040215, 'Hossam', 'Karim', 'hossam.karim@example.com', '01099003344', 'Magic Lake', '13I', 'Fayoum', 'Ground'),
(2950301, 'Inas', 'Fathi', 'inas.fathi@example.com', '01100114455', 'Fayoum Desert', '6J', 'Fayoum', 'First'),

(3000405, 'Raafat', 'Hamed', 'raafat.hamed@example.com', '01211225566', 'Mudawara', '9K', 'Fayoum', 'Second'),
(3020503, 'Sahar', 'Lotfy', 'sahar.lotfy@example.com', '01522336677', 'Kom Oshim', '2L', 'Fayoum', 'Third'),
(2960607, 'Ehab', 'Salah', 'ehab.salah@example.com', '01033447788', 'Sanhour', '14M', 'Fayoum', 'Ground'),
(2980715, 'Hanan', 'Mounir', 'hanan.mounir@example.com', '01144558899', 'Ibsheway', '10N', 'Fayoum', 'First'),
(3000809, 'Galal', 'Ragab', 'galal.ragab@example.com', '01255669900', 'Tamiya', '5O', 'Fayoum', 'Second');
-- Updated Rooms for Branch 4 with Resident_No from 1 to 6 for all rooms
INSERT INTO Room (Room_Number, Branch_ID, Price_Per_Night, Occupied, RoomView, Room_Type, Resident_No)
VALUES
(401, 4, 140.00, 1, 'Lake View', 'Standard', 2),
(402, 4, 140.00, 1, 'Lake View', 'Standard', 1),
(403, 4, 170.00, 1, 'Lake View', 'Deluxe', 3),
(404, 4, 170.00, 1, 'Garden View', 'Deluxe', 2),
(405, 4, 140.00, 1, 'Lake View', 'Standard', 4),
(406, 4, 210.00, 1, 'Lake View', 'Suite', 6),
(407, 4, 140.00, 1, 'Garden View', 'Standard', 2),
(408, 4, 170.00, 1, 'Lake View', 'Deluxe', 3),
(409, 4, 170.00, 1, 'Garden View', 'Deluxe', 1),
(410, 4, 210.00, 1, 'Lake View', 'Suite', 5),
(411, 4, 140.00, 1, 'Garden View', 'Standard', 2),
(412, 4, 170.00, 1, 'Lake View', 'Deluxe', 4),
(413, 4, 210.00, 1, 'Garden View', 'Suite', 6),
(414, 4, 240.00, 1, 'Panoramic Lake View', 'Premium', 3),
(415, 4, 140.00, 1, 'Lake View', 'Standard', 1);
-- ========================
-- Guests for Branch 5 (City Center)
-- ========================
INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
VALUES
(2970312, 'Wael', 'Nabil', 'wael.nabil@example.com', '01011226677', 'Kasr El Nil', '18A', 'Cairo', 'Ground'),
(2990423, 'Heba', 'Fouad', 'heba.fouad@example.com', '01122337788', 'Talaat Harb', '10B', 'Cairo', 'First'),
(3010515, 'Atef', 'Hamed', 'atef.hamed@example.com', '01233448899', 'Ramses', '6C', 'Cairo', 'Second'),
(3030622, 'Mona', 'Samir', 'mona.samir@example.com', '01544559900', 'Abdeen', '14D', 'Cairo', 'Third'),
(2950715, 'Samir', 'Adel', 'samir.adel@example.com', '01055660011', 'Giza Square', '17E', 'Giza', 'Ground'),

(3000822, 'Noha', 'Hisham', 'noha.hisham@example.com', '01166771122', 'Faisal', '9F', 'Giza', 'First'),
(3020915, 'Hisham', 'Kamal', 'hisham.kamal@example.com', '01277882233', 'Haram', '13G', 'Giza', 'Second'),
(2981009, 'Faten', 'Raafat', 'faten.raafat@example.com', '01588993344', 'Dokki', '5H', 'Giza', 'Third'),
(3040115, 'Karim', 'Hassan', 'karim.hassan@example.com', '01099004455', 'Mohandessin', '15I', 'Giza', 'Ground'),
(2960201, 'Lamis', 'Nagy', 'lamis.nagy@example.com', '01100115566', 'Agouza', '8J', 'Giza', 'First'),

(3010305, 'Hazem', 'Osama', 'hazem.osama@example.com', '01211226677', 'Manial', '11K', 'Cairo', 'Second'),
(3030403, 'Dalia', 'Hussein', 'dalia.hussein@example.com', '01522337788', 'Zamalek', '4L', 'Cairo', 'Third'),
(2970507, 'Amal', 'Sayed', 'amal.sayed@example.com', '01033448899', 'Heliopolis', '16M', 'Cairo', 'Ground'),
(2990615, 'Tamer', 'Wael', 'tamer.wael@example.com', '01144559900', 'Nasr City', '12N', 'Cairo', 'First'),
(3010709, 'Yara', 'Hany', 'yara.hany@example.com', '01255660011', 'Maadi', '7O', 'Cairo', 'Second');
-- Updated Rooms for Branch 5 with Resident_No from 1 to 6 for all rooms
INSERT INTO Room (Room_Number, Branch_ID, Price_Per_Night, Occupied, RoomView, Room_Type, Resident_No)
VALUES
(501, 5, 160.00, 1, 'City View', 'Standard', 2),
(502, 5, 160.00, 1, 'City View', 'Standard', 1),
(503, 5, 190.00, 1, 'City View', 'Deluxe', 3),
(504, 5, 190.00, 1, 'Garden View', 'Deluxe', 2),
(505, 5, 160.00, 1, 'City View', 'Standard', 4),
(506, 5, 230.00, 1, 'City View', 'Suite', 6),
(507, 5, 160.00, 1, 'Garden View', 'Standard', 2),
(508, 5, 190.00, 1, 'City View', 'Deluxe', 3),
(509, 5, 190.00, 1, 'Garden View', 'Deluxe', 1),
(510, 5, 230.00, 1, 'City View', 'Suite', 5),
(511, 5, 160.00, 1, 'Garden View', 'Standard', 2),
(512, 5, 190.00, 1, 'City View', 'Deluxe', 4),
(513, 5, 230.00, 1, 'Garden View', 'Suite', 6),
(514, 5, 260.00, 1, 'Panoramic City View', 'Premium', 3),
(515, 5, 160.00, 1, 'City View', 'Standard', 1);

-- ========================
-- Reservations for all branches
-- ========================

-- Branch 1 Reservations
INSERT INTO Reservation (GuestID, Check_In, Check_Out, Meals, BookingDate, Price)
VALUES
(3050126, '2025-06-01', '2025-06-05', 'Breakfast', '2025-05-20', 480.00),
(2990521, '2025-06-10', '2025-06-15', 'Half Board', '2025-05-22', 750.00),
(2971115, '2025-06-15', '2025-06-20', 'Full Board', '2025-05-25', 900.00),
(2950823, '2025-06-18', '2025-06-25', 'Breakfast & Dinner', '2025-05-27', 1050.00),
(2901228, '2025-06-22', '2025-06-30', 'Breakfast', '2025-05-30', 960.00),
(3010521, '2025-07-01', '2025-07-07', 'Half Board', '2025-06-10', 1260.00),
(3020813, '2025-07-05', '2025-07-10', 'Full Board', '2025-06-15', 1125.00),
(3031122, '2025-07-10', '2025-07-15', 'Breakfast', '2025-06-20', 600.00),
(3040215, '2025-07-15', '2025-07-20', 'Half Board', '2025-06-25', 825.00),
(3051003, '2025-07-20', '2025-07-25', 'Full Board', '2025-06-30', 1125.00),
(2960309, '2025-08-01', '2025-08-05', 'Breakfast', '2025-07-10', 480.00),
(2980715, '2025-08-10', '2025-08-15', 'Half Board', '2025-07-20', 825.00),
(3000912, '2025-08-15', '2025-08-20', 'Full Board', '2025-07-25', 900.00),
(2991215, '2025-08-18', '2025-08-25', 'Breakfast & Dinner', '2025-07-27', 1225.00),
(3010403, '2025-08-22', '2025-08-30', 'Breakfast', '2025-07-30', 960.00);

-- Branch 2 Reservations
INSERT INTO Reservation (GuestID, Check_In, Check_Out, Meals, BookingDate, Price)
VALUES
(2980613, '2025-06-01', '2025-06-05', 'Breakfast', '2025-05-20', 600.00),
(2970922, '2025-06-10', '2025-06-15', 'Half Board', '2025-05-22', 975.00),
(3000315, '2025-06-15', '2025-06-20', 'Full Board', '2025-05-25', 1200.00),
(3020510, '2025-06-18', '2025-06-25', 'Breakfast & Dinner', '2025-05-27', 1400.00),
(2951115, '2025-06-22', '2025-06-30', 'Breakfast', '2025-05-30', 1200.00),
(3010722, '2025-07-01', '2025-07-07', 'Half Board', '2025-06-10', 1680.00),
(3031015, '2025-07-05', '2025-07-10', 'Full Board', '2025-06-15', 1500.00),
(2991209, '2025-07-10', '2025-07-15', 'Breakfast', '2025-06-20', 750.00),
(3040222, '2025-07-15', '2025-07-20', 'Half Board', '2025-06-25', 1100.00),
(2960801, '2025-07-20', '2025-07-25', 'Full Board', '2025-06-30', 1500.00),
(3000915, '2025-08-01', '2025-08-05', 'Breakfast', '2025-07-10', 600.00),
(3021103, '2025-08-10', '2025-08-15', 'Half Board', '2025-07-20', 1100.00),
(2970207, '2025-08-15', '2025-08-20', 'Full Board', '2025-07-25', 1200.00),
(2990415, '2025-08-18', '2025-08-25', 'Breakfast & Dinner', '2025-07-27', 1750.00),
(3010609, '2025-08-22', '2025-08-30', 'Breakfast', '2025-07-30', 1200.00);

-- Branch 3 Reservations
INSERT INTO Reservation (GuestID, Check_In, Check_Out, Meals, BookingDate, Price)
VALUES
(2970512, '2025-06-01', '2025-06-05', 'Breakfast', '2025-05-20', 520.00),
(2990623, '2025-06-10', '2025-06-15', 'Half Board', '2025-05-22', 845.00),
(3010715, '2025-06-15', '2025-06-20', 'Full Board', '2025-05-25', 1040.00),
(3030822, '2025-06-18', '2025-06-25', 'Breakfast & Dinner', '2025-05-27', 1190.00),
(2950915, '2025-06-22', '2025-06-30', 'Breakfast', '2025-05-30', 1040.00),
(3001022, '2025-07-01', '2025-07-07', 'Half Board', '2025-06-10', 1456.00),
(3021115, '2025-07-05', '2025-07-10', 'Full Board', '2025-06-15', 1300.00),
(2981209, '2025-07-10', '2025-07-15', 'Breakfast', '2025-06-20', 650.00),
(3040215, '2025-07-15', '2025-07-20', 'Half Board', '2025-06-25', 975.00),
(2960301, '2025-07-20', '2025-07-25', 'Full Board', '2025-06-30', 1300.00),
(3010405, '2025-08-01', '2025-08-05', 'Breakfast', '2025-07-10', 520.00),
(3030503, '2025-08-10', '2025-08-15', 'Half Board', '2025-07-20', 975.00),
(2970607, '2025-08-15', '2025-08-20', 'Full Board', '2025-07-25', 1040.00),
(2990715, '2025-08-18', '2025-08-25', 'Breakfast & Dinner', '2025-07-27', 1470.00)


-- ========================
-- Staff for all branches
-- ========================

-- Branch 1 Staff (Downtown)
INSERT INTO Staff (First_Name, Last_Name, Email, Phone_Number, StaffRole, Street_Name, Flat_No, City, SFloor, BranchID, Manager_ID, Job_Status)
VALUES
('Mohamed', 'El-Sayed', 'mohamed.elsayed@hoteld.com', '01001112233', 'Manager', 'Corniche El Nil', '101', 'Cairo', 'Ground', 1, NULL, 'Active'),
('Amina', 'Farouk', 'amina.farouk@hoteld.com', '01112223344', 'Receptionist', 'Talaat Harb', '202', 'Cairo', 'First', 1, 1, 'Active'),
('Karim', 'Hassan', 'karim.hassan@hoteld.com', '01223334455', 'Housekeeping', 'Kasr El Nil', '303', 'Cairo', 'Second', 1, 1, 'Active'),
('Nadia', 'Ibrahim', 'nadia.ibrahim@hoteld.com', '01534445566', 'Concierge', 'Garden City', '404', 'Cairo', 'Third', 1, 1, 'Active'),
('Hany', 'Mahmoud', 'hany.mahmoud@hoteld.com', '01045556677', 'Chef', 'Dokki', '505', 'Giza', 'Ground', 1, 1, 'Active'),
('Samira', 'Nasser', 'samira.nasser@hoteld.com', '01156667788', 'Waiter', 'Agouza', '606', 'Giza', 'First', 1, 1, 'Active'),
('Adel', 'Osman', 'adel.osman@hoteld.com', '01267778899', 'Security', 'Mohandessin', '707', 'Giza', 'Second', 1, 1, 'Active'),
('Dalia', 'Rashad', 'dalia.rashad@hoteld.com', '01578889900', 'Housekeeping', 'Zamalek', '808', 'Cairo', 'Third', 1, 1, 'Active'),
('Faisal', 'Samir', 'faisal.samir@hoteld.com', '01089990011', 'Bellboy', 'Heliopolis', '909', 'Cairo', 'Ground', 1, 1, 'Active'),
('Hala', 'Tarek', 'hala.tarek@hoteld.com', '01190001122', 'Receptionist', 'Nasr City', '1010', 'Cairo', 'First', 1, 1, 'Active');

-- Branch 2 Staff (Seaside)
INSERT INTO Staff (First_Name, Last_Name, Email, Phone_Number, StaffRole, Street_Name, Flat_No, City, SFloor, BranchID, Manager_ID, Job_Status)
VALUES
('Youssef', 'Abdelrahman', 'youssef.abdelrahman@hoteld.com', '01002223344', 'Manager', 'San Stefano', '111', 'Alexandria', 'Ground', 2, NULL, 'Active'),
('Layla', 'Badr', 'layla.badr@hoteld.com', '01113334455', 'Receptionist', 'Stanley', '222', 'Alexandria', 'First', 2, 11, 'Active'),
('Omar', 'Clement', 'omar.clement@hoteld.com', '01224445566', 'Housekeeping', 'Sidi Gaber', '333', 'Alexandria', 'Second', 2, 11, 'Active'),
('Nermin', 'Dawood', 'nermin.dawood@hoteld.com', '01535556677', 'Concierge', 'Gleem', '444', 'Alexandria', 'Third', 2, 11, 'Active'),
('Ramy', 'Ezzat', 'ramy.ezzat@hoteld.com', '01046667788', 'Chef', 'Roushdy', '555', 'Alexandria', 'Ground', 2, 11, 'Active'),
('Salma', 'Fawzy', 'salma.fawzy@hoteld.com', '01157778899', 'Waiter', 'Louran', '666', 'Alexandria', 'First', 2, 11, 'Active'),
('Tarek', 'Gamal', 'tarek.gamal@hoteld.com', '01268889900', 'Security', 'Mandara', '777', 'Alexandria', 'Second', 2, 11, 'Active'),
('Wafaa', 'Hakim', 'wafaa.hakim@hoteld.com', '01579990011', 'Housekeeping', 'Victoria', '888', 'Alexandria', 'Third', 2, 11, 'Active'),
('Ziad', 'Ihab', 'ziad.ihab@hoteld.com', '01080001122', 'Bellboy', 'Saba Pasha', '999', 'Alexandria', 'Ground', 2, 11, 'Active'),
('Hanan', 'Joseph', 'hanan.joseph@hoteld.com', '01191112233', 'Receptionist', 'Bolkly', '1010', 'Alexandria', 'First', 2, 11, 'Active');

-- Branch 3 Staff (Mountain View)
INSERT INTO Staff (First_Name, Last_Name, Email, Phone_Number, StaffRole, Street_Name, Flat_No, City, SFloor, BranchID, Manager_ID, Job_Status)
VALUES
('Khaled', 'Kamal', 'khaled.kamal@hoteld.com', '01003334455', 'Manager', 'Naama Bay', '121', 'Sharm El Sheikh', 'Ground', 3, NULL, 'Active'),
('Inas', 'Lotfy', 'inas.lotfy@hoteld.com', '01114445566', 'Receptionist', 'Hadaba', '232', 'Sharm El Sheikh', 'First', 3, 21, 'Active'),
('Maged', 'Mounir', 'maged.mounir@hoteld.com', '01225556677', 'Housekeeping', 'Nabq Bay', '343', 'Sharm El Sheikh', 'Second', 3, 21, 'Active'),
('Noha', 'Nabil', 'noha.nabil@hoteld.com', '01536667788', 'Concierge', 'Ras Um Sid', '454', 'Sharm El Sheikh', 'Third', 3, 21, 'Active'),
('Osama', 'Omar', 'osama.omar@hoteld.com', '01047778899', 'Chef', 'Sharks Bay', '565', 'Sharm El Sheikh', 'Ground', 3, 21, 'Active'),
('Pakinam', 'Philip', 'pakinam.philip@hoteld.com', '01158889900', 'Waiter', 'Montaza', '676', 'Sharm El Sheikh', 'First', 3, 21, 'Active'),
('Qasim', 'Raouf', 'qasim.raouf@hoteld.com', '01269990011', 'Security', 'Peace Road', '787', 'Sharm El Sheikh', 'Second', 3, 21, 'Active'),
('Rasha', 'Samir', 'rasha.samir@hoteld.com', '01570001122', 'Housekeeping', 'El Fanar', '898', 'Sharm El Sheikh', 'Third', 3, 21, 'Active'),
('Said', 'Tamer', 'said.tamer@hoteld.com', '01081112233', 'Bellboy', 'El Salam', '909', 'Sharm El Sheikh', 'Ground', 3, 21, 'Active'),
('Tahani', 'Victor', 'tahani.victor@hoteld.com', '01192223344', 'Receptionist', 'El Pasha', '1010', 'Sharm El Sheikh', 'First', 3, 21, 'Active');

-- Branch 4 Staff (Lakeside)
INSERT INTO Staff (First_Name, Last_Name, Email, Phone_Number, StaffRole, Street_Name, Flat_No, City, SFloor, BranchID, Manager_ID, Job_Status)
VALUES
('Usama', 'Wael', 'usama.wael@hoteld.com', '01004445566', 'Manager', 'Lake View', '131', 'Fayoum', 'Ground', 4, NULL, 'Active'),
('Vivian', 'Xavier', 'vivian.xavier@hoteld.com', '01115556677', 'Receptionist', 'Palm Street', '242', 'Fayoum', 'First', 4, 31, 'Active'),
('Wael', 'Youssef', 'wael.youssef@hoteld.com', '01226667788', 'Housekeeping', 'Oasis Road', '353', 'Fayoum', 'Second', 4, 31, 'Active'),
('Xenia', 'Zaki', 'xenia.zaki@hoteld.com', '01537778899', 'Concierge', 'Waterfall', '464', 'Fayoum', 'Third', 4, 31, 'Active'),
('Yahia', 'Adel', 'yahia.adel@hoteld.com', '01048889900', 'Chef', 'Bird Street', '575', 'Fayoum', 'Ground', 4, 31, 'Active'),
('Zahra', 'Bassem', 'zahra.bassem@hoteld.com', '01159990011', 'Waiter', 'Tunis Village', '686', 'Fayoum', 'First', 4, 31, 'Active'),
('Amgad', 'Cherif', 'amgad.cherif@hoteld.com', '01260001122', 'Security', 'Qarun Lake', '797', 'Fayoum', 'Second', 4, 31, 'Active'),
('Bassant', 'Diaa', 'bassant.diaa@hoteld.com', '01571112233', 'Housekeeping', 'Wadi El Rayan', '808', 'Fayoum', 'Third', 4, 31, 'Active'),
('Cherif', 'Emad', 'cherif.emad@hoteld.com', '01082223344', 'Bellboy', 'Magic Lake', '919', 'Fayoum', 'Ground', 4, 31, 'Active'),
('Dina', 'Fouad', 'dina.fouad@hoteld.com', '01193334455', 'Receptionist', 'Fayoum Desert', '1020', 'Fayoum', 'First', 4, 31, 'Active');

-- Branch 5 Staff (City Center)
INSERT INTO Staff (First_Name, Last_Name, Email, Phone_Number, StaffRole, Street_Name, Flat_No, City, SFloor, BranchID, Manager_ID, Job_Status)
VALUES
('Emad', 'Gabr', 'emad.gabr@hoteld.com', '01005556677', 'Manager', 'Kasr El Nil', '141', 'Cairo', 'Ground', 5, NULL, 'Active'),
('Farida', 'Hamed', 'farida.hamed@hoteld.com', '01116667788', 'Receptionist', 'Talaat Harb', '252', 'Cairo', 'First', 5, 41, 'Active'),
('Gamal', 'Ihab', 'gamal.ihab@hoteld.com', '01227778899', 'Housekeeping', 'Ramses', '363', 'Cairo', 'Second', 5, 41, 'Active'),
('Heba', 'Jalal', 'heba.jalal@hoteld.com', '01538889900', 'Concierge', 'Abdeen', '474', 'Cairo', 'Third', 5, 41, 'Active'),
('Ihab', 'Kamel', 'ihab.kamel@hoteld.com', '01049990011', 'Chef', 'Giza Square', '585', 'Giza', 'Ground', 5, 41, 'Active'),
('Jihan', 'Labib', 'jihan.labib@hoteld.com', '01150001122', 'Waiter', 'Faisal', '696', 'Giza', 'First', 5, 41, 'Active'),
('Kareem', 'Maher', 'kareem.maher@hoteld.com', '01261112233', 'Security', 'Haram', '707', 'Giza', 'Second', 5, 41, 'Active'),
('Laila', 'Nader', 'laila.nader@hoteld.com', '01572223344', 'Housekeeping', 'Dokki', '818', 'Giza', 'Third', 5, 41, 'Active'),
('Mamdouh', 'Osman', 'mamdouh.osman@hoteld.com', '01083334455', 'Bellboy', 'Mohandessin', '929', 'Giza', 'Ground', 5, 41, 'Active'),
('Nadia', 'Peter', 'nadia.peter@hoteld.com', '01194445566', 'Receptionist', 'Agouza', '1030', 'Giza', 'First', 5, 41, 'Active');

-- ========================
-- Room_Reserve records (exactly matching reservations)
-- ========================

-- Branch 1 Room_Reserve
INSERT INTO Room_Reserve (ReservationIDRR, Room_NumberRR, BranchIDRR)
VALUES
(1, 101, 1),
(2, 102, 1),
(3, 103, 1),
(4, 104, 1),
(5, 105, 1),
(6, 106, 1),
(7, 107, 1),
(8, 108, 1),
(9, 109, 1),
(10, 110, 1),
(11, 101, 1),
(12, 102, 1),
(13, 103, 1),
(14, 104, 1),
(15, 105, 1);

-- Branch 2 Room_Reserve
INSERT INTO Room_Reserve (ReservationIDRR, Room_NumberRR, BranchIDRR)
VALUES
(16, 201, 2),
(17, 202, 2),
(18, 203, 2),
(19, 204, 2),
(20, 205, 2),
(21, 206, 2),
(22, 207, 2),
(23, 208, 2),
(24, 209, 2),
(25, 210, 2),
(26, 201, 2),
(27, 202, 2),
(28, 203, 2),
(29, 204, 2),
(30, 205, 2);

-- Branch 3 Room_Reserve
INSERT INTO Room_Reserve (ReservationIDRR, Room_NumberRR, BranchIDRR)
VALUES
(31, 301, 3),
(32, 302, 3),
(33, 303, 3),
(34, 304, 3),
(35, 305, 3),
(36, 306, 3),
(37, 307, 3),
(38, 308, 3),
(39, 309, 3),
(40, 310, 3),
(41, 301, 3),
(42, 302, 3),
(43, 303, 3),
(44, 304, 3),
(45, 305, 3);

-- Branch 4 Room_Reserve
INSERT INTO Room_Reserve (ReservationIDRR, Room_NumberRR, BranchIDRR)
VALUES
(46, 401, 4),
(47, 402, 4),
(48, 403, 4),
(49, 404, 4),
(50, 405, 4),
(51, 406, 4),
(52, 407, 4),
(53, 408, 4),
(54, 409, 4),
(55, 410, 4),
(56, 401, 4),
(57, 402, 4),
(58, 403, 4),
(59, 404, 4),
(60, 405, 4);

-- Branch 5 Room_Reserve
INSERT INTO Room_Reserve (ReservationIDRR, Room_NumberRR, BranchIDRR)
VALUES
(61, 501, 5),
(62, 502, 5),
(63, 503, 5),
(64, 504, 5),
(65, 505, 5),
(66, 506, 5),
(67, 507, 5),
(68, 508, 5),
(69, 509, 5),
(70, 510, 5),
(71, 501, 5),
(72, 502, 5),
(73, 503, 5),
(74, 504, 5),
(75, 505, 5);