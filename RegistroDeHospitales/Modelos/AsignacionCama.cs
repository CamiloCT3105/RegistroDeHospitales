// Modelos/AsignacionCama.cs
using System;

namespace RegistroDeHospitales.Modelos
{
    public class AsignacionCama
    {
        public int AsignacionID { get; set; }
        public int PacienteID { get; set; }
        public string PacienteNombre { get; set; }
        public int CamaID { get; set; }
        public string NumeroCama { get; set; }
        public int SalaID { get; set; }
        public string TipoSala { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
