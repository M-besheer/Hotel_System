using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;



namespace Database_project
{
        

        public class DBHandler
        {
        private readonly string connectionString = @"Server=MOMOS-LIL-SHREK;Database=hotelres;Trusted_Connection=True;TrustServerCertificate=True;";


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


    }
}

    
    

