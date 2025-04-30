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
        private readonly string connectionString = @"Data Source=.;Initial Catalog=HotelDatabase;Integrated Security=True;TrustServerCertificate=True;";

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
                INSERT INTO Guest (First_Name, Last_Name, Email, Phone_Number, Street_Name, Flat_No, City, GFloor)
                VALUES (@First_Name, @Last_Name, @Email, @Phone_Number, @Street_Name, @Flat_No, @City, @GFloor);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@First_Name", firstName);
                    insertCmd.Parameters.AddWithValue("@Last_Name", lastName);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@Phone_Number", phoneNumber);
                    insertCmd.Parameters.AddWithValue("@Street_Name", streetName);
                    insertCmd.Parameters.AddWithValue("@Flat_No", flatNo);
                    insertCmd.Parameters.AddWithValue("@City", city);
                    insertCmd.Parameters.AddWithValue("@GFloor", gFloor);

                    int newGuestId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    return newGuestId;
                }
            }
        }





    }
}

    
    

