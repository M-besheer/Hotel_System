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
    public partial class RoomSelect : Form
    {

        public RoomSelect()
        {
            InitializeComponent();
        }

        public RoomSelect(int guestID)
        {
            InitializeComponent();
        }

        private void View_Rooms(object sender, EventArgs e)
        {
            string startDate = CheckIn.Text.Trim();
            string endDate = CheckOut.Text.Trim();
            string branchID = BranchNumber.Text.Trim();

            DBHandler db = new DBHandler();
            dataGridRooms.DataSource = db.ShowAvailableRooms(startDate, endDate, branchID);
            dataGridRooms.AutoGenerateColumns = true;
            dataGridRooms.ReadOnly = true;
            dataGridRooms.AllowUserToAddRows = false;
            dataGridRooms.Refresh();
        }

        private void RoomSelect_Load(object sender, EventArgs e)
        {
            if (dataGridRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room first.");
                return;
            }
        }

      
    }
}
