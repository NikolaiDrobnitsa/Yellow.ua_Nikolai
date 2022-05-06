using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yellow.ua_Nikolai.Auth.Controller;

namespace Yellow.ua_Nikolai.Auth.GUI
{
    public partial class SingUp : Form
    {
        public SingUp()
        {
            InitializeComponent();
        }
        bool check_email = false;
        bool check_pass = false;
        string required_email = "Email is a required field";
        string required_pass = "Password is a required field";
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
                    check_email = true;
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
            check_email = false;
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
                    check_email = true;
                }
                else
                {
                    label4.Text = "Invalid email format! You forgot \"@\" or \".\"!";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d\[\]\(\),\.!@\$\^~\|=\-_\{\}#*%]{8,16}$");
            if (textBox2.Text == "")
            {
                label3.Text = required_pass;
            }
            else
            {
                if (textBox2.Text.Length < 8 || textBox2.Text.Length > 16)
                {
                    label3.Visible = true;
                    check_pass = false;
                    label3.Text = "Password Must be 8 - 16 characters long";
                }
                else
                {
                    if (rgx.IsMatch(textBox2.Text))
                    {
                        label3.Visible = false;
                        check_pass = true;
                    }
                    else
                    {
                        label3.Text = "Minimum 8 characters at least 1 Alphabet and 1 Number.The only allowed characters are all alphanumerics(A - Z, a - z, 0 - 9) and symbols[]()!$^,.~|= -_{ }#";
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegestrationController new_user = new RegestrationController();

            if (check_email == true && check_pass == true)
            {
                new_user.CanUserEdit(textBox1.Text);
                if (new_user.checkUniEmail == true)
                {
                    new_user.Regestration(textBox1.Text, textBox2.Text);
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = "Такой email существует придумайте другой!";
                }
            }
            else
            {
                if (check_email == false)
                {
                    textBox1.Focus();
                    if (textBox1.Text == "")
                    {
                        label4.Text = required_email;
                    }

                }
                if (check_pass == false)
                {
                    textBox2.Focus();
                    if (textBox2.Text == "")
                    {
                        label3.Text = required_pass;
                    }

                }
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

