using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Banking_Application;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Banking.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try { txt_username.Text = ""; } catch { }
            try { txt_password.Text = ""; } catch { }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // read user input
            string name = txt_username.Text.Trim();
            string token = txt_password.Text.Trim(); 

            try
            {
                var person = CoreBridge.LoginByNameAndSin(name, token);
                if (person == null)
                {
                    MessageBox.Show("Invalid name or SIN/password combination.");
                    return;
                }

                AppState.CurrentUser = person;
                AppState.CurrentAccounts = CoreBridge.AccountsOf(person);

                // Enter the main interface and ensure the process can exit normally
                this.Hide();
                var main = new MainForm();
                main.FormClosed += (s, args) => this.Close();
                main.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed：" + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txt_username.Text.Trim();
            string sin = txt_password.Text.Trim();

            if (name.Length < 2 || sin.Length < 3)
            {
                MessageBox.Show("Please enter a valid name and SIN.");
                return;
            }

            try
            {
                Bank.AddUser(name, sin);
                MessageBox.Show("Registration successful! You can now log in.");
            }
            catch (AccountException ex)
            {
                MessageBox.Show("Registration failed:" + ex.Message);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit(); // Close the login form to exit the program
        }
    }
}
