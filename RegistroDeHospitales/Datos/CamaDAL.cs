using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RegistroDeHospitales.Datos;
using RegistroDeHospitales.Modelos;

public class CamaDAL
{
    public DataTable ObtenerTodas()
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.CamaID, c.Codigo, c.Estado, c.SalaID FROM Camas c INNER JOIN Salas s ON c.SalaID = s.SalaID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public void Insertar(Cama cama)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            string query = "INSERT INTO Camas (Codigo, SalaID, Estado) VALUES (@Codigo, @SalaID, @Estado)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Codigo", cama.Codigo);
            cmd.Parameters.AddWithValue("@SalaID", cama.SalaID);
            cmd.Parameters.AddWithValue("@Estado", cama.Estado);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void Actualizar(Cama cama)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            string query = "UPDATE Camas SET Codigo=@Codigo, SalaID=@SalaID, Estado=@Estado WHERE CamaID=@CamaID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Codigo", cama.Codigo);
            cmd.Parameters.AddWithValue("@SalaID", cama.SalaID);
            cmd.Parameters.AddWithValue("@Estado", cama.Estado);
            cmd.Parameters.AddWithValue("@CamaID", cama.CamaID);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void Eliminar(int camaID)
    {
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            string query = "DELETE FROM Camas WHERE CamaID=@CamaID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CamaID", camaID);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public List<Cama> ObtenerPorSalaDisponibles(int salaId)
    {
        var lista = new List<Cama>();
        using (SqlConnection con = Conexion.ObtenerConexion())
        {
            con.Open();
            string query = "SELECT CamaID, Numero FROM Camas WHERE SalaID = @SalaID AND Estado = 'Disponible'";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SalaID", salaId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cama
                        {
                            CamaID = reader.GetInt32(0),
                            Numero = reader.GetString(1)
                        });
                    }
                }
            }
        }
        return lista;
    }

}
