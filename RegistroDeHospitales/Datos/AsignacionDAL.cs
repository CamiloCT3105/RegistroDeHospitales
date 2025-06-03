using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RegistroDeHospitales.Datos;
using RegistroDeHospitales.Modelos;

public class AsignacionDAL
{
    // Asigna una cama a un paciente
    public void AsignarCamaPaciente(int pacienteID, int camaID)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            con.Open();

            // Verificar si la cama está disponible
            string estadoQuery = "SELECT Estado FROM Camas WHERE CamaID = @CamaID";
            SqlCommand cmdEstado = new SqlCommand(estadoQuery, con);
            cmdEstado.Parameters.AddWithValue("@CamaID", camaID);
            string estado = cmdEstado.ExecuteScalar() as string;

            if (estado != "Disponible")
            {
                throw new InvalidOperationException("La cama no está disponible para asignar.");
            }

            // Insertar asignación
            string insertQuery = @"INSERT INTO AsignacionesCamas (PacienteID, CamaID, FechaAsignacion) 
                                   VALUES (@PacienteID, @CamaID, @FechaAsignacion)";
            SqlCommand cmdInsert = new SqlCommand(insertQuery, con);
            cmdInsert.Parameters.AddWithValue("@PacienteID", pacienteID);
            cmdInsert.Parameters.AddWithValue("@CamaID", camaID);
            cmdInsert.Parameters.AddWithValue("@FechaAsignacion", DateTime.Now);
            cmdInsert.ExecuteNonQuery();

            // Cambiar estado de la cama a Ocupada
            string updateEstado = "UPDATE Camas SET Estado = 'Ocupada' WHERE CamaID = @CamaID";
            SqlCommand cmdUpdate = new SqlCommand(updateEstado, con);
            cmdUpdate.Parameters.AddWithValue("@CamaID", camaID);
            cmdUpdate.ExecuteNonQuery();
        }
    }

    // Obtiene todas las asignaciones con detalle
    public List<AsignacionCama> ObtenerTodas()
    {
        var lista = new List<AsignacionCama>();

        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            con.Open();
            string query = @"
                SELECT ac.AsignacionID, ac.PacienteID, p.Nombre + ' ' + p.Apellido AS PacienteNombre,
                       ac.CamaID, s.SalaID, s.Tipo AS TipoSala,
                       ac.FechaAsignacion
                FROM AsignacionesCamas ac
                INNER JOIN Pacientes p ON ac.PacienteID = p.PacienteID
                INNER JOIN Camas c ON ac.CamaID = c.CamaID
                INNER JOIN Salas s ON c.SalaID = s.SalaID
                ORDER BY ac.FechaAsignacion DESC";

            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var asignacion = new AsignacionCama
                    {
                        AsignacionID = reader.GetInt32(0),
                        PacienteID = reader.GetInt32(1),
                        PacienteNombre = reader.GetString(2),
                        CamaID = reader.GetInt32(3),
                        NumeroCama = reader.GetString(4),
                        SalaID = reader.GetInt32(5),
                        TipoSala = reader.GetString(6),
                        FechaAsignacion = reader.GetDateTime(7)
                    };
                    lista.Add(asignacion);
                }
            }
        }

        return lista;
    }

    // Libera una cama (opcional si quieres dar de alta al paciente)
    public void LiberarCama(int asignacionID)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            con.Open();

            // Obtener ID de cama
            string selectCamaID = "SELECT CamaID FROM AsignacionesCamas WHERE AsignacionID = @AsignacionID";
            SqlCommand cmdSelect = new SqlCommand(selectCamaID, con);
            cmdSelect.Parameters.AddWithValue("@AsignacionID", asignacionID);
            object result = cmdSelect.ExecuteScalar();

            if (result == null)
                throw new Exception("No se encontró la asignación.");

            int camaID = (int)result;

            // Eliminar la asignación
            string deleteQuery = "DELETE FROM AsignacionesCamas WHERE AsignacionID = @AsignacionID";
            SqlCommand cmdDelete = new SqlCommand(deleteQuery, con);
            cmdDelete.Parameters.AddWithValue("@AsignacionID", asignacionID);
            cmdDelete.ExecuteNonQuery();

            // Cambiar el estado de la cama a Disponible
            string updateEstado = "UPDATE Camas SET Estado = 'Disponible' WHERE CamaID = @CamaID";
            SqlCommand cmdUpdate = new SqlCommand(updateEstado, con);
            cmdUpdate.Parameters.AddWithValue("@CamaID", camaID);
            cmdUpdate.ExecuteNonQuery();
        }
    }
}
