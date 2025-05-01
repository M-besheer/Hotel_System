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
        private int _branchID; // NEW: to store branch ID
        private List<string> _roomIDs;
        private string _startDate;
        private string _endDate;

        public Reserve(int branchID, int guestID, List<string> selectedRooms, string startDate, string endDate)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[]
            {
                "Breakfast only",
                "Dinner Only",
                "Breakfast and Diner",
                "Full Board"
            });
            comboBox1.SelectedIndex = 0;

            _guestID = guestID;
            _branchID = branchID; // Store branch ID
            _roomIDs = selectedRooms;
            _startDate = startDate;
            _endDate = endDate;

            LoadRoomSummary();
            LoadDatesAndPrices();
        }

        private void LoadRoomSummary()
        {
            DBHandler dbHandler = new DBHandler();
            DataTable summaryTable = new DataTable();
            summaryTable.Columns.Add("Room ID");
            summaryTable.Columns.Add("Room Type");
            summaryTable.Columns.Add("Room View");
            summaryTable.Columns.Add("Price Per Night");

            foreach (var roomID in _roomIDs)
            {
                DataTable roomDetails = dbHandler.GetRoomDetails(roomID);
                if (roomDetails.Rows.Count > 0)
                {
                    var row = roomDetails.Rows[0];
                    summaryTable.Rows.Add(roomID, row["Room_Type"], row["RoomView"], row["Price_Per_Night"]);
                }
            }

            dataGridView1.DataSource = summaryTable;
        }

        private void LoadDatesAndPrices()
        {
            DBHandler dbHandler = new DBHandler();
            DataTable priceTable = new DataTable();
            priceTable.Columns.Add("Room ID");
            priceTable.Columns.Add("Stay Dates");
            priceTable.Columns.Add("Total Price");

            DateTime start = DateTime.ParseExact(_startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(_endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int totalNights = (end - start).Days + 1;

            foreach (var roomID in _roomIDs)
            {
                DataTable roomDetails = dbHandler.GetRoomDetails(roomID);
                if (roomDetails.Rows.Count > 0)
                {
                    var row = roomDetails.Rows[0];
                    decimal pricePerNight = Convert.ToDecimal(row["Price_Per_Night"]);
                    decimal totalPrice = pricePerNight * totalNights;

                    priceTable.Rows.Add(roomID, $"{start:yyyy-MM-dd} to {end:yyyy-MM-dd}", $"${totalPrice:F2}");
                }
            }

            dataGridView2.DataSource = priceTable;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            DBHandler dbHandler = new DBHandler();
            DateTime checkIn = DateTime.ParseExact(_startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime checkOut = DateTime.ParseExact(_endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string meals = comboBox1.SelectedItem.ToString();
            DateTime bookingDate = DateTime.Now;

            int totalNights = (checkOut - checkIn).Days + 1;

            foreach (var roomID in _roomIDs)
            {
                DataTable roomDetails = dbHandler.GetRoomDetails(roomID);
                if (roomDetails.Rows.Count > 0)
                {
                    var row = roomDetails.Rows[0];
                    decimal pricePerNight = Convert.ToDecimal(row["Price_Per_Night"]);
                    decimal totalPrice = pricePerNight * totalNights;
                    int roomNumber = int.Parse(roomID); // Assuming roomID is a number in string form

                    dbHandler.MakeReservation(
                        _guestID,
                        checkIn,
                        checkOut,
                        meals,
                        bookingDate,
                        roomNumber,
                        _branchID,
                        totalPrice
                    );
                }
                else
                {
                    MessageBox.Show($"Room not found: {roomID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Reservation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
