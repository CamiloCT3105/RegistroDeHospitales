using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RegistroDeHospitales.Modelos;

namespace RegistroDeHospitales.Datos
{
    public class MedicoDAL
    {
        public DataTable ObtenerTodos()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "SELECT MedicoID, Nombre, Especializacion, Horario, Licencia, Rol FROM PersonalMedico";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insertar(Medico medico)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "INSERT INTO PersonalMedico (Nombre, Especializacion, Horario, Licencia, Rol) VALUES (@Nombre, @Esp, @Horario, @Lic, @Rol)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Esp", medico.Especializacion);
                cmd.Parameters.AddWithValue("@Horario", medico.Horario);
                cmd.Parameters.AddWithValue("@Lic", medico.Licencia);
                cmd.Parameters.AddWithValue("@Rol", medico.Rol);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Medico medico)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "UPDATE PersonalMedico SET Nombre=@Nombre, Especializacion=@Esp, Horario=@Horario, Licencia=@Lic, Rol=@Rol WHERE MedicoID=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Esp", medico.Especializacion);
                cmd.Parameters.AddWithValue("@Horario", medico.Horario);
                cmd.Parameters.AddWithValue("@Lic", medico.Licencia);
                cmd.Parameters.AddWithValue("@Rol", medico.Rol);
                cmd.Parameters.AddWithValue("@ID", medico.MedicoID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int medicoID)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "DELETE FROM PersonalMedico WHERE MedicoID=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", medicoID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AsignarMedicoAPaciente(int medicoID, int pacienteID)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_AsignarPersonalMedico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PacienteID", pacienteID);
                cmd.Parameters.AddWithValue("@MedicoID", medicoID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
