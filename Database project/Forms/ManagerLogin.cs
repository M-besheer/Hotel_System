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
    public partial class ManagerLogin : Form
    {
        private Form1 originalForm;

        public ManagerLogin(Form1 form1)
        {
            InitializeComponent();
            originalForm = form1;
        }

        private void Managersearch(object sender, EventArgs e)
        {
            int managerid;
            if(int.TryParse(managercode.Text,out managerid))
            {
                DBHandler dB = new DBHandler();
                if (dB.SearchManager(managerid) > 0)
                {
                    MessageBox.Show("Manager with code " + managerid + " exists!");
                    StaffData sd = new StaffData(managerid);
                    sd.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("There is no Manager with this id" + managerid);
                }
            }
            else
            {
                MessageBox.Show("Enter a value!");
            }
        }

        private void backbtn(object sender, EventArgs e)
        {
            originalForm.Show();
            this.Hide();
        }
    }
}
