using Database_project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_project
{
    public partial class ViewReservation : Form
    {
        public ViewReservation()
        {
            InitializeComponent();
            GuestID.Enabled = true;
            GuestName.Enabled = true;
            PhoneNumber.Enabled = true;
            GuestEmail.Enabled = true;
            CheckIN.Enabled = true;
            CheckOUT.Enabled = true;
            Price.Enabled = true;
            Meal.Enabled = true;
            BranchName.Enabled = true;
        }
        int ReservationID;
        string BookingDate;
        string Branchid;
        string checkin;
        string checkout;
        public ViewReservation(int ReservationID)
        {
            this.ReservationID = ReservationID;
            InitializeComponent();
            DBHandler db = new DBHandler();
            db.getReservationInfo(ReservationID,this);
        }

        public void PopulateFields(int Reservation, string bookingDate, string guestID, string guestName, string phoneNumber, string guestEmail, string checkIN, string checkOUT, string price, string meal, string branchName, string Branchid)
        {
            label5.Text = Reservation.ToString();
            label6.Text = bookingDate.ToString();

            GuestID.Text = guestID;
            GuestName.Text = guestName;
            PhoneNumber.Text = phoneNumber;
            GuestEmail.Text = guestEmail;
            CheckIN.Text = checkIN;
            CheckOUT.Text = checkOUT;
            Price.Text = price;
            Meal.Text = meal;
            BranchName.Text = branchName;

            DBHandler db = new DBHandler();
            dataGridView1.DataSource = db.getReservedRooms(Reservation);


            this.BookingDate = bookingDate;
            this.Branchid = Branchid;
            this.checkin = checkIN;
            this.checkout = checkOUT;

            if (db.isPaid(Reservation))
            {
                Delete.Visible = false;
            }
            else
            {
                Delete.Visible = true;
            }

        }



        private void Delete_Click(object sender, EventArgs e)
        {
            DBHandler db = new DBHandler();
            db.deleteReservation(ReservationID);
            CheckReservation checkReservation = new CheckReservation();
            checkReservation.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            CheckReservation checkReservation = new CheckReservation();
            checkReservation.Show();
            this.Hide();
        }

        private void EditRooms_Click(object sender, EventArgs e)
        {
            EditReservationRooms editReservationRooms = new EditReservationRooms(ReservationID, BookingDate,Branchid, checkin, checkout);
            editReservationRooms.Show();
            this.Hide();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            ViewReservation viewReservation = new ViewReservation(ReservationID);
            viewReservation.Show();
            this.Hide();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {

        }
    }
}
