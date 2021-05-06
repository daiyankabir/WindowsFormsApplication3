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

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from department");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from department where Name like '%"+textBox1.Text+"%'");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from department");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "";
            if (textBox2.Text == "")
            {
                query = "insert into Department(Name) values('" + textBox3.Text + "')";
            }
            else
            {
                query = "update Department set Name='" + textBox3.Text + "' where ID=" + textBox2.Text + "";
            }

            int row = DataAccess.ExecuteQuery(query);
            if (row > 0)

            {
                MessageBox.Show("Inserted");
                button1.PerformClick();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex==-1)
                return;

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }

            string query = "delete from Department where ID=" + textBox2.Text + "";

            int row = DataAccess.ExecuteQuery(query);
            if (row > 0)
            {
                MessageBox.Show("Deleted");
                button1.PerformClick();
                button4.PerformClick();
            }
        }
    }
}
