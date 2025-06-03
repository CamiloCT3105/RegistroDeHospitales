using System.Collections.Generic;
using System.Linq;

namespace RegistroDeHospitales
{
    public class SalaDAL
    {
        private static List<Sala> salas = new List<Sala>();
        private static int contador = 1;

        public List<Sala> ObtenerTodas()
        {
            return salas.ToList(); // Retorna una copia
        }

        public void Agregar(Sala sala)
        {
            sala.SalaID = contador++;
            salas.Add(sala);
        }

        public void Editar(Sala sala)
        {
            var existente = salas.FirstOrDefault(s => s.SalaID == sala.SalaID);
            if (existente != null)
            {
                existente.Nombre = sala.Nombre;
                existente.Capacidad = sala.Capacidad;
                existente.Especialidad = sala.Especialidad;
            }
        }

        public void Eliminar(int salaID)
        {
            var sala = salas.FirstOrDefault(s => s.SalaID == salaID);
            if (sala != null)
            {
                salas.Remove(sala);
            }
        }

        public Sala BuscarPorID(int salaID)
        {
            return salas.FirstOrDefault(s => s.SalaID == salaID);
        }
    }
}

