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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into accounts values(@account_id,@account_type,@balance,@date_opened,@customer_name)", con);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox2.Text));
            cnn.Parameters.AddWithValue("@Account_Type", textBox3.Text);
            cnn.Parameters.AddWithValue("@Balance", textBox4.Text);
            cnn.Parameters.AddWithValue("@Date_Opened", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully !");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyy";

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("select*from accounts", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("update accounts set account_type=@account_type,balance=@balance,date_opened=@date_opened,customer_name=@customer_name where account_id=@account_id" , con);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox2.Text));
            cnn.Parameters.AddWithValue("@Account_Type", textBox3.Text);
            cnn.Parameters.AddWithValue("@Balance", textBox4.Text);
            cnn.Parameters.AddWithValue("@Date_Opened", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully !");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete accounts where account_id=@account_id", con);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox2.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully !");
        }

        private void Account_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("select*from accounts", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("select*from accounts where customer_name=@customer_name ", con);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            con.Close();
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                
              
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells[3].Value);
                textBox5.Text = row.Cells[4].Value.ToString();
                
            }
        }
    }
}
