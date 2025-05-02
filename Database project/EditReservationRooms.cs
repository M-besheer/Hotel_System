using Database_project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_project
{
    public partial class EditReservationRooms : Form
    {
        int reservationId;
        string BookingDate;
        String BranchID;
        public EditReservationRooms(int reservationId, string bookingDate, string branchID, string checkin, string checkout)
        {
            InitializeComponent();
            this.reservationId = reservationId;
            BookingDate = bookingDate;
            BranchID = branchID;

            label5.Text = reservationId.ToString();
            label6.Text = bookingDate;
            label3.Text = branchID;


            DBHandler db = new DBHandler();
            dataGridView2.DataSource = db.ShowAvailableRooms(checkin, checkout, BranchID);
            dataGridView1.DataSource = db.getReservedRooms(reservationId);
        }

        private void RemoveRoom_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room first.");
                return;
            }

            

            var selectedRooms = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var cell = row.Cells["Room_Number"];
                if (cell?.Value != null)
                    selectedRooms.Add(cell.Value.ToString());
            }

            DBHandler db = new DBHandler();
            db.removeRoomFromReservation(reservationId, BranchID, selectedRooms);


        }

        private void Back_Click(object sender, EventArgs e)
        {
            ViewReservation viewReservation = new ViewReservation(reservationId);
            viewReservation.Show();
            this.Hide();
        }
    }
}
