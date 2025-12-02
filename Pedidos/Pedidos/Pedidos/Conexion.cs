using System.Data.SqlClient;

namespace Pedidos
{
    public static class Conexion
    {
        private static readonly string cadena =
            @"Data Source=ADMN-PC\SQLEXPRESS;Initial Catalog=PanaderiaDB;Integrated Security=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
