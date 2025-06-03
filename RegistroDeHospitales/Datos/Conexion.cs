using System.Data.SqlClient;

namespace RegistroDeHospitales.Datos
{
    public static class Conexion
    {
        private static readonly string cadena = @"Server = localhost\SQLEXPRESS;Database=RegistroDeHospitales;Trusted_Connection=True;";
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
