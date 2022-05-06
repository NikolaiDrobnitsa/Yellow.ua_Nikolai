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
        private void button2_Click(object sender, EventArgs e)
        {
            AuthorizationController authorization = new AuthorizationController();
            authorization.Authorization(textBox1.Text, textBox2.Text);
            if (authorization.check_pass == true && authorization.check_email == true)
            {
                label9.Visible = false;
                label10.ForeColor = Color.Gray;
                label10.Text = "Account does not exist! Register?";
                label10.Enabled = true;

            }
            else
            {
                label10.Enabled = false;
                label10.ForeColor = Color.Red;
                if (authorization.check_email == true)
                {
                    label9.Visible = true;
                    label9.Text = "Incorrect email";
                }
                else
                {
                    label9.Visible = false;
                    label9.Text = "";
                }
                if (authorization.check_pass == true)
                {
                    label10.Text = "Incorrect password";
                }
                else
                {
                    label10.Text = "";
                }
            }
            if (authorization.check_pass == false)
            {
                MessageBox.Show("Успешная авторизацыя");
            }


        }
        string required_email = "Email is a required field";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label9.Text = required_email;
            }
            else
            {
                if (textBox1.Text.Contains('@') && textBox1.Text.Contains('.'))
                {
                    label9.Visible = false;
                }
                else
                {
                    label9.Text = "Invalid email format! You forgot \"@\" or \".\"!";
                }
            }
            textBox1.LostFocus += TextBox1_LostFocus;
        }
        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            label9.Visible = true;
            if (textBox1.Text == "")
            {
                label9.Text = required_email;
            }
            else
            {
                if (textBox1.Text.Contains('@') && textBox1.Text.Contains('.'))
                {
                    label9.Visible = false;
                }
                else
                {
                    label9.Text = "Invalid email format! You forgot \"@\" or \".\"!";
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
