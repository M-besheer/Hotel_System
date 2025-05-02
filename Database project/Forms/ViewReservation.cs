using Database_project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        string ReservationID;
        string BookingDate;
        string Branchid;
        string checkin;
        string checkout;
        public ViewReservation(string ReservationID)
        {
            this.ReservationID = ReservationID;
            InitializeComponent();
            DBHandler db = new DBHandler();
            db.getReservationInfo(ReservationID,this);
        }

        public void PopulateFields(string Reservation, string bookingDate, string guestID, string guestName, string phoneNumber, string guestEmail, string checkIN, string checkOUT, string price, string meal, string branchName, string Branchid)
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

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            DateTime current = DateTime.ParseExact(currentDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime check_out_date = DateTime.ParseExact(checkOUT, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (current >= check_out_date)
            {
                EditRooms.Visible = false;
                UPDATE.Visible = false;
            }
            else
            {
                EditRooms.Visible = true;
                UPDATE.Visible = true;
            }
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


        private void UPDATE_Click(object sender, EventArgs e)
        {

        }


    }
}
