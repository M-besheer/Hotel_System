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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void CreateGuest_Click(object sender, EventArgs e)
        {
            // Get the data from the TextBoxes
            string firstName = FirstName.Text;  // First name from the TextBox
            string lastName = LastName.Text;    // Last name from the TextBox
            string email = mail.Text;           // Email from the TextBox
            string phoneNumber = Phone.Text;    // Phone number from the TextBox
            string streetName = Street.Text;    // Street name from the TextBox
            string flatNo = Apartment.Text;     // Apartment number from the TextBox
            string city = City.Text;            // City from the TextBox
            string gFloor = Floor.Text;         // Floor number from the TextBox

            // Create an instance of DBHandler and insert the new guest
            DBHandler db = new DBHandler();

            // The InsertGuest method should return the GuestID of the inserted guest
            int guestId = db.InsertGuest(firstName, lastName, email, phoneNumber, streetName, flatNo, city, gFloor);

            if (guestId > 0)
            {
                MessageBox.Show($"Guest created successfully! Guest ID: {guestId}");

                // Send the guest data to the Reserve form
                Reserve reserveForm = new Reserve(guestId);
                reserveForm.Show();  // This will show the Reserve form
                this.Hide();         // This hides the current form (Guest creation form)
            }
            else
            {
                MessageBox.Show("Failed to create guest.");
            }
        }

    }
}
