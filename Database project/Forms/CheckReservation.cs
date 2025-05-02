using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Database_project.Forms
{
    public partial class CheckReservation : Form
    {
        Form f;
        public CheckReservation(Form f)
        {
            InitializeComponent();
            this.f = f;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int guestID;
            int RoomNumber;


            
            if (int.TryParse(roomNumber.Text, out RoomNumber))
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
                    MessageBox.Show("No reservations found for this Room");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Room number");
            }




        }



        private void Back_Click(object sender, EventArgs e)
        {
            f.Show();
            this.Hide();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation first.");
                return;
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one.");
                return;
            }

            DBHandler db = new DBHandler();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells["reservationid"].Value != null)
                {
                    ViewReservation vs = new ViewReservation(row.Cells["reservationid"].Value.ToString(),this);
                    vs.Show();
                    this.Hide();
                }
            }
        }
    }
}
