using Database_project.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Database_project
{
    public partial class ViewReservation : Form
    {
        private string ReservationID;
        private string BookingDate;
        private string Branchid;
        private string checkin;
        private string checkout;

        // Keep your parameterless constructor as-is, with all the .Enabled = false calls:
        public ViewReservation()
        {
            InitializeComponent();
            GuestID.Enabled = false;
            GuestName.Enabled = false;
            PhoneNumber.Enabled = false;
            GuestEmail.Enabled = false;
            CheckIN.Enabled = false;
            CheckOUT.Enabled = false;
            Price.Enabled = false;
            Meal.Enabled = true;
            BranchName.Enabled = false;
        }
        CheckReservation cr;
        // Make your ID-based ctor call the default one:
        public ViewReservation(string reservationID, CheckReservation cr)
            : this()    // ← this calls ViewReservation()
        {
            this.cr=cr;
            this.ReservationID = reservationID;

            // Now you can do your Meal combo-box setup and load data…
            Meal.DropDownStyle = ComboBoxStyle.DropDownList;
            Meal.Items.AddRange(new[] {
        "No Meals",
        "Breakfast only",
        "Dinner Only",
        "Breakfast and Dinner",
        "Full Board"
    });

            new DBHandler().getReservationInfo(ReservationID, this);
            this.cr = cr;
        }


        /// <summary>
        /// Populates UI fields with reservation data.
        /// </summary>
        public void PopulateFields(
            string reservation,
            string bookingDate,
            string guestID,
            string guestName,
            string phoneNumber,
            string guestEmail,
            string checkIN,
            string checkOUT,
            string price,
            string meal,
            string branchName,
            string branchId)
        {
            // Header labels
            label5.Text = reservation;
            label6.Text = bookingDate;

            // Guest info
            GuestID.Text = guestID;
            GuestName.Text = guestName;
            PhoneNumber.Text = phoneNumber;
            GuestEmail.Text = guestEmail;

            // Reservation dates & price
            CheckIN.Text = checkIN;
            CheckOUT.Text = checkOUT;
            Price.Text = price;

            // Select meal in combo-box
            if (Meal.Items.Contains(meal))
                Meal.SelectedItem = meal;
            else
                Meal.SelectedIndex = 0;

            // Branch
            BranchName.Text = branchName;

            // Load reserved rooms into grid
            DBHandler db = new DBHandler();
            dataGridView1.DataSource = db.getReservedRooms(reservation);

            // Store for navigation
            BookingDate = bookingDate;
            Branchid = branchId;
            this.checkin = checkIN;
            this.checkout = checkOUT;

            // Show or hide edit/update based on checkout date
            DateTime current = DateTime.Now.Date;
            DateTime checkOutDate = DateTime.ParseExact(checkOUT, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            bool pastOrToday = current >= checkOutDate;

            EditRooms.Visible = !pastOrToday;
            UPDATE.Visible = !pastOrToday;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            cr.Show();
            this.Hide();
        }

        private void EditRooms_Click(object sender, EventArgs e)
        {
            var editRooms = new EditReservationRooms(
                ReservationID,
                BookingDate,
                Branchid,
                checkin,
                checkout,
                this
            );
            editRooms.Show();
            this.Hide();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            // Get new meal selection
            string newMeals = Meal.SelectedItem?.ToString() ?? string.Empty;

            // Call data-layer to update only meals
            var db = new DBHandler();
            db.UpdateReservationMeals(ReservationID, newMeals);

            MessageBox.Show(
                "Meal plan updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
