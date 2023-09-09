namespace NEALibrarySystem
{
    partial class frmCustomTransaction
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMemberBarcode = new System.Windows.Forms.TextBox();
            this.lblMemberBarcode = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.lblCashGain = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCashGain = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(668, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(542, 388);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 50);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtMemberBarcode
            // 
            this.txtMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberBarcode.Location = new System.Drawing.Point(271, 7);
            this.txtMemberBarcode.Name = "txtMemberBarcode";
            this.txtMemberBarcode.Size = new System.Drawing.Size(517, 38);
            this.txtMemberBarcode.TabIndex = 20;
            // 
            // lblMemberBarcode
            // 
            this.lblMemberBarcode.AutoSize = true;
            this.lblMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberBarcode.Location = new System.Drawing.Point(12, 10);
            this.lblMemberBarcode.Name = "lblMemberBarcode";
            this.lblMemberBarcode.Size = new System.Drawing.Size(228, 31);
            this.lblMemberBarcode.TabIndex = 19;
            this.lblMemberBarcode.Text = "Member Barcode:";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberName.Location = new System.Drawing.Point(271, 67);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(517, 38);
            this.txtMemberName.TabIndex = 18;
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberName.Location = new System.Drawing.Point(12, 70);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(199, 31);
            this.lblMemberName.TabIndex = 17;
            this.lblMemberName.Text = "Member Name:";
            // 
            // lblCashGain
            // 
            this.lblCashGain.AutoSize = true;
            this.lblCashGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashGain.Location = new System.Drawing.Point(12, 115);
            this.lblCashGain.Name = "lblCashGain";
            this.lblCashGain.Size = new System.Drawing.Size(196, 62);
            this.lblCashGain.TabIndex = 21;
            this.lblCashGain.Text = "Cash gain\r\n(add - for loss):";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(12, 190);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(159, 31);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "Description:";
            // 
            // txtCashGain
            // 
            this.txtCashGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashGain.Location = new System.Drawing.Point(271, 127);
            this.txtCashGain.Name = "txtCashGain";
            this.txtCashGain.Size = new System.Drawing.Size(517, 38);
            this.txtCashGain.TabIndex = 23;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(271, 187);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(517, 189);
            this.txtDescription.TabIndex = 24;
            // 
            // frmCustomTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCashGain);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCashGain);
            this.Controls.Add(this.txtMemberBarcode);
            this.Controls.Add(this.lblMemberBarcode);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.lblMemberName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmCustomTransaction";
            this.Text = "frmCustomTransaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMemberBarcode;
        private System.Windows.Forms.Label lblMemberBarcode;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblCashGain;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCashGain;
        private System.Windows.Forms.TextBox txtDescription;
    }
}