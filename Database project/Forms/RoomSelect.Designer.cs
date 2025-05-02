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
            // 
            // View_Available_Rooms
            // 
            this.View_Available_Rooms.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.View_Available_Rooms.FlatAppearance.BorderSize = 2;
            this.View_Available_Rooms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.View_Available_Rooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.View_Available_Rooms.ForeColor = System.Drawing.Color.White;
            this.View_Available_Rooms.Location = new System.Drawing.Point(885, 252);
            this.View_Available_Rooms.Name = "View_Available_Rooms";
            this.View_Available_Rooms.Size = new System.Drawing.Size(230, 40);
            this.View_Available_Rooms.TabIndex = 10;
            this.View_Available_Rooms.Text = "View Available Rooms";
            this.View_Available_Rooms.UseVisualStyleBackColor = false;
            this.View_Available_Rooms.Click += new System.EventHandler(this.View_Rooms);
            // 
            // dataGridRooms
            // 
            this.dataGridRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRooms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridRooms.BackgroundColor = System.Drawing.Color.White;
            this.dataGridRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRooms.Location = new System.Drawing.Point(15, 85);
            this.dataGridRooms.Name = "dataGridRooms";
            this.dataGridRooms.RowHeadersWidth = 51;
            this.dataGridRooms.Size = new System.Drawing.Size(804, 350);
            this.dataGridRooms.TabIndex = 9;
            // 
            // BranchNumber
            // 
            this.BranchNumber.Location = new System.Drawing.Point(560, 34);
            this.BranchNumber.Name = "BranchNumber";
            this.BranchNumber.Size = new System.Drawing.Size(228, 28);
            this.BranchNumber.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Check-in Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(261, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Check-Out Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(557, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Branch Number";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Pay
            // 
            this.Pay.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Pay.FlatAppearance.BorderSize = 2;
            this.Pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pay.ForeColor = System.Drawing.Color.White;
            this.Pay.Location = new System.Drawing.Point(929, 353);
            this.Pay.Name = "Pay";
            this.Pay.Size = new System.Drawing.Size(157, 46);
            this.Pay.TabIndex = 4;
            this.Pay.Text = "Pay";
            this.Pay.UseVisualStyleBackColor = false;
            this.Pay.Click += new System.EventHandler(this.Pay_Click);
            // 
            // CheckOut
            // 
            this.CheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CheckOut.Location = new System.Drawing.Point(264, 34);
            this.CheckOut.Name = "CheckOut";
            this.CheckOut.Size = new System.Drawing.Size(140, 28);
            this.CheckOut.TabIndex = 3;
            this.CheckOut.Value = new System.DateTime(2025, 5, 2, 0, 0, 0, 0);
            // 
            // Checkin
            // 
            this.Checkin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Checkin.Location = new System.Drawing.Point(15, 34);
            this.Checkin.Name = "Checkin";
            this.Checkin.Size = new System.Drawing.Size(140, 28);
            this.Checkin.TabIndex = 2;
            this.Checkin.Value = new System.DateTime(2025, 5, 2, 0, 0, 0, 0);
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.back_btn.FlatAppearance.BorderSize = 2;
            this.back_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.back_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_btn.ForeColor = System.Drawing.Color.White;
            this.back_btn.Location = new System.Drawing.Point(1157, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(75, 30);
            this.back_btn.TabIndex = 1;
            this.back_btn.Text = "<- Back";
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btnClick);
            // 
            // RoomSelect
            // 
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1244, 450);
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
            this.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
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
