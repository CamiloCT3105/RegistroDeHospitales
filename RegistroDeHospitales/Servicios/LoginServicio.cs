// Services/LoginService.cs
using System;
using System.Data.SqlClient;
using RegistroDeHospitales.Datos;
using RegistroDeHospitales.Modelos;

namespace RegistroDeHospitales.Servicios
{
    public class LoginServicio
    {
        public static Usuario ValidarLogin(string usuario, string clave)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Usuarios WHERE Usuario = @usuario AND Clave = @clave";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                IDUsuario = (int)reader["IDUsuario"],
                                NombreUsuario = reader["Usuario"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Rol = reader["Rol"].ToString(),
                                IDMedico = reader["IDMedico"] == DBNull.Value ? null : (int?)reader["IDMedico"]
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}


