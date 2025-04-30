using System;
using System.Linq;
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
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string email = mail.Text;
            string phoneNumber = Phone.Text;
            string streetName = Street.Text;
            string flatNo = Apartment.Text;
            string city = City.Text;
            string gFloor = Floor.Text;
            string guestIdStr = cnic.Text;

            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(streetName) || string.IsNullOrWhiteSpace(flatNo) ||
                string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(gFloor) ||
                string.IsNullOrWhiteSpace(guestIdStr))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Validate the Guest ID
            int guestId;
            if (!int.TryParse(guestIdStr, out guestId))
            {
                MessageBox.Show("Invalid Guest ID. Please enter a valid number.");
                return;
            }

            // Validate email format using a simple regex pattern
            /*if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email.");
                return;
            }*/

            // Validate phone number format (for example, checking if it has 10 digits)
            /*if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                MessageBox.Show("Invalid phone number. Please enter a 10-digit phone number.");
                return;
            }*/

            // Create an instance of DBHandler and insert the new guest
            DBHandler db = new DBHandler();

            // The InsertGuest method should return the GuestID of the inserted guest
            int insertedGuestId = db.InsertGuest(guestId, firstName, lastName, email, phoneNumber, streetName, flatNo, city, gFloor);

            if (insertedGuestId == 1)
            {
                MessageBox.Show($"Guest created successfully!");

                // Send the guest data to the Reserve form
                RoomSelect rs = new RoomSelect();
                rs.Show();  // This will show the Reserve form
                this.Hide();         // This hides the current form (Guest creation form)
            }
            else
            {
                MessageBox.Show("Failed to create guest. Please try again.");
            }
        }
    }
}
