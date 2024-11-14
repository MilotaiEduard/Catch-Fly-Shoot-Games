using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Xml.Schema;
using A_and_E_Games;

namespace A_and_E_Application
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            if(textUsername.Text == "" && textPassword.Text == "" && textConfirmPassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textPassword.Text == textConfirmPassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('"+textUsername.Text+"' , '"+textPassword.Text+"')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                textUsername.Text = "";
                textPassword.Text = "";
                textConfirmPassword.Text = "";

                MessageBox.Show("Your Account has been Successfully Created" , "Registration Success!", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show("Passwords does not match, Please try again.", "Registration Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassword.Text = "";
                textConfirmPassword.Text = "";
                textPassword.Focus();
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPassword.Checked == true)
            {
                textPassword.PasswordChar = '\0';
                textConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                textPassword.PasswordChar = '*';
                textConfirmPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
            textConfirmPassword.Text = "";
            textUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}