using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow.ua_Nikolai.Auth.Controller
{
    class RegestrationController
    {
        private bool checkUniEmail { get; set; }
        public void Regestration(string _email, string _pass)
        {

            //string connectionString = @"Data Source=SQL5080.site4now.net;Initial Catalog=db_a8323e_itstep011;User Id=db_a8323e_itstep011_admin;Password=passitstep011;";
            string connectionString = @"Data Source = SQL5108.site4now.net; Initial Catalog = db_a85cd7_nick; User Id = db_a85cd7_nick_admin; Password = Passvbu011";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //InsertProcedure(_email);
                CanUserEdit(_email);
                //Users regestration = new Users() { email = _email, password =new Text_crypt ().Generate(_pass) };
                //connection.Execute("INSERT INTO Users (email, password) VALUES(@email,@password)", regestration);
            }

        }
        //CheckUniversalEmail
        public void InsertProcedure(string user_email)
        {
            try
            {
                #region выполнить хранимую процедуру вставки
                string connectionString = @"Data Source = SQL5108.site4now.net; Initial Catalog = db_a85cd7_nick; User Id = db_a85cd7_nick_admin; Password = Passvbu011";

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    int result = connection.Execute("usp_Login", new
                    {
                        uemail = user_email
                    }, commandType: CommandType.StoredProcedure);
                    System.Windows.Forms.MessageBox.Show(result.ToString());
                }
                #endregion



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("false");
            }
        }
        public void CanUserEdit(string userName)
        {
            string connectionString = @"Data Source = SQL5108.site4now.net; Initial Catalog = db_a85cd7_nick; User Id = db_a85cd7_nick_admin; Password = Passvbu011";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("CheckUniEmail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("uemail", userName);
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(rowAffected.ToString());

            }
        }
        private static void GetAgeRange(string user_email)
        {
            string sqlExpression = "CheckUniEmail";
            string connectionString = @"Data Source = SQL5108.site4now.net; Initial Catalog = db_a85cd7_nick; User Id = db_a85cd7_nick_admin; Password = Passvbu011";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = user_email
                };
                command.Parameters.Add(nameParam);

                // определяем первый выходной параметр
                SqlParameter minAgeParam = new SqlParameter
                {
                    ParameterName = "@minAge",
                    SqlDbType = SqlDbType.Int // тип параметра
                };
                // указываем, что параметр будет выходным
                minAgeParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(minAgeParam);



                command.ExecuteNonQuery();

                Console.WriteLine("Минимальный возраст: {0}", command.Parameters["@minAge"].Value);
                Console.WriteLine("Максимальный возраст: {0}", command.Parameters["@maxAge"].Value);
            }
        }
    }
}
