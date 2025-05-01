using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Database_project.Forms
{
    public partial class Reserve : Form
    {
        private int _guestID;
        private List<string> _roomIDs;
        private string _startDate;
        private string _endDate;

        public Reserve(int guestID, List<string> selectedRooms, string startDate, string endDate)
        {
            InitializeComponent();

            _guestID = guestID;
            _roomIDs = selectedRooms;
            _startDate = startDate;
            _endDate = endDate;

            LoadRoomSummary();
            LoadDatesAndPrices();
        }

        private void LoadRoomSummary()
        {
            DBHandler dbHandler = new DBHandler();  // Instantiate DBHandler to get data
            DataTable summaryTable = new DataTable();
            summaryTable.Columns.Add("Room ID");
            summaryTable.Columns.Add("Room Type");
            summaryTable.Columns.Add("Room View");
            summaryTable.Columns.Add("Price Per Night");

            // Fetch room details from the database and populate the table
            foreach (var roomID in _roomIDs)
            {
                // Fetch room details for each room
                DataTable roomDetails = dbHandler.GetRoomDetails(roomID); // Get room details from DB
                if (roomDetails.Rows.Count > 0)
                {
                    var row = roomDetails.Rows[0];
                    summaryTable.Rows.Add(roomID, row["Room_Type"], row["RoomView"], row["Price_Per_Night"]);
                }
            }

            dataGridView1.DataSource = summaryTable;  // Bind the summary table to the DataGridView
        }

        private void LoadDatesAndPrices()
        {
            DBHandler dbHandler = new DBHandler();  // Instantiate DBHandler to get data
            DataTable priceTable = new DataTable();
            priceTable.Columns.Add("Room ID");
            priceTable.Columns.Add("Stay Dates");
            priceTable.Columns.Add("Total Price");

            DateTime start = DateTime.ParseExact(_startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(_endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Calculate the total number of nights
            int totalNights = (end - start).Days + 1; // Add 1 to include the start day

            // For each room, get prices and calculate the total price for the entire stay
            foreach (var roomID in _roomIDs)
            {
                // Get price per night for the room from the database
                DataTable roomDetails = dbHandler.GetRoomDetails(roomID);
                if (roomDetails.Rows.Count > 0)
                {
                    var row = roomDetails.Rows[0];
                    decimal pricePerNight = Convert.ToDecimal(row["Price_Per_Night"]);

                    // Calculate the total price
                    decimal totalPrice = pricePerNight * totalNights;

                    // Add room info, dates, and total price to the price table
                    priceTable.Rows.Add(roomID, $"{start:yyyy-MM-dd} to {end:yyyy-MM-dd}", $"${totalPrice:F2}");
                }
            }

            dataGridView2.DataSource = priceTable;  // Bind the price table to the DataGridView
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reservation Confirmed!");

            // Here, you can add logic to store reservation details in the database
            // For now, we just confirm the reservation.

            Form1 done = new Form1(); // Navigate back to Form1 after confirmation
            done.Show();
            this.Close();  // Close the current Reserve form
        }
    }
}
