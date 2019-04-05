using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3App.Model
{
    class Mlistaclientes
    {
        public DataTable listaClientes()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = conect.DATABASE_URL;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "sp_Company_Orders_byYear";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(dt);
            }
            catch(Exception ex)
            {
                throw new Exception("ERROR EN LA CONEXIÓN\n" + ex.Message);
            }
            return dt;
        }
    }
}
