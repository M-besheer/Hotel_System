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
        string reservationId;
        string BookingDate;
        String BranchID;
        string checkin;
        string checkout;
        ViewReservation vr;
        public EditReservationRooms(string reservationId, string bookingDate, string branchID, string checkin, string checkout, ViewReservation vr)
        {
            InitializeComponent();
            this.reservationId = reservationId;
            this.checkin = checkin;
            this.checkout = checkout;

            BookingDate = bookingDate;
            BranchID = branchID;

            label5.Text = reservationId.ToString();
            label6.Text = bookingDate;
            label3.Text = branchID;


            DBHandler db = new DBHandler();
            dataGridView2.DataSource = db.ShowAvailableRooms(checkin, checkout, BranchID);
            dataGridView1.DataSource = db.getReservedRooms(reservationId);
            this.vr = vr;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            vr.Show();
            this.Hide();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room first.");
                return;
            }


            if (dataGridView1.Rows.Count==2)
            {
                MessageBox.Show("Only one room, add first");
                return;
            }


            DBHandler db = new DBHandler();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells["Room_Number"].Value != null)
                {
                   db.removeRoomFromReservation(reservationId, BranchID, row.Cells["Room_Number"].Value.ToString());

                }
            }


            dataGridView2.DataSource = db.ShowAvailableRooms(checkin, checkout, BranchID);
            dataGridView1.DataSource = db.getReservedRooms(reservationId);

        }

        private void Add_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room first.");
                return;
            }

            DBHandler db = new DBHandler();
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                if (row.Cells["Room_Number"].Value != null)
                {
                    db.addRoomToReservation(reservationId, BranchID, row.Cells["Room_Number"].Value.ToString());
                }
            }
            dataGridView2.DataSource = db.ShowAvailableRooms(checkin, checkout, BranchID);
            dataGridView1.DataSource = db.getReservedRooms(reservationId);
        }
    }
}
