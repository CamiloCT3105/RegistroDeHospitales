using System;

    namespace RegistroDeHospitales.Modelos
{
    public class Cama
    {
        public int CamaID { get; set; }
        public string Numero { get; set; }
        public string Especializacion { get; set; } // General, UCI, etc.
        public string Estado { get; set; } // Disponible / Ocupada
        public int SalaID { get; set; } // Relación con sala
        public string Codigo { get; internal set; }
    }
}

