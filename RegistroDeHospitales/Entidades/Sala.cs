using System;

namespace RegistroDeHospitales
{
    public class Sala
    {
        public int SalaID { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Especialidad { get; set; } // General, UCI, Intermedios
    }
}
