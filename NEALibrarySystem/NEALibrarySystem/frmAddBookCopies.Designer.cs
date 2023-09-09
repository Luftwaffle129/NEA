namespace NEALibrarySystem
{
    partial class frmAddBookCopies
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
            this.lblBarcodes = new System.Windows.Forms.Label();
            this.txtBarcodes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(145, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(15, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 50);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblBarcodes
            // 
            this.lblBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcodes.Location = new System.Drawing.Point(12, 9);
            this.lblBarcodes.Name = "lblBarcodes";
            this.lblBarcodes.Size = new System.Drawing.Size(253, 39);
            this.lblBarcodes.TabIndex = 19;
            this.lblBarcodes.Text = "Barcodes:";
            // 
            // txtBarcodes
            // 
            this.txtBarcodes.Location = new System.Drawing.Point(15, 51);
            this.txtBarcodes.Multiline = true;
            this.txtBarcodes.Name = "txtBarcodes";
            this.txtBarcodes.Size = new System.Drawing.Size(250, 333);
            this.txtBarcodes.TabIndex = 20;
            // 
            // frmAddBookCopies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 450);
            this.Controls.Add(this.txtBarcodes);
            this.Controls.Add(this.lblBarcodes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmAddBookCopies";
            this.Text = "Add Book Copies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBarcodes;
        private System.Windows.Forms.TextBox txtBarcodes;
    }
}