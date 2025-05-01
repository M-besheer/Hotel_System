using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;



namespace Database_project
{


    public class DBHandler
    {
        private readonly string connectionString = @"Data Source=.;Initial Catalog=HotelD;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public bool GuestExists(int guestId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Guest WHERE GuestID = @GuestID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GuestID", guestId);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public DataTable SearchGuests(string partialId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Define the query
                string query = @"SELECT GuestID, First_Name, Last_Name 
                         FROM Guest
                         WHERE GuestID LIKE @partialId + '%'";

                // Create the command and add the parameter
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@partialId", partialId);

                // Open the connection
                conn.Open();

                // Execute the query and read the data
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Create a DataTable to hold the results
                    DataTable dt = new DataTable();

                    // Load the DataTable with the data from the SqlDataReader
                    dt.Load(reader);

                    return dt;
                }
            }
        }


        public int InsertGuest(int guestId, string firstName, string lastName, string email, string phoneNumber, string streetName, string flatNo, string city, string gFloor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM Guest WHERE GuestID = @GuestID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@GuestID", guestId);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    return 0;
                }
                else
                {
                    string insertQuery = @"
                INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
                VALUES (@GuestID, @First_Name, @Last_Name, @Email, @Phone_Number, @Street_Name, @Flat_No, @City, @GFloor);";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@GuestID", guestId);
                    insertCmd.Parameters.AddWithValue("@First_Name", firstName);
                    insertCmd.Parameters.AddWithValue("@Last_Name", lastName);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@Phone_Number", phoneNumber);
                    insertCmd.Parameters.AddWithValue("@Street_Name", streetName);
                    insertCmd.Parameters.AddWithValue("@Flat_No", flatNo);
                    insertCmd.Parameters.AddWithValue("@City", city);
                    insertCmd.Parameters.AddWithValue("@GFloor", gFloor);

                    insertCmd.ExecuteNonQuery();  // THIS LINE IS NECESSARY

                    return guestId;
                }
            }
        }

        public DataTable getReservationsByGuestID(int GuestID)
        {

            if (!GuestExists(GuestID))
            {
                Console.WriteLine("no client");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                    r.ReservationID,
                    g.First_Name + ' ' + g.Last_Name AS GuestName,
                    r.Check_In AS CheckIN,
                    r.Check_Out AS CheckOUT,
                    rr.Room_NumberRR AS Room
                FROM 
                    Reservation r
                JOIN 
                    Guest g ON r.GuestID = g.GuestID
                left JOIN 
                    Room_Reserve rr ON r.ReservationID = rr.ReservationIDRR
                where g.GuestID = @GuestID
                ORDER BY 
                    r.Check_In DESC;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GuestID", GuestID);
                DataTable table = new DataTable();

                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                table.Columns.Add("ReservationID");
                table.Columns.Add("GuestName");
                table.Columns.Add("CheckIN");
                table.Columns.Add("CheckOUT");
                table.Columns.Add("Room");
                DataRow row;
                while (reader.Read())
                {
                    row = table.NewRow();
                    row["ReservationID"] = reader["ReservationID"];
                    row["GuestName"] = reader["GuestName"];
                    row["CheckIN"] = reader["CheckIN"];
                    row["CheckOUT"] = reader["CheckOUT"];
                    row["Room"] = reader["Room"];
                    table.Rows.Add(row);
                }
                if (table.Rows.Count == 0)
                {
                    Console.WriteLine("a7a");
                }
                reader.Close();
                conn.Close();
                return table;

            }
        }


        public DataTable getReservationsByRoomNumber(int roomNumber)
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                    r.ReservationID,
                    g.First_Name + ' ' + g.Last_Name AS GuestName,
                    r.Check_In AS CheckIN,
                    r.Check_Out AS CheckOUT,
                    rr.Room_NumberRR AS Room
                FROM 
                    Reservation r
                JOIN 
                    Guest g ON r.GuestID = g.GuestID
                JOIN 
                    Room_Reserve rr ON r.ReservationID = rr.ReservationIDRR
                where rr.Room_NumberRR = @roomNumber
                ORDER BY 
                    r.Check_In DESC;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                DataTable table = new DataTable();

                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                table.Columns.Add("ReservationID");
                table.Columns.Add("GuestName");
                table.Columns.Add("CheckIN");
                table.Columns.Add("CheckOUT");
                table.Columns.Add("Room");
                DataRow row;
                while (reader.Read())
                {
                    row = table.NewRow();
                    row["ReservationID"] = reader["ReservationID"];
                    row["GuestName"] = reader["GuestName"];
                    row["CheckIN"] = reader["CheckIN"];
                    row["CheckOUT"] = reader["CheckOUT"];
                    row["Room"] = reader["Room"];
                    table.Rows.Add(row);
                }
                if (table.Rows.Count == 0)
                {
                    Console.WriteLine("a7a");
                }
                reader.Close();
                conn.Close();
                return table;

            }
        }
        public int SearchManager(int Code)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) FROM STAFF WHERE StaffRole LIKE '%manager%' AND StaffID = @Code;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Code", Code);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0) { return count; }
                else { return 0; }

            }
        }
        public DataTable Employeesdata(int ManagerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string q = @"SELECT StaffID,First_Name,Last_Name,StaffRole,BranchID,Job_Status FROM STAFF 
                            WHERE not StaffID=@ManagerID;";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@ManagerID", ManagerID);
                DataTable table = new DataTable();

                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                table.Columns.Add("StaffID");
                table.Columns.Add("First_Name");
                table.Columns.Add("Last_Name");
                table.Columns.Add("StaffRole");
                table.Columns.Add("BranchID");
                table.Columns.Add("Job_Status");
                DataRow row;
                while (reader.Read())
                {
                    row = table.NewRow();
                    row["StaffID"] = reader["StaffID"];
                    row["First_Name"] = reader["First_Name"];
                    row["Last_Name"] = reader["Last_Name"];
                    row["StaffRole"] = reader["StaffRole"];
                    row["BranchID"] = reader["BranchID"];
                    row["Job_Status"] = reader["Job_Status"];
                    table.Rows.Add(row);
                }

                reader.Close();
                conn.Close();
                return table;

            }
        }

        public void ShowFullInfo(int StaffID, Employeedetails ed)
        {
            try
            {
                // Create SQL query to get staff details
                string query = @"
                            SELECT 
                            s.StaffID, 
                            s.First_Name, 
                            s.Last_Name, 
                            s.Email, 
                            s.Phone_Number, 
                            s.StaffRole, 
                            s.Street_Name, 
                            s.Flat_No, 
                            s.City, 
                            s.SFloor, 
                            s.BranchID, 
                            s.Manager_ID, 
                            m.First_Name + ' ' + m.Last_Name AS ManagerName,
                            s.Job_Status
                            FROM 
                                Staff s
                            LEFT JOIN 
                                Staff m ON s.Manager_ID = m.StaffID
                            WHERE 
                                s.StaffID = @StaffID";

                // Create connection and command
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", StaffID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Fetch values from database
                        int staffID = Convert.ToInt32(reader["StaffID"]);
                        string firstName = reader["First_Name"].ToString();
                        string lastName = reader["Last_Name"].ToString();
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone_Number"].ToString();
                        string role = reader["StaffRole"].ToString();
                        string city = reader["City"].ToString();
                        string street = reader["Street_Name"].ToString().ToLower();
                        string flatno = reader["Flat_No"].ToString();
                        string floor = reader["SFloor"].ToString();
                        string branch = reader["BranchID"].ToString();
                        string managerName = reader["ManagerName"]?.ToString() ?? "No Manager";
                        string managerID = reader["Manager_ID"].ToString();
                        string status = reader["Job_Status"].ToString();

                        Console.WriteLine("Query obtained successfully!");

                        // Populate existing fields with the fetched values
                        ed.PopulateFields(staffID, firstName, lastName, email, phone, role, street, city, flatno, floor, branch, managerName, managerID, status);
                    }
                    else
                    {
                        MessageBox.Show("No details found for the selected employee.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff details: {ex.Message}", "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> FetchBranches()
        {
            List<string> branches = new List<string>();

            try
            {
                // Define the query to fetch all branch names
                string query = "SELECT BranchID FROM Branch";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    // Read each record and add to the list
                    while (reader.Read())
                    {
                        branches.Add(reader["BranchID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching branches: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return branches;
        }

        public void UpdateEmployee(string staffid, string role, string status, string phone, string branch)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                UPDATE Staff
                SET 
                    StaffRole = @role,
                    Phone_Number = @phone,
                    BranchID = @branch,
                    Job_Status = @status
                WHERE StaffID = @staffID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@branch", branch);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@staffID", staffid);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Please check the employee ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                con.Close();
            }
        }

        public DataTable ShowAvailableRooms(string startDate, string endDate, string branchID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery =
                    "SELECT r.Room_Number, r.Branch_ID, r.Price_Per_Night, r.RoomView, r.Room_Type, r.Resident_No " +
                    "FROM Room AS r " +
                    "LEFT JOIN Room_Reserve AS rr ON rr.Room_NumberRR = r.Room_Number " +
                    "AND rr.BranchIDRR = r.Branch_ID " +
                    "LEFT JOIN Reservation AS res ON res.ReservationID = rr.ReservationIDRR " +
                    "AND @CheckInDate <= res.Check_Out AND @CheckOutDate >= res.Check_In " +
                    "WHERE res.ReservationID IS NULL " +
                    "AND r.Branch_ID = @branchID";



                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@CheckInDate", startDate);
                checkCmd.Parameters.AddWithValue("@CheckOutDate", endDate);
                checkCmd.Parameters.AddWithValue("@branchID", branchID);

                using (SqlDataReader reader = checkCmd.ExecuteReader())
                {
                    // Create a DataTable to hold the results
                    DataTable dt = new DataTable();

                    // Load the DataTable with the data from the SqlDataReader
                    dt.Load(reader);

                    return dt;
                }
            }
        }


        public DataTable GetRoomDetails(string roomNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Room_Number AS [Room ID], Room_Type, RoomView, Price_Per_Night FROM Room WHERE Room_Number = @RoomNumber";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable roomDetails = new DataTable();
                adapter.Fill(roomDetails);

                return roomDetails;
            }
        }

        public DataTable GetPricesPerDay(string roomNumber, string startDate, string endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // First get price per night
                string priceQuery = "SELECT Price_Per_Night FROM Room WHERE Room_Number = @RoomNumber";
                SqlCommand priceCmd = new SqlCommand(priceQuery, conn);
                priceCmd.Parameters.AddWithValue("@RoomNumber", roomNumber);

                conn.Open();
                object priceObj = priceCmd.ExecuteScalar();
                conn.Close();

                if (priceObj == null) return null;

                decimal price = Convert.ToDecimal(priceObj);

                // Now generate dates and prices
                DateTime start = DateTime.ParseExact(startDate, "yyyy-MM-dd", null);
                DateTime end = DateTime.ParseExact(endDate, "yyyy-MM-dd", null);

                DataTable table = new DataTable();
                table.Columns.Add("Date");
                table.Columns.Add("Price");

                for (DateTime date = start; date <= end; date = date.AddDays(1))
                {
                    table.Rows.Add(date.ToString("yyyy-MM-dd"), price);
                }

                return table;
            }
        }



        public void getReservationInfo(int ReservationID, ViewReservation rs)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    			select 
	                        r.reservationid,
	                        r.guestid,
	                        r.meals,
	                        r.price,
	                        g.first_name+' '+g.last_name as GuestName,
	                        g.phone_number,
	                        g.Email,
	                        b.branchid,
	                        b.location as BranchName,
	                        FORMAT(r.Check_In, 'yyyy-MM-dd') as Check_In,
                            FORMAT(r.Check_Out, 'yyyy-MM-dd') as Check_Out,
                            FORMAT(r.BookingDate, 'yyyy-MM-dd') as BookingDate
	                        from Reservation r
	                        join Guest g on g.guestid = r.guestid
	                        left join Room_Reserve rr on rr.reservationidrr = r.reservationid
	                        left join branch b on rr.branchidrr = b.branchid
	                        where r.reservationid=@ReservationID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {


                    string BookingDate = reader["BookingDate"].ToString();
                    string GuestID = reader["GuestID"].ToString();
                    string GuestName = reader["GuestName"].ToString();
                    string PhoneNumber = reader["Phone_Number"].ToString();
                    string GuestEmail = reader["Email"].ToString();
                    string CheckIN = reader["Check_In"].ToString();
                    string CheckOUT = reader["Check_Out"].ToString();
                    string Price = reader["Price"].ToString();
                    string Meal = reader["Meals"].ToString();
                    string BranchName = reader["BranchName"].ToString();
                    string Branchid = reader["branchid"].ToString();


                    rs.PopulateFields(ReservationID, BookingDate, GuestID, GuestName, PhoneNumber, GuestEmail, CheckIN, CheckOUT, Price, Meal, BranchName, Branchid);
                }

            }

        }

        public DataTable getReservedRooms(int ReservationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    select room_Numberrr as Rooms from room_reserve where reservationidrr=@ReservationID
                    		";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReservationID", ReservationID.ToString());
                DataTable table = new DataTable();
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                table.Columns.Add("Rooms");
                DataRow row;
                while (reader.Read())
                {
                    row = table.NewRow();
                    row["Rooms"] = reader["Rooms"];
                    table.Rows.Add(row);
                }

                return table;
            }

        }

        public bool isPaid(int reservationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    		select count(transactionid) as numberOfTransactions from payment 
	                        where reservationidp=@ReservationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }

        }

        public void updateReservation(string reservationid, string CheckIn, string CheckOut, string meal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                                UPDATE reservation
                                SET Check_in = @CheckIn,
                                    check_out = @CheckOut,
	                                Meals = @meal
                                WHERE reservationid=@reservationid;
                            ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CheckIn", CheckIn);
                    cmd.Parameters.AddWithValue("@CheckOut", CheckOut);
                    cmd.Parameters.AddWithValue("@meal", meal);
                    cmd.Parameters.AddWithValue("@ReservationID", reservationid);
                    conn.Open();
                    MessageBox.Show("Reservation is updated successfully");
                }
            }
        }


        public void MakeReservation(
    int guestId,
    DateTime checkIn,
    DateTime checkOut,
    string meals,
    DateTime bookingDate,
    List<int> roomNumbers,    // just room numbers
    int branchId,             // same branch for all
    decimal price)
        {
            // Build DataTable matching dbo.RoomListType (RoomNumber, BranchID)
            var roomsTable = new DataTable();
            roomsTable.Columns.Add("RoomNumber", typeof(int));
            roomsTable.Columns.Add("BranchID", typeof(int));

            // Fill with one row per room, all sharing the same branchId
            foreach (int rn in roomNumbers)
                roomsTable.Rows.Add(rn, branchId);

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("MakeReservation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Scalar params
                cmd.Parameters.AddWithValue("@GuestID", guestId);
                cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                cmd.Parameters.AddWithValue("@CheckOut", checkOut);
                cmd.Parameters.AddWithValue("@Meals", meals);
                cmd.Parameters.AddWithValue("@BookingDate", bookingDate);
                cmd.Parameters.AddWithValue("@Price", price);

                // Table‐valued param
                var p = cmd.Parameters.Add("@Rooms", SqlDbType.Structured);
                p.TypeName = "dbo.RoomListType";
                p.Value = roomsTable;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteReservation(int ReservationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    		DELETE FROM Room_Reserve WHERE ReservationIDRR = @ReservationID;
                            DELETE FROM Reservation WHERE reservationid = @ReservationID;
                            ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", ReservationID.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reservation is deleted successfully");
                }

            }
        }




    }
}

