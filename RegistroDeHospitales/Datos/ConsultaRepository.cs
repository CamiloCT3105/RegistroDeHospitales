using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeHospitales.Datos
{
    public class ConsultaRepository
    {
        private SqlConnection conexion = Conexion.ObtenerConexion();

        public void ProgramarConsulta(Consulta consulta)
        {
            string query = "INSERT INTO Consultas (FechaConsulta, TipoConsulta, PacienteID, MedicoID) " +
                           "VALUES (@Fecha, @Tipo, @PacienteID, @MedicoID)";

            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Fecha", consulta.FechaConsulta);
                cmd.Parameters.AddWithValue("@Tipo", consulta.TipoConsulta);
                cmd.Parameters.AddWithValue("@PacienteID", consulta.PacienteID);
                cmd.Parameters.AddWithValue("@MedicoID", consulta.MedicoID);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }

            string historial = "INSERT INTO HistorialMedico (FechaRegistro, DescripcionTratamiento, Observaciones, PacienteID) " +
                               "VALUES (GETDATE(), @Descripcion, @Obs, @PacienteID)";

            using (SqlCommand cmd = new SqlCommand(historial, conexion))
            {
                cmd.Parameters.AddWithValue("@Descripcion", consulta.TipoConsulta);
                cmd.Parameters.AddWithValue("@Obs", $"Consulta programada con el médico ID: {consulta.MedicoID}");
                cmd.Parameters.AddWithValue("@PacienteID", consulta.PacienteID);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public List<Consulta> Listar()
        {
            List<Consulta> lista = new List<Consulta>();
            string query = @"SELECT c.ConsultaID, c.FechaConsulta, c.TipoConsulta, 
                                    c.PacienteID, p.Nombre AS NombrePaciente, 
                                    c.MedicoID, m.Nombre AS NombreMedico
                             FROM Consultas c
                             JOIN Pacientes p ON c.PacienteID = p.PacienteID
                             JOIN PersonalMedico m ON c.MedicoID = m.MedicoID";

            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Consulta
                    {
                        ConsultaID = (int)dr["ConsultaID"],
                        FechaConsulta = (DateTime)dr["FechaConsulta"],
                        TipoConsulta = dr["TipoConsulta"].ToString(),
                        PacienteID = (int)dr["PacienteID"],
                        NombrePaciente = dr["NombrePaciente"].ToString(),
                        MedicoID = (int)dr["MedicoID"],
                        NombreMedico = dr["NombreMedico"].ToString()
                    });
                }
                conexion.Close();
            }

            return lista;
        }
    }
}
