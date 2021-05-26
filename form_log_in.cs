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

namespace WinFormsApp1
{
    public partial class form_log_in : Form
    {
        public form_log_in()
        {
            InitializeComponent();
        }
        string connition = ("Data Source = DESKTOP-O3UH2S9\\SQLEXPRESS; initial catalog = ahmed ; integrated security=true");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("write pass and name");
                }
                else
                {
                    SqlConnection sqlcon = new SqlConnection(connition);
                    SqlCommand cmd = new SqlCommand("select * from Table_1 where userName= @usero and password=@passo", sqlcon);
                    cmd.Parameters.AddWithValue("@usero", textBox1.Text);
                    cmd.Parameters.AddWithValue("@passo", textBox2.Text);
                    sqlcon.Open();
                    SqlDataAdapter sqla = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    sqla.Fill(dt);
                    sqlcon.Close();

                    int count = dt.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        MessageBox.Show("logedin");
                    }
                    else
                    {
                        MessageBox.Show("Not");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_log_up a = new form_log_up();
            a.Show();

        }

        private void form_log_in_Load(object sender, EventArgs e)
        {

        }
    }
}
