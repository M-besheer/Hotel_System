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
        private Form1 originalForm;
        public CheckReservation(Form1 form1)
        {
            InitializeComponent();
            originalForm = form1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int guestID;
            int RoomNumber;
            Console.WriteLine(GuestID.Text);
            if (int.TryParse(GuestID.Text,out guestID))
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
                Console.WriteLine("da5alt 1");


            }
            else if (int.TryParse(roomNumber.Text,out RoomNumber))
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
                Console.WriteLine("da5alt 2");
            }
            else
            {
                MessageBox.Show("Please enter a valid Guest ID or Room number");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void back_btnClick(object sender, EventArgs e)
        {
            originalForm.Show();
            this.Close();
        }
    }
}
