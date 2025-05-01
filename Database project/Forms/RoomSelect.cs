using Database_project.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Database_project
{
    public partial class RoomSelect : Form
    {
        private int CguestID;
        private GuestSearh guestSearch;

        public RoomSelect(GuestSearh guest_Search,int guestID)
        {
            InitializeComponent();
            guestSearch = guest_Search;
            CguestID = guestID;
        }

        private void View_Rooms(object sender, EventArgs e)
        {
            string startDate = Checkin.Value.ToString("yyyy-MM-dd");
            string endDate = CheckOut.Value.ToString("yyyy-MM-dd");
            string branchID = BranchNumber.Text.Trim();

            DBHandler db = new DBHandler();
            dataGridRooms.DataSource = db.ShowAvailableRooms(startDate, endDate, branchID);
            dataGridRooms.AutoGenerateColumns = true;
            dataGridRooms.ReadOnly = true;
            dataGridRooms.AllowUserToAddRows = false;
            dataGridRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridRooms.MultiSelect = true;
            dataGridRooms.Refresh();
        }

        private void RoomSelect_Load(object sender, EventArgs e)
        {
            // You can leave this empty or remove it.
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            if (dataGridRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room first.");
                return;
            }

            int guestID = CguestID;
            string startDate = Checkin.Value.ToString("yyyy-MM-dd");
            string endDate = CheckOut.Value.ToString("yyyy-MM-dd");

            List<string> selectedRooms = new List<string>();

            foreach (DataGridViewRow row in dataGridRooms.SelectedRows)
            {
                if (row.Cells["Room_Number"].Value != null)
                {
                    selectedRooms.Add(row.Cells["Room_Number"].Value.ToString());
                }
            }
            if (!int.TryParse(BranchNumber.Text.Trim(), out int branchID))
            {
                MessageBox.Show("Invalid branch ID. Please enter a valid number.");
                return;
            }


            Reserve reserveForm = new Reserve(this, branchID, guestID, selectedRooms, startDate, endDate);
            reserveForm.Show();
            this.Hide();
        }
        private void back_btnClick(object sender, EventArgs e)
        {
            guestSearch.Show();
            this.Close();
        }

       
    }
}
