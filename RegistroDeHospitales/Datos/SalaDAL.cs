using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RegistroDeHospitales;
using RegistroDeHospitales.Datos;
using RegistroDeHospitales.Modelos;

public class SalaDAL
{
    public List<Sala> ObtenerTodas()
    {
        var salas = new List<Sala>();

        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            con.Open();
            string query = "SELECT SalaID, Tipo, Capacidad, Estado FROM Salas";

            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    salas.Add(new Sala
                    {
                        SalaID = reader.GetInt32(0),                   // SalaID
                        Tipo = reader.GetString(1),                    // Tipo
                        Capacidad = reader.GetInt32(2),                // Capacidad
                        Estado = reader.IsDBNull(3) ? "Desconocido" : reader.GetString(3) // Estado
                    });
                }
            }
        }

        return salas;
    }

    public void Insertar(Sala sala)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            string query = "INSERT INTO Salas (Capacidad, Tipo, Estado) VALUES (@Capacidad, @Tipo, @Estado)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Capacidad", sala.Capacidad);
                cmd.Parameters.AddWithValue("@Tipo", sala.Tipo);
                cmd.Parameters.AddWithValue("@Estado", sala.Estado ?? "Activa");
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Actualizar(Sala sala)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            string query = @"UPDATE Salas SET 
                                Capacidad = @Capacidad, 
                                Tipo = @Tipo, 
                                Estado = @Estado
                             WHERE SalaID = @SalaID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Capacidad", sala.Capacidad);
                cmd.Parameters.AddWithValue("@Tipo", sala.Tipo);
                cmd.Parameters.AddWithValue("@Estado", sala.Estado);
                cmd.Parameters.AddWithValue("@SalaID", sala.SalaID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Eliminar(int salaID)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            string query = "DELETE FROM Salas WHERE SalaID = @SalaID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SalaID", salaID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
