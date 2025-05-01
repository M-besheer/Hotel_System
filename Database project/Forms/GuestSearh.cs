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
            SearchBox.AutoCompleteMode = AutoCompleteMode.None;
            SearchBox.AutoCompleteSource = AutoCompleteSource.None;

            // wire up text-update to refill the DataSource
            SearchBox.TextUpdate += SearchComboBox_TextChanged;
        }

        // Handle text changes
        private void SearchComboBox_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox.Text;
            if (string.IsNullOrEmpty(txt))
            {
                SearchBox.DroppedDown = false;
                SearchBox.DataSource = null;
                return;
            }

            DataTable results;
            try { results = db.SearchGuests(txt); }
            catch
            {
                SearchBox.DroppedDown = false;
                SearchBox.DataSource = null;
                return;
            }
            if (results.Rows.Count == 0)
            {
                SearchBox.DroppedDown = false;
                SearchBox.DataSource = null;
                return;
            }

            // Build a list of objects with GuestID and Display text:
            var list = results.Rows
                              .Cast<DataRow>()
                              .Select(r => new {
                                  GuestID = Convert.ToInt32(r["GuestID"]),
                                  Display = $"{r["GuestID"]} - {r["First_Name"]} {r["Last_Name"]}"
                              })
                              .ToList();

            SearchBox.DataSource = list;
            SearchBox.DisplayMember = "Display";
            SearchBox.ValueMember = "GuestID";
            SearchBox.DroppedDown = true;
            // put the user’s raw typing back and reset caret:
            SearchBox.Text = txt;
            SearchBox.SelectionStart = txt.Length;
            SearchBox.SelectionLength = 0;
        }
        private void SearchBtnClick(object sender, EventArgs e)
        {
            // Now SelectedValue *is* the GuestID (or null if nothing selected)
            if (SearchBox.SelectedValue is int guestId)
            {
                if (db.GuestExists(guestId))
                {
                    MessageBox.Show("Guest exists!");

                    // pass guestId along to your reservation form
                    var reserveForm = new RoomSelect(guestId);
                    reserveForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Guest does not exist.");
                }
            }
            else
            {
                MessageBox.Show("Please select a guest from the list.");
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
