using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LoginRegistrationForm
{
    public partial class SendCode : Form
    {
        string randomcode;
        public static string to;
        public SendCode()
        {
            InitializeComponent();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;

            // Get the email input and trim whitespace
            string emailInput = txtemail.Text.Trim();

            // Check if email input is empty
            if (string.IsNullOrWhiteSpace(emailInput))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }

            // Validate email format
            if (!IsValidEmail(emailInput))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            Random rnd = new Random();
            randomcode = rnd.Next(100000, 999999).ToString(); // Generate a 6-digit code
            MailMessage message = new MailMessage();
            to = emailInput; // Assign email input
            from = "kkharavimla@gmail.com";
            pass = "fxmc maxi wkql iogz"; // Ensure this is secure and not hard-coded
            messageBody = "Your reset code is " + randomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password Reset Code";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com"); // Corrected SMTP server
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnverify_Click(object sender, EventArgs e)
        {
            if (randomcode == (txtvercode.Text).ToString())
            {
                to = txtemail .Text;
                ResetPassword rp = new ResetPassword();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("wrong code");
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtvercode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
