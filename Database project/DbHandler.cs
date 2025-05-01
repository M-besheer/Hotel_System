using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;



namespace Database_project
{


    public class DBHandler
    {
        private readonly string connectionString = @"Data Source=.;Initial Catalog=HotelDB;Integrated Security=True;Trust Server Certificate=True";

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

                // Check if guest with given ID exists
                string checkQuery = "SELECT COUNT(*) FROM Guest WHERE GuestID = @GuestID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@GuestID", guestId);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    // Guest already exists
                    return 0;
                }
                else
                {

                    // Insert new guest
                    string insertQuery = @"
                    INSERT INTO Guest (GuestID, First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
                    VALUES (@GuestID, @First_Name, @Last_Name, @Email, @Phone_Number, @Street_Name, @Flat_No, @City, @GFloor);
                    SELECT SCOPE_IDENTITY();";

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

                    //int newGuestId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    return 1;
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
                JOIN 
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
                if (table.Rows.Count == 0)
                {
                    Console.WriteLine("a7a");
                }
                if (table.Rows.Count > 0)
                {
                    Console.WriteLine("not a7a");
                }
                // Print column headers
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}\t");
                }
                Console.WriteLine();

                Console.WriteLine(new string('-', 50)); // Separator line

                // Print rows
                foreach (DataRow rows in table.Rows)
                {
                    foreach (var item in rows.ItemArray)
                    {
                        Console.WriteLine($"{item}\t");
                    }
                    Console.WriteLine();
                }
                reader.Close();
                conn.Close();
                return table;

            }
        }



        public DataTable ShowAvailableRooms(string startDate, string endDate, string branchID)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT r.Room_Number, r.Branch_ID, r.Price_Per_Night, r.RoomView, r.Room_Type, r.Resident_No FROM Room AS r LEFT JOIN Room_Reserve AS rr ON rr.Room_NumberRR = r.Room_Number AND rr.BranchIDRR = r.Branch_ID LEFT JOIN Reservation AS res ON res.ReservationID = rr.ReservationIDRR AND @CheckInDate < res.Check_Out AND @CheckOutDate > res.Check_In WHERE res.ReservationID IS NULL"; //AND r.Branch_ID = @branchID";


                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@CheckInDate", startDate);
                checkCmd.Parameters.AddWithValue("@CheckOutDate", endDate);
                //checkCmd.Parameters.AddWithValue("@branchID", branchID);

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



    }
}




