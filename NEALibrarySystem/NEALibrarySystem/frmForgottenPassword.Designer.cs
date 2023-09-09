namespace NEALibrarySystem
{
    partial class frmForgottenPassword
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
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.txtVerificationCode = new System.Windows.Forms.TextBox();
            this.lblEMail = new System.Windows.Forms.Label();
            this.lblVerificationcode = new System.Windows.Forms.Label();
            this.btnSendVerificationCode = new System.Windows.Forms.Button();
            this.btnSubmitVerificationcode = new System.Windows.Forms.Button();
            this.lblForgottenPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEMail
            // 
            this.txtEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMail.Location = new System.Drawing.Point(66, 49);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(228, 20);
            this.txtEMail.TabIndex = 5;
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerificationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerificationCode.Location = new System.Drawing.Point(119, 126);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.PasswordChar = '•';
            this.txtVerificationCode.Size = new System.Drawing.Size(175, 20);
            this.txtVerificationCode.TabIndex = 6;
            // 
            // lblEMail
            // 
            this.lblEMail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEMail.Location = new System.Drawing.Point(20, 52);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(40, 17);
            this.lblEMail.TabIndex = 8;
            this.lblEMail.Text = "Email:";
            // 
            // lblVerificationcode
            // 
            this.lblVerificationcode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVerificationcode.Location = new System.Drawing.Point(20, 129);
            this.lblVerificationcode.Name = "lblVerificationcode";
            this.lblVerificationcode.Size = new System.Drawing.Size(93, 17);
            this.lblVerificationcode.TabIndex = 10;
            this.lblVerificationcode.Text = "Verification code:";
            // 
            // btnSendVerificationCode
            // 
            this.btnSendVerificationCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSendVerificationCode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSendVerificationCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendVerificationCode.Location = new System.Drawing.Point(22, 75);
            this.btnSendVerificationCode.Name = "btnSendVerificationCode";
            this.btnSendVerificationCode.Size = new System.Drawing.Size(272, 43);
            this.btnSendVerificationCode.TabIndex = 7;
            this.btnSendVerificationCode.Text = "Send Verification Code";
            this.btnSendVerificationCode.UseVisualStyleBackColor = false;
            // 
            // btnSubmitVerificationcode
            // 
            this.btnSubmitVerificationcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmitVerificationcode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSubmitVerificationcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitVerificationcode.Location = new System.Drawing.Point(23, 150);
            this.btnSubmitVerificationcode.Name = "btnSubmitVerificationcode";
            this.btnSubmitVerificationcode.Size = new System.Drawing.Size(272, 43);
            this.btnSubmitVerificationcode.TabIndex = 9;
            this.btnSubmitVerificationcode.Text = "Next";
            this.btnSubmitVerificationcode.UseVisualStyleBackColor = false;
            this.btnSubmitVerificationcode.Click += new System.EventHandler(this.btnSubmitVerificationcode_Click);
            // 
            // lblForgottenPassword
            // 
            this.lblForgottenPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblForgottenPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgottenPassword.Location = new System.Drawing.Point(-8, 4);
            this.lblForgottenPassword.Name = "lblForgottenPassword";
            this.lblForgottenPassword.Size = new System.Drawing.Size(340, 37);
            this.lblForgottenPassword.TabIndex = 11;
            this.lblForgottenPassword.Text = "Forgotten Password";
            this.lblForgottenPassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblForgottenPassword.Click += new System.EventHandler(this.lblForgottenPassword_Click);
            // 
            // frmForgottenPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 202);
            this.Controls.Add(this.lblForgottenPassword);
            this.Controls.Add(this.btnSubmitVerificationcode);
            this.Controls.Add(this.btnSendVerificationCode);
            this.Controls.Add(this.lblVerificationcode);
            this.Controls.Add(this.lblEMail);
            this.Controls.Add(this.txtVerificationCode);
            this.Controls.Add(this.txtEMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(338, 241);
            this.MinimumSize = new System.Drawing.Size(338, 241);
            this.Name = "frmForgottenPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgottenPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.TextBox txtVerificationCode;
        private System.Windows.Forms.Label lblEMail;
        private System.Windows.Forms.Label lblVerificationcode;
        private System.Windows.Forms.Button btnSendVerificationCode;
        private System.Windows.Forms.Button btnSubmitVerificationcode;
        private System.Windows.Forms.Label lblForgottenPassword;
    }
}