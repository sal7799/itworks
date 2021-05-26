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
//using System.Data.commandType;

namespace WinFormsApp1
{
    public partial class form_log_up : Form
    {
        public form_log_up()
        {
            InitializeComponent();
        }
        string connition = ("Data Source = DESKTOP-O3UH2S9\\SQLEXPRESS; initial catalog = ahmed ; integrated security=true");
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(connition);
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into Table_1 values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')",sql);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data saved");
            sql.Close();
            select();
        }
        private void select()
        {
           
            SqlConnection sqlc = new SqlConnection(connition);
            sqlc.Open();
            SqlCommand cmd =new SqlCommand("readData", sqlc);
            cmd.CommandType= CommandType.StoredProcedure;
           // SqlParameter[] par = new SqlParameter();
            
            SqlDataAdapter sqlaa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlaa.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlc.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void form_log_up_Load(object sender, EventArgs e)
        {
            select();
        }
    }
}
