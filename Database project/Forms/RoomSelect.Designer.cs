namespace Database_project
{
    partial class RoomSelect
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.View_Available_Rooms = new System.Windows.Forms.Button();
            this.dataGridRooms = new System.Windows.Forms.DataGridView();
            this.BranchNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Pay = new System.Windows.Forms.Button();
            this.CheckOut = new System.Windows.Forms.DateTimePicker();
            this.Checkin = new System.Windows.Forms.DateTimePicker();
            this.back_btn = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridRooms)).BeginInit();
            this.SuspendLayout();

            // Form Theme
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(1244, 450);

            // View_Available_Rooms
            this.View_Available_Rooms.Location = new System.Drawing.Point(885, 252);
            this.View_Available_Rooms.Size = new System.Drawing.Size(230, 40);
            this.View_Available_Rooms.Text = "View Available Rooms";
            this.View_Available_Rooms.BackColor = System.Drawing.Color.SeaGreen;
            this.View_Available_Rooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.View_Available_Rooms.FlatAppearance.BorderSize = 2;
            this.View_Available_Rooms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.View_Available_Rooms.ForeColor = System.Drawing.Color.White;
            this.View_Available_Rooms.Click += new System.EventHandler(this.View_Rooms);

            // dataGridRooms
            this.dataGridRooms.Location = new System.Drawing.Point(15, 85);
            this.dataGridRooms.Size = new System.Drawing.Size(804, 350);
            this.dataGridRooms.BackgroundColor = System.Drawing.Color.White;
            this.dataGridRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRooms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // BranchNumber
            this.BranchNumber.Location = new System.Drawing.Point(560, 34);
            this.BranchNumber.Size = new System.Drawing.Size(228, 24);

            // label1 - Check-in
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Text = "Check-in Date";
            this.label1.ForeColor = System.Drawing.Color.White;

            // label2 - Check-out
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 9);
            this.label2.Text = "Check-Out Date";
            this.label2.ForeColor = System.Drawing.Color.White;

            // label3 - Branch Number
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 9);
            this.label3.Text = "Branch Number";
            this.label3.ForeColor = System.Drawing.Color.White;

            // contextMenuStrip1
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);

            // Pay
            this.Pay.Location = new System.Drawing.Point(929, 353);
            this.Pay.Size = new System.Drawing.Size(157, 46);
            this.Pay.Text = "Pay";
            this.Pay.BackColor = System.Drawing.Color.SeaGreen;
            this.Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pay.FlatAppearance.BorderSize = 2;
            this.Pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.Pay.ForeColor = System.Drawing.Color.White;
            this.Pay.Click += new System.EventHandler(this.Pay_Click);

            // CheckOut
            this.CheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CheckOut.Location = new System.Drawing.Point(264, 34);
            this.CheckOut.Size = new System.Drawing.Size(140, 24);
            this.CheckOut.Value = new System.DateTime(2025, 5, 2);

            // Checkin
            this.Checkin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Checkin.Location = new System.Drawing.Point(15, 34);
            this.Checkin.Size = new System.Drawing.Size(140, 24);
            this.Checkin.Value = new System.DateTime(2025, 5, 2);

            // back_btn
            this.back_btn.Location = new System.Drawing.Point(1157, 12);
            this.back_btn.Size = new System.Drawing.Size(75, 30);
            this.back_btn.Text = "<- Back";
            this.back_btn.BackColor = System.Drawing.Color.SeaGreen;
            this.back_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_btn.FlatAppearance.BorderSize = 2;
            this.back_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.back_btn.ForeColor = System.Drawing.Color.White;
            this.back_btn.Click += new System.EventHandler(this.back_btnClick);

            // Add controls
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.Checkin);
            this.Controls.Add(this.CheckOut);
            this.Controls.Add(this.Pay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BranchNumber);
            this.Controls.Add(this.dataGridRooms);
            this.Controls.Add(this.View_Available_Rooms);
            this.Name = "RoomSelect";
            this.Text = "Select a Room";
            this.Load += new System.EventHandler(this.RoomSelect_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button View_Available_Rooms;
        private System.Windows.Forms.DataGridView dataGridRooms;
        private System.Windows.Forms.TextBox BranchNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button Pay;
        private System.Windows.Forms.DateTimePicker CheckOut;
        private System.Windows.Forms.DateTimePicker Checkin;
        private System.Windows.Forms.Button back_btn;
    }
}
