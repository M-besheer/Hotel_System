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
    public partial class GuestSearh : Form
    {
        public GuestSearh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int guestId;
            if (int.TryParse(textBox1.Text, out guestId))
            {
                DBHandler db = new DBHandler();
                if (db.GuestExists(guestId))
                {
                    MessageBox.Show("Guest exists!");

                    // Navigate to Reserve form
                    Reserve reserveForm = new Reserve(guestId); // If Reserve takes guestId
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
