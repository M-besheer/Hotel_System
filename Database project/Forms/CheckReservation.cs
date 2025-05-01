using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_project.Forms
{
    public partial class CheckReservation : Form
    {
        public CheckReservation()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int guestID;
            int RoomNumber;
            Console.WriteLine(GuestID.Text);
            if (int.TryParse(GuestID.Text, out guestID))
            {
                DBHandler db = new DBHandler();
                dataGridView1.DataSource = db.getReservationsByGuestID(guestID);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Refresh();

                // Check if any rows were returned
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No reservations found for this Guest ID");
                }


            }
            else if (int.TryParse(roomNumber.Text, out RoomNumber))
            {
                DBHandler db = new DBHandler();
                dataGridView1.DataSource = db.getReservationsByRoomNumber(RoomNumber);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Refresh();

                // Check if any rows were returned
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No reservations found for this Guest ID");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Guest ID or Room number");
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewReservation vs = new ViewReservation(1);
            vs.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

    }
}
