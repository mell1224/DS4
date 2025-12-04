using System.Data.SqlClient;

namespace Pedidos
{
    public static class Conexion
    {
        // 1. Reemplaza la cadena de conexión existente por la nueva.
        // Se mantiene el literal @ para manejar posibles caracteres especiales.
        private static readonly string cadena =
            @"Server=ADMN-PC\SQLEXPRESS;Database=PanaderiaDB;Integrated Security=True;";

        // 2. La función para obtener la conexión sigue siendo la misma.
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
