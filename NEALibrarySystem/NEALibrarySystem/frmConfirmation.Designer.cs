﻿namespace NEALibrarySystem
{
    partial class frmConfirmation
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
            this.btnMemberCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMemberCancel
            // 
            this.btnMemberCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMemberCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberCancel.Location = new System.Drawing.Point(668, 205);
            this.btnMemberCancel.Name = "btnMemberCancel";
            this.btnMemberCancel.Size = new System.Drawing.Size(120, 50);
            this.btnMemberCancel.TabIndex = 3;
            this.btnMemberCancel.Text = "Cancel";
            this.btnMemberCancel.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(511, 205);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(120, 50);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(12, 9);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(776, 170);
            this.lblOutput.TabIndex = 4;
            this.lblOutput.Text = "Confirmation Message";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 266);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnMemberCancel);
            this.Controls.Add(this.btnYes);
            this.Name = "frmConfirmation";
            this.Text = "Confirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMemberCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblOutput;
    }
}