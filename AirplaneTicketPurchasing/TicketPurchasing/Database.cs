using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TicketPurchasing
{
    class Database
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["TicketPurchasing"].ConnectionString;
        private SqlConnection sqlCon;

        public void executeQuery(string sp,List<Parameter> param)
        {

        }

        public string autoGenerateID(string firstLetter, string sp, int length)
        {
            int num = 1;
            try
            {
                sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();
                SqlCommand sqlcmd = new SqlCommand(sp, sqlCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                if (reader.Read())
                {
                    num = Convert.ToInt32(reader[0].ToString().Remove(0, firstLetter.Length)) + 1;
                }
                sqlCon.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(sqlCon != null)
                {
                    sqlCon.Close();
                }
            }

            return firstLetter + num.ToString().PadLeft(length - firstLetter.ToString().Length, '0');
        }
    }
}
