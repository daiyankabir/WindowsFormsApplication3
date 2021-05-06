using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from UserInfo where UserName='" + textBox3.Text +
                                               "' and Password='" + textBox1.Text + "'");

            if (dt.Rows.Count != 1)
            {
                MessageBox.Show("Invalid UserName or Password");
                return;
            }

            string type = dt.Rows[0]["Type"].ToString();
            if (type == "Admin")
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else
            {
                Form2 f1 = new Form2();
                f1.Show();
                this.Hide();
            }
        }
    }
}
