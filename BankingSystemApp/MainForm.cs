using System;
using System.Linq;
using System.Windows.Forms;
using Banking_Application;

namespace Banking.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (AppState.CurrentUser == null)
            {
                MessageBox.Show("Not logged in.");
                Close();
                return;
            }

            lblWelcome.Text = "Welcome, " + AppState.CurrentUser.Name;

            
            if (AppState.CurrentAccounts == null || AppState.CurrentAccounts.Count == 0)
                AppState.CurrentAccounts = CoreBridge.AccountsOf(AppState.CurrentUser);

          
            cboAccounts.DataSource = AppState.CurrentAccounts
                .Select(a => a.Number)
                .ToList();

            UpdateBalance();
            RefreshHistory();
        }

        private Account CurrentAccount()
        {
            var num = cboAccounts.SelectedItem as string;
            if (string.IsNullOrEmpty(num))
                throw new AccountException(AccountExceptionType.ACCOUNT_DOES_NOT_EXIST);
            return Bank.GetAccount(num);
        }

        private void UpdateBalance()
        {
            var acc = CurrentAccount();                    
            var bal = CoreBridge.BalanceOf(acc);
            lblBalance.Text = "Balance: " + bal.ToString("0.00");

        }

        private void RefreshHistory()
        {
            if (lstHistory == null) return; 
            var acc = CurrentAccount();
            lstHistory.Items.Clear();
            foreach (var t in CoreBridge.TransactionsOf(acc))
                lstHistory.Items.Add(t.ToString());
        }

        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBalance();
            RefreshHistory();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal amt;
            if (!decimal.TryParse(txtAmount.Text, out amt) || amt <= 0)
            {
                MessageBox.Show("Enter a valid amount.");
                return;
            }

            try
            {
                var acc = CurrentAccount();
                CoreBridge.Deposit(acc, amt, AppState.CurrentUser);
                UpdateBalance();
                RefreshHistory();
                txtAmount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deposit failed: " + ex.Message);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            decimal amt;
            if (!decimal.TryParse(txtAmount.Text, out amt) || amt <= 0)
            {
                MessageBox.Show("Enter a valid amount.");
                return;
            }

            try
            {
                var acc = CurrentAccount();
                CoreBridge.Withdraw(acc, amt, AppState.CurrentUser);
                UpdateBalance();
                RefreshHistory();
                txtAmount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Withdraw failed: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try { AppState.CurrentUser.Logout(); } catch { }
            
            this.Close(); 
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            
            if (Application.OpenForms.Count == 0) Application.Exit();
        }
    }
}
