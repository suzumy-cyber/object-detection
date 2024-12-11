using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LoginRegistrationForm
{
    public partial class ResetPassword : Form
    {
        string username = SendCode.to;
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            if (txtresetpass.Text == txtresetpassver.Text)
            {
                string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30";
                string query = "UPDATE admin SET passowrd=@passowrd WHERE email=@email";

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@passowrd", txtresetpassver.Text);
                    cmd.Parameters.AddWithValue("@email", username);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("reset successfully , Please Login Now.....!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error Occured:" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("the new password do not match so enter same password");
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtresetpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtresetpassver_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


