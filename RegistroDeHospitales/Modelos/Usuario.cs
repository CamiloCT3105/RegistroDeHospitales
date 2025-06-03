using System;

namespace RegistroDeHospitales.Modelos
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Clave { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public int? IDMedico { get; set; }
    }
}
