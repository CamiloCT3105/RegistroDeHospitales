using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeHospitales.Entidades
{
    public class Paciente
    {
        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int ContactoEmergencia { get; set; }
    }
}
