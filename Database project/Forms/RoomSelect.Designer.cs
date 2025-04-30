namespace Database_project
{
    partial class RoomSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.View_Available_Rooms = new System.Windows.Forms.Button();
            this.dataGridRooms = new System.Windows.Forms.DataGridView();
            this.CheckIn = new System.Windows.Forms.TextBox();
            this.CheckOut = new System.Windows.Forms.TextBox();
            this.BranchNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // View_Available_Rooms
            // 
            this.View_Available_Rooms.AllowDrop = true;
            this.View_Available_Rooms.Location = new System.Drawing.Point(544, 287);
            this.View_Available_Rooms.Name = "View_Available_Rooms";
            this.View_Available_Rooms.Size = new System.Drawing.Size(244, 33);
            this.View_Available_Rooms.TabIndex = 0;
            this.View_Available_Rooms.Text = "View Available Rooms";
            this.View_Available_Rooms.UseVisualStyleBackColor = true;
            this.View_Available_Rooms.Click += new System.EventHandler(this.View_Rooms);
            // 
            // dataGridRooms
            // 
            this.dataGridRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRooms.Location = new System.Drawing.Point(12, 79);
            this.dataGridRooms.Name = "dataGridRooms";
            this.dataGridRooms.RowHeadersWidth = 51;
            this.dataGridRooms.RowTemplate.Height = 24;
            this.dataGridRooms.Size = new System.Drawing.Size(776, 202);
            this.dataGridRooms.TabIndex = 1;
            // 
            // CheckIn
            // 
            this.CheckIn.Location = new System.Drawing.Point(12, 34);
            this.CheckIn.Name = "CheckIn";
            this.CheckIn.Size = new System.Drawing.Size(228, 22);
            this.CheckIn.TabIndex = 2;
            // 
            // CheckOut
            // 
            this.CheckOut.Location = new System.Drawing.Point(264, 34);
            this.CheckOut.Name = "CheckOut";
            this.CheckOut.Size = new System.Drawing.Size(228, 22);
            this.CheckOut.TabIndex = 3;
            // 
            // BranchNumber
            // 
            this.BranchNumber.Location = new System.Drawing.Point(560, 34);
            this.BranchNumber.Name = "BranchNumber";
            this.BranchNumber.Size = new System.Drawing.Size(228, 22);
            this.BranchNumber.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Check-in Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Check-Out Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Branch Number";
            // 
            // RoomSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BranchNumber);
            this.Controls.Add(this.CheckOut);
            this.Controls.Add(this.CheckIn);
            this.Controls.Add(this.dataGridRooms);
            this.Controls.Add(this.View_Available_Rooms);
            this.Name = "RoomSelect";
            this.Text = "Reserve";
            this.Load += new System.EventHandler(this.RoomSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button View_Available_Rooms;
        private System.Windows.Forms.DataGridView dataGridRooms;
        private System.Windows.Forms.TextBox CheckIn;
        private System.Windows.Forms.TextBox CheckOut;
        private System.Windows.Forms.TextBox BranchNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}