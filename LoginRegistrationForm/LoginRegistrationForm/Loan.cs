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
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "dd/MM/yyy";
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker3.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into loans values(@loan_id,@loan_type,@amount,@interest_rate,@loan_date,@customer_name)", con);
            cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Loan_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Interest_Rate", textBox4.Text);
            cnn.Parameters.AddWithValue("@Loan_Date", dateTimePicker3.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully !");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("select*from loans", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("update loans set loan_type=@loan_type,amount=@amount,interest_rate=@interest_rate,loan_date=@loan_date,customer_name=@customer_name where loan_id=@loan_id", con);
            cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Loan_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Interest_Rate", textBox4.Text);
            cnn.Parameters.AddWithValue("@Loan_Date", dateTimePicker3.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully !");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete loans where loan_id=@loan_id", con);
            cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully !");
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2292\LoginRegistrationForm\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cnn = new SqlCommand("select*from loans", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

          
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // Assign values to textboxes  
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                dateTimePicker3.Value = Convert.ToDateTime(row.Cells[4].Value);
                textBox5.Text = row.Cells[5].Value.ToString();
                // Continue for each column (Cells[index]) and each textbox  
            }
        }
    }
}
