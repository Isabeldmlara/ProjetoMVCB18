using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoMVCB18.DAL
{
    public class ConexaoDAL
    { 
        private string stringConnection = "Persist Security info=false; server=localhost; database=ProjetoMVCB18; user=root; pwd=;";
        private MySqlConnection connection;

        public void ConnectDB()
        {
            try
            {
                connection = new MySqlConnection(stringConnection);
                connection.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error in database connection. " + e.Message);
            }
        }

        public void executeQuery(string sql)
        {
            try
            {
                ConnectDB();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw new Exception("Error in execute query. " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable executeConsult(string sql)
        {
            try
            {
                ConnectDB();
                DataTable dt = new DataTable();
                MySqlDataAdapter data = new MySqlDataAdapter(sql, connection);
                data.Fill(dt);
                return dt;
            }
            catch (MySqlException e)
            {
                throw new Exception("Error in consult database. " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}