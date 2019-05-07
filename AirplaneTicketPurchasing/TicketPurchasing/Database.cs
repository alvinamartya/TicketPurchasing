using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace TicketPurchasing
{
    class Database
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["TicketPurchasing"].ConnectionString;
        private SqlConnection sqlCon;

        public int executeQuery(string sp,List<Parameter> param,string process)
        {
            try
            {
                sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(sp, sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                foreach(Parameter item in param)
                {
                    sqlCmd.Parameters.AddWithValue(item.Key, item.Value);
                }
                return sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(process + " data is failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlCon != null)
                {
                    sqlCon.Close();
                }
            }
            return 0;
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

        public DataSet getDataFromDatabase(string sp, string role)
        {
            DataSet result = new DataSet();
            sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            if (role == null)
            {
                try
                {
                    SqlDataAdapter sqlAdp = new SqlDataAdapter(sp, sqlCon);
                    sqlAdp.Fill(result);
                    sqlCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    SqlCommand comm = new SqlCommand("sp_view_employees", sqlCon);
                    comm.Parameters.AddWithValue("@Role", role);
                    comm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlAdp = new SqlDataAdapter(comm);
                    sqlAdp.Fill(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sqlCon.Close();
            return result;
        } 
    }
}
