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
        private readonly string connectionString = @"Data Source=.;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True;";

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

        public int InsertGuest(string firstName, string lastName, string email, string phoneNumber, string streetName, string flatNo, string city, string gFloor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert query
                string query = @"
                INSERT INTO Guest (First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
                VALUES (@First_Name, @Last_Name, @Email, @Phone_Number, @Street_Name, @Flat_No, @City, @GFloor);
                SELECT SCOPE_IDENTITY();";  // This will return the auto-incremented GuestID

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@First_Name", firstName);
                cmd.Parameters.AddWithValue("@Last_Name", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone_Number", phoneNumber);
                cmd.Parameters.AddWithValue("@Street_Name", streetName);
                cmd.Parameters.AddWithValue("@Flat_No", flatNo);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@GFloor", gFloor);

                // Execute the query and retrieve the GuestID
                int guestId = Convert.ToInt32(cmd.ExecuteScalar());  // This will give the last inserted GuestID
                return guestId;
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
                if (table.Rows.Count==0)
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


    }
}

    
    

