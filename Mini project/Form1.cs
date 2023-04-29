using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mini_project
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ahmad_bqh2ijo\source\repos\Mini project\Mini project\Database1.mdf"";Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from users", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox4.Text.ToString());
            string name = textBox1.Text.ToString();
            string address = textBox3.Text.ToString();
            int phone = Int32.Parse(textBox2.Text.ToString());
            SqlCommand sq = new SqlCommand("insert into users values(" + id + ",'" + name + "','" + address + "', " + phone + ")", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sq = new SqlCommand("delete from users where id = " + textBox4.Text + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox4.Text.ToString());
            string name = textBox1.Text.ToString();
            string address = textBox3.Text.ToString();
            int phone = Int32.Parse(textBox2.Text.ToString());
            SqlCommand sq = new SqlCommand("update users set name ='" + name + "', address = '" + address + "', phonenumber = " + phone + " where id = " + id + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
