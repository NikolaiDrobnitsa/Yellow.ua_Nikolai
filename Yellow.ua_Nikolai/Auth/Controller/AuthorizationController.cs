using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yellow.ua_Nikolai.Auth.Model;

namespace Yellow.ua_Nikolai.Auth.Controller
{
    class AuthorizationController
    {
        public bool check_email { get; set; }
        public bool check_pass { get; set; }
        public AuthorizationController()
        {

        }

        public void Authorization(string auth_email, string auth_pass)
        {
            string connectionString = @"Data Source = SQL5108.site4now.net; Initial Catalog = db_a85cd7_nick; User Id = db_a85cd7_nick_admin; Password = Passvbu011";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    Users regestration = new Users() { email = _email, password = new Text_crypt().Generate(_pass) };
            //    connection.Execute("INSERT INTO Users (email, password) VALUES(@email,@password)", regestration);
            //}
            //System.Windows.Forms.MessageBox.Show(new Text_crypt().Generate(auth_pass));
            check_email = false;
            check_pass = false;
            string sqlExpression = "CheckUniversalEmail";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var myEvent = connection.QueryFirst<Users>(string.Format("SELECT * FROM Users WHERE email = '{0}'", auth_email));
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    if (new Text_crypt().Verification(auth_pass, myEvent.password))
                    {
                        //System.Windows.Forms.MessageBox.Show("if");
                        check_pass = false;
                    }
                    else
                    {
                        //System.Windows.Forms.MessageBox.Show("else");
                        check_pass = true;
                    }
                }
                catch
                {

                    check_email = true;
                }

            }
        }


    }
}

