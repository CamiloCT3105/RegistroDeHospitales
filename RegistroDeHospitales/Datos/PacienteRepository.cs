using RegistroDeHospitales.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RegistroDeHospitales.Datos
{
    public class PacienteRepository
    {
        private SqlConnection conexion = Conexion.ObtenerConexion();

        public void Agregar(Paciente paciente)
        {
            string query = "INSERT INTO Pacientes (Nombre, Apellido, FechaNacimiento, ContactoEmergencia) VALUES (@Nombre, @Apellido, @FechaNacimiento, @ContactoEmergencia)";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ContactoEmergencia", paciente.ContactoEmergencia);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public List<Paciente> Listar()
        {
            var lista = new List<Paciente>();
            string query = "SELECT * FROM Pacientes";

            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Paciente
                    {
                        PacienteID = (int)reader["PacienteID"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        ContactoEmergencia = (long)reader["ContactoEmergencia"] // ← CORRECTO
                    });
                }

                conexion.Close();
            }

            return lista;
        }


        public List<Paciente> ObtenerTodos()
        {
            return Listar();
        }

        public void Actualizar(Paciente paciente)
        {
            string query = "UPDATE Pacientes SET Nombre=@Nombre, Apellido=@Apellido, FechaNacimiento=@FechaNacimiento, ContactoEmergencia=@ContactoEmergencia WHERE PacienteID=@PacienteID";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@PacienteID", paciente.PacienteID);
                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ContactoEmergencia", paciente.ContactoEmergencia);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public void Eliminar(int pacienteID)
        {
            string query = "DELETE FROM Pacientes WHERE PacienteID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@ID", pacienteID);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }
}
