using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yellow.ua_Nikolai.Auth.GUI;
using Yellow.ua_Nikolai.GUI;

namespace Yellow.ua_Nikolai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Catalogs catalogs = new Catalogs();
            catalogs.Show();
        }
        bool check = false;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (check == false)
            {
                textBox1.Visible = true;
                check = true;
            }
            else
            {
                textBox1.Visible = false;
                check = false;
            }
            

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Begin_form begin_Form = new Begin_form();
            begin_Form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Catalogs catalogs = new Catalogs();
            catalogs.Show();
        }
    }
}
