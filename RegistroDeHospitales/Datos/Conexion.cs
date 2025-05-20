using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RegistroDeHospitales.Datos
{
    public class Conexion
    {
        private static SqlConnection conexion;
        private static readonly string cadena = "Server=localhost\\SQLEXPRESS;Database=RegistroDeHospitales;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            if (conexion == null)
                conexion = new SqlConnection(cadena);

            return conexion;
        }
    }
}
