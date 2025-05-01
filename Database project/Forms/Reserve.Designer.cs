namespace Database_project.Forms
{
    partial class Reserve
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.confirm = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.meals = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(230, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(778, 108);
            this.dataGridView1.TabIndex = 0;
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(493, 341);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(260, 61);
            this.confirm.TabIndex = 1;
            this.confirm.Text = "CONFIRM RESERVATION";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(368, 183);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(539, 113);
            this.dataGridView2.TabIndex = 2;
            // 
            // meals
            // 
            this.meals.AutoSize = true;
            this.meals.Location = new System.Drawing.Point(583, 315);
            this.meals.Name = "meals";
            this.meals.Size = new System.Drawing.Size(66, 20);
            this.meals.TabIndex = 4;
            this.meals.Text = "meals";
            this.meals.UseVisualStyleBackColor = true;
            // 
            // Reserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 450);
            this.Controls.Add(this.meals);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Reserve";
            this.Text = "Reserve";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox meals;
    }
}