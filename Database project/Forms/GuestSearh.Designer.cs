namespace Database_project
{
    partial class GuestSearh
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
            this.SearchBtn = new System.Windows.Forms.Button();
            this.GuestSigUp = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.SearchBtn.FlatAppearance.BorderSize = 3;
            this.SearchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchBtn.Location = new System.Drawing.Point(650, 47);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(204, 48);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtnClick);
            // 
            // GuestSigUp
            // 
            this.GuestSigUp.BackColor = System.Drawing.Color.SeaGreen;
            this.GuestSigUp.FlatAppearance.BorderSize = 3;
            this.GuestSigUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GuestSigUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuestSigUp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestSigUp.ForeColor = System.Drawing.SystemColors.Control;
            this.GuestSigUp.Location = new System.Drawing.Point(650, 119);
            this.GuestSigUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GuestSigUp.Name = "GuestSigUp";
            this.GuestSigUp.Size = new System.Drawing.Size(210, 58);
            this.GuestSigUp.TabIndex = 2;
            this.GuestSigUp.Text = "New Guest";
            this.GuestSigUp.UseVisualStyleBackColor = false;
            this.GuestSigUp.Click += new System.EventHandler(this.GuestSigUp_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.FormattingEnabled = true;
            this.SearchBox.IntegralHeight = false;
            this.SearchBox.ItemHeight = 28;
            this.SearchBox.Location = new System.Drawing.Point(69, 54);
            this.SearchBox.MaxDropDownItems = 100;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(562, 36);
            this.SearchBox.Sorted = true;
            this.SearchBox.TabIndex = 3;
            // 
            // GuestSearh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.GuestSigUp);
            this.Controls.Add(this.SearchBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GuestSearh";
            this.Text = "GuestSearh";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button GuestSigUp;
        private System.Windows.Forms.ComboBox SearchBox;
    }
}