namespace NEALibrarySystem
{
    partial class frmSelectDate
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
            this.calSelectDate = new System.Windows.Forms.MonthCalendar();
            this.btnMemberCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calSelectDate
            // 
            this.calSelectDate.Location = new System.Drawing.Point(18, 18);
            this.calSelectDate.Name = "calSelectDate";
            this.calSelectDate.ShowWeekNumbers = true;
            this.calSelectDate.TabIndex = 0;
            // 
            // btnMemberCancel
            // 
            this.btnMemberCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMemberCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberCancel.Location = new System.Drawing.Point(147, 192);
            this.btnMemberCancel.Name = "btnMemberCancel";
            this.btnMemberCancel.Size = new System.Drawing.Size(120, 50);
            this.btnMemberCancel.TabIndex = 5;
            this.btnMemberCancel.Text = "Cancel";
            this.btnMemberCancel.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(18, 192);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(120, 50);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // frmSelectDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 257);
            this.Controls.Add(this.btnMemberCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.calSelectDate);
            this.Name = "frmSelectDate";
            this.Text = "Select Date";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calSelectDate;
        private System.Windows.Forms.Button btnMemberCancel;
        private System.Windows.Forms.Button btnYes;
    }
}