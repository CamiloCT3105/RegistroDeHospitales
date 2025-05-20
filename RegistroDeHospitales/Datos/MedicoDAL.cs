using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalMedicoApp.Modelos;

namespace PersonalMedicoApp.Datos
{
    public class MedicoDAL
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=RegistroDeHospitales;Integrated Security=True";

        public DataTable ObtenerTodos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PersonalMedico", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insertar(Medico medico)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO PersonalMedico (Nombre, Especializacion, Horario, Licencia) VALUES (@Nombre, @Esp, @Horario, @Lic)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Esp", medico.Especializacion);
                cmd.Parameters.AddWithValue("@Horario", medico.Horario);
                cmd.Parameters.AddWithValue("@Lic", medico.Licencia);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Medico medico)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE PersonalMedico SET Nombre=@Nombre, Especializacion=@Esp, Horario=@Horario, Licencia=@Lic WHERE MedicoID=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Esp", medico.Especializacion);
                cmd.Parameters.AddWithValue("@Horario", medico.Horario);
                cmd.Parameters.AddWithValue("@Lic", medico.Licencia);
                cmd.Parameters.AddWithValue("@ID", medico.MedicoID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int medicoID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PersonalMedico WHERE MedicoID=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", medicoID);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
