using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace CadATM.BLL
{
    public class DAL
    {
        public static DataTable ExecutaQuery(string query)
        {
            DataTable dt = new DataTable();

            string conexao = "informacoes de conexao ao banco de dados";
            
            SqlConnection sqlconn = new SqlConnection(conexao);
            SqlCommand sqlcmd = new SqlCommand(query, sqlconn);
            sqlconn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dt);
            sqlconn.Close();
            da.Dispose();

            return dt;
        }
    }
}
