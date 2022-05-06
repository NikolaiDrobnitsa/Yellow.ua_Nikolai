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
    class RegestrationController
    {
        public bool checkUniEmail { get; set; }
        public int outresult { get; set; }
        public void Regestration(string _email, string _pass)
        {

            //string connectionString = @"Data Source=SQL5080.site4now.net;Initial Catalog=db_a8323e_itstep011;User Id=db_a8323e_itstep011_admin;Password=passitstep011;";
            string connectionString = @"Data Source = SQL5108.site4now.net; Initial Catalog = db_a85cd7_nick; User Id = db_a85cd7_nick_admin; Password = Passvbu011";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                Users regestration = new Users() { email = _email, password =new Text_crypt ().Generate(_pass) };
                connection.Execute("INSERT INTO Users (email, password) VALUES(@email,@password)", regestration);
            }

        }
        //CheckUniversalEmail

        public void CanUserEdit(string userName)
        {
            string connectionString = @"Data Source = SQL5108.site4now.net; Initial Catalog = db_a85cd7_nick; User Id = db_a85cd7_nick_admin; Password = Passvbu011";

            string sqlExpression = "CheckUniEmail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameEmail = new SqlParameter
                {
                    ParameterName = "@check_email",
                    Value = userName
                };
                command.Parameters.Add(nameEmail);


                SqlParameter Count_email = new SqlParameter
                {
                    ParameterName = "@count_check",
                    SqlDbType = SqlDbType.Int
                };

                Count_email.Direction = ParameterDirection.Output;
                command.Parameters.Add(Count_email);



                command.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show(command.Parameters["@count_check"].Value.ToString());
                outresult = Convert.ToInt32(command.Parameters["@count_check"].Value);
                if (outresult >= 1)
                {
                    checkUniEmail = false;
                }
                else
                {
                    checkUniEmail = true;
                }
            }
        }
        
    }
}
