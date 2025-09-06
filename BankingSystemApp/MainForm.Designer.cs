namespace Banking.GUI
{
    partial class MainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(274, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(80, 18);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome,";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(140, 152);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(80, 18);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "Balance:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(245, 255);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(133, 28);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(136, 337);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(84, 32);
            this.btnDeposit.TabIndex = 3;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(324, 337);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(88, 32);
            this.btnWithdraw.TabIndex = 4;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(845, 303);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(79, 32);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // cboAccounts
            // 
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Location = new System.Drawing.Point(245, 72);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(133, 26);
            this.cboAccounts.TabIndex = 6;
            this.cboAccounts.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.HorizontalScrollbar = true;
            this.lstHistory.ItemHeight = 18;
            this.lstHistory.Location = new System.Drawing.Point(529, 12);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(395, 256);
            this.lstHistory.TabIndex = 7;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(149, 258);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(71, 18);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Amount:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(140, 75);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(80, 18);
            this.lblAccount.TabIndex = 9;
            this.lblAccount.Text = "Account:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 661);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.cboAccounts);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountManage";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cboAccounts;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAccount;
    }
}