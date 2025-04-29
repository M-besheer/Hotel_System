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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Reserve_Click(object sender, EventArgs e)
        {
            GuestSearh GP = new GuestSearh();  // create an instance of Form2
            GP.Show();               // show Form2
            this.Hide();
        }
    }
}
