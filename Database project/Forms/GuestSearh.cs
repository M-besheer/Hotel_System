using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;

namespace Database_project
{
    public partial class GuestSearh : Form
    {
        DBHandler db = new DBHandler();
        public GuestSearh()
        {
            InitializeComponent();
            SearchBox.DropDownStyle = ComboBoxStyle.DropDown;
            SearchBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SearchBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            SearchBox.DisplayMember = "Display"; // Custom display text
            SearchBox.ValueMember = "GuestID";   // Actual value to use
            SearchBox.TextChanged += SearchComboBox_TextChanged;
        }

        // Handle text changes
        private void SearchComboBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchBox.Text.Length >= 1) // Start searching after 1 character
            {
                DataTable results = db.SearchGuests(SearchBox.Text);

                // Create a list with combined display text
                var displayItems = new List<dynamic>();
                foreach (DataRow row in results.Rows)
                {
                    displayItems.Add(new
                    {
                       
                        Display = $"{row["GuestID"]} - {row["First_Name"]} {row["Last_Name"]}"
                    });
                }

                SearchBox.DataSource = displayItems;
                SearchBox.DroppedDown = true; // Show dropdown automatically
                if (SearchBox.Text.IsNullOrEmpty()) {
                    SearchBox.DroppedDown= false;

                }
            }
        }
        private void SearchBtnClick(object sender, EventArgs e)
        {
            int guestId;
            if (int.TryParse(SearchBox.Text, out guestId))
            {
                DBHandler db = new DBHandler();
                if (db.GuestExists(guestId))
                {
                    MessageBox.Show("Guest exists!");

                    // Navigate to Reserve form
                    RoomSelect reserveForm = new RoomSelect(guestId); // If Reserve takes guestId
                    reserveForm.Show();
                    this.Hide(); // Optional: hide current form
                }
                else
                {
                    MessageBox.Show("Guest does not exist.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Guest ID.");
            }
        }

        private void GuestSigUp_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Hide(); // Optional: hides the current form
        }

    }
}
