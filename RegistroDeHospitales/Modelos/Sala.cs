using System;

namespace RegistroDeHospitales.Modelos
{
    public class Sala
    {
        public int SalaID { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; } // Ej: Activa, Inactiva, Mantenimiento, etc.
    }
}

