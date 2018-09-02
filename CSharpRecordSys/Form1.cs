using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSharpRecordSys
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; User Id=root1; Password=''; Database=db_csrecords");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        public DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into tbl_accounts (username, password, privilege) VALUES " +
             "('" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", conn);
            adapter.Fill(ds, "tbl_accounts");
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            MessageBox.Show("User Registered!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from tbl_accounts where username = '" + textBox1.Text + 
                "' and password = '" + textBox2.Text + "'", conn);
            adapter.Fill(ds, "tbl_accounts");
            if (ds.Tables["tbl_accounts"].Rows.Count > 0)
            {
                MessageBox.Show("Welcome!");
                textBox1.Clear();
                textBox2.Clear();

                Form2 frm = new Form2();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Wrong combination of username and password");
            }
        }
    }
}
