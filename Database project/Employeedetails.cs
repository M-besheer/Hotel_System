using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database_project.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Database_project
{
    public partial class Employeedetails : Form
    {
        public Employeedetails()
        {
            InitializeComponent();
            InitFields();
        }
        public Employeedetails(int staffid)
        {
            InitializeComponent();
            DBHandler dB = new DBHandler();
            dB.ShowFullInfo(staffid,this);
            Console.WriteLine("db function invoked!");
            
        }
        
        private void InitFields()
        {
            StaffID.Enabled = true;
            Fname.Enabled = true;
            Lname.Enabled = true;
            email.Enabled = true;
            Phone.Enabled = true;
            Role.Enabled = true;
            BranchID.Enabled = true;
            ManagerID.Enabled = true;
            Managername.Enabled = true;
            JOBStatus.Enabled = true;
            Streetname.Enabled = true;
            CITY.Enabled = true;
            Flatno.Enabled = true;
            Floor.Enabled = true;
            insert.Visible = true;
            UPDATE.Visible = false;
          
        }
        private void Insertrecord(object sender, EventArgs e)
        {
            // Check if required fields are filled
            if (string.IsNullOrWhiteSpace(StaffID.Text) ||
                string.IsNullOrWhiteSpace(Fname.Text) ||
                string.IsNullOrWhiteSpace(Lname.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(Phone.Text) ||
                Role.SelectedItem == null ||
                BranchID.SelectedItem == null ||
                JOBStatus.SelectedItem == null ||
                string.IsNullOrWhiteSpace(Streetname.Text) ||
                string.IsNullOrWhiteSpace(CITY.Text) ||
                string.IsNullOrWhiteSpace(Flatno.Text) ||
                string.IsNullOrWhiteSpace(Floor.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email format
            if (!System.Text.RegularExpressions.Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate phone number
            if (!System.Text.RegularExpressions.Regex.IsMatch(Phone.Text, @"^[0-9+\-]+$"))
            {
                MessageBox.Show("Phone number must contain only numbers, '+' or '-'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Display a success message for now
            MessageBox.Show("All fields are valid. Ready for database insertion.", "Validation Passed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void PopulateFields(
         int staffID, string firstName, string lastName, string Email,
         string phone, string role, string street, string city, string flatno, string floor, string branch,
         string managerName,string managerID, string status)
        {
            StaffID.Text = staffID.ToString();
            Fname.Text = firstName;
            Lname.Text = lastName;
            email.Text = Email;
            Phone.Text = phone;
            Role.Text = role;
            BranchID.Text = branch;
            ManagerID.Text = managerID.ToString();
            Managername.Text = managerName;
            JOBStatus.Text = status;
            Streetname.Text = street;
            CITY.Text = city;
            Flatno.Text = flatno.ToString();
            Floor.Text = floor.ToString();

        }
        public void updatefields(object sender, EventArgs e)
        {
            DBHandler dbHandler = new DBHandler();
            // Toggle edit mode
            if (JOBStatus.Enabled == false)
            {
                // Enable fields for editing
                JOBStatus.Enabled = true;
                Role.Enabled = true;
                Phone.Enabled = true;
                BranchID.Enabled = true;

                // Populate Role dropdown
                Role.Items.Clear();
                Role.Items.AddRange(new string[] {
            "chef", "restaurant waiter", "room service", "front desk receptionist",
            "front desk manager", "bellman", "golf car driver", "general supervisor", "Branch Manager"
        });

                // Populate JOBStatus dropdown
                JOBStatus.Items.Clear();
                JOBStatus.Items.AddRange(new string[] { "active", "fired" });

                // Populate BranchID dropdown (example values)
                BranchID.Items.Clear();
                BranchID.Items.AddRange(dbHandler.FetchBranches().ToArray());
            }
            else
            {
                // Confirm before firing employee
                if (JOBStatus.SelectedItem?.ToString() == "fired")
                {
                    DialogResult confirmFiring = MessageBox.Show(
                        "Are you sure you want to fire "+ Fname.Text +" "+Lname.Text +"?",
                        "Confirm Firing",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmFiring != DialogResult.Yes)
                    {
                        return; // Abort firing
                    }
                }

                // Validate phone number
                if (!System.Text.RegularExpressions.Regex.IsMatch(Phone.Text, @"^[0-9+\-]+$"))
                {
                    MessageBox.Show("Invalid phone number. Only numbers, +, and - are allowed.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Call the database update function
                string role = Role.Text.ToString();
                string status = JOBStatus.Text.ToString();
                string phone = Phone.Text;
                string branch = BranchID.Text.ToString();

                Console.WriteLine(role + " " + status + " " + phone + " " +branch);
                if (role == null || status == null || branch == null)
                {
                    MessageBox.Show("All fields must be filled before updating.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Example DB function invocation

                dbHandler.UpdateEmployee(StaffID.Text, role, status, phone, branch);
                // Disable fields after saving
                JOBStatus.Enabled = false;
                Role.Enabled = false;
                Phone.Enabled = false;
                BranchID.Enabled = false;

                MessageBox.Show("Employee details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
