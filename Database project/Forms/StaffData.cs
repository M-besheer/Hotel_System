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
    public partial class StaffData : Form
    {   
        private int _id;
        private DataTable employeeData;
        public StaffData(int ManagerID)
        {
            _id = ManagerID;
            InitializeComponent();
            loademployees();
            EmployeeSearch.TextChanged += SearchBox_TextChanged;
            
        }
        private void loademployees()
        {
            DBHandler db = new DBHandler();
            employeeData = db.Employeesdata(_id);
            Employeesdata.DataSource = db.Employeesdata(_id);

        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
    {
        string filterText = EmployeeSearch.Text;

        
            // Apply filtering
            string filterExpression = $@"
                Convert(StaffID, 'System.String') LIKE '%{filterText}%' OR 
                First_Name LIKE '%{filterText}%' OR 
                Last_Name LIKE '%{filterText}%'";
            
            DataView filteredView = new DataView(employeeData);
            filteredView.RowFilter = filterExpression;
            Employeesdata.DataSource = filteredView;
        
    }

    }
}
