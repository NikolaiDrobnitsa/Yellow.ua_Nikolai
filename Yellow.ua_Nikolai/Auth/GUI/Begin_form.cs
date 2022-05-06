using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yellow.ua_Nikolai.Auth.Controller;

namespace Yellow.ua_Nikolai.Auth.GUI
{
    public partial class Begin_form : Form
    {
        public Begin_form()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AuthorizationController authorization = new AuthorizationController();
            authorization.Authorization(textBox1.Text, textBox2.Text);
            if (authorization.check_pass == true && authorization.check_email == true)
            {
                label4.Visible = false;
                label3.ForeColor = Color.Gray;
                label3.Text = "Account does not exist! Register?";
                label3.Enabled = true;

            }
            else
            {
                label3.Enabled = false;
                label3.ForeColor = Color.Red;
                if (authorization.check_email == true)
                {
                    label4.Visible = true;
                    label4.Text = "Incorrect email";
                }
                else
                {
                    label4.Visible = false;
                    label4.Text = "";
                }
                if (authorization.check_pass == true)
                {
                    label3.Text = "Incorrect password";
                }
                else
                {
                    label3.Text = "";
                }
            }
            if (authorization.check_pass == false)
            {
                MessageBox.Show("AUTH");
            }


        }
        string required_email = "Email is a required field";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label4.Text = required_email;
            }
            else
            {
                if (textBox1.Text.Contains('@') && textBox1.Text.Contains('.'))
                {
                    label4.Visible = false;
                }
                else
                {
                    label4.Text = "Invalid email format! You forgot \"@\" or \".\"!";
                }
            }
            textBox1.LostFocus += TextBox1_LostFocus;
        }
        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            label4.Visible = true;
            if (textBox1.Text == "")
            {
                label4.Text = required_email;
            }
            else
            {
                if (textBox1.Text.Contains('@') && textBox1.Text.Contains('.'))
                {
                    label4.Visible = false;
                }
                else
                {
                    label4.Text = "Invalid email format! You forgot \"@\" or \".\"!";
                }
            }

        }


    }
}
