using System;
using System.Data;
using System.Windows.Forms;

namespace Database_project.Forms
{
    public partial class StaffData : Form
    {
        private int _id; // Manager ID
        private DataTable employeeData; // Stores employee data

        public StaffData(int ManagerID)
        {
            _id = ManagerID;
            InitializeComponent();

            // Load employees and set up the DataGridView
            loademployees();
            InitializeDataGridView();

            // Attach search box event
            EmployeeSearch.TextChanged += SearchBox_TextChanged;
        }
        private void refresh(object sender, EventArgs e)
        {
            loademployees();
        }
        public void loademployees()
        {
            DBHandler db = new DBHandler();
            employeeData = db.Employeesdata(_id);

            // Bind the data to the DataGridView
            Employeesdata.DataSource = employeeData;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = EmployeeSearch.Text;

            if (string.IsNullOrEmpty(filterText))
            {
                // Reset the data source to show all employees
                Employeesdata.DataSource = employeeData;
            }
            else
            {
                // Apply filtering using a DataView
                string filterExpression = $@"
                    Convert(StaffID, 'System.String') LIKE '%{filterText}%' OR 
                    First_Name LIKE '%{filterText}%' OR 
                    Last_Name LIKE '%{filterText}%'";

                DataView filteredView = new DataView(employeeData);
                filteredView.RowFilter = filterExpression;

                Employeesdata.DataSource = filteredView;
            }
        }

        private void InitializeDataGridView()
        {
            // Create a new button column
            DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn
            {
                Name = "ViewDetails",
                HeaderText = "",
                Text = "View Details",
                UseColumnTextForButtonValue = true // Display "View Details" on all buttons
            };

            // Add the button column to the DataGridView
            Employeesdata.Columns.Add(viewButtonColumn);

            // Attach the event handler for button clicks
            Employeesdata.CellContentClick += Employeesdata_CellContentClick;
        }

        private void Employeesdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click was on the "ViewDetails" button column
            if (Employeesdata.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                // Retrieve the StaffID of the selected row
                int selectedStaffID = Convert.ToInt32(Employeesdata.Rows[e.RowIndex].Cells["StaffID"].Value);

                // Fetch and display detailed information for the selected staff
              Viewfullinfo(selectedStaffID);
                Console.WriteLine("View button clicked!");
            }
        }

        private void Viewfullinfo(int staffid)
        {
            Employeedetails employeedetails = new Employeedetails(staffid);
            employeedetails.Show();
            Console.WriteLine("Employee form shown!");

        }

        private void insertemployee(object sender, EventArgs e)
        {
            Employeedetails insert = new Employeedetails();
            insert.Show();
        }
    }
}
