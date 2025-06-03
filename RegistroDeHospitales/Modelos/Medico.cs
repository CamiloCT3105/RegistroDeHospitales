using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeHospitales.Modelos
{
    public class Medico
    {
        public int MedicoID { get; set; }
        public string Nombre { get; set; }
        public string Especializacion { get; set; }
        public string Horario { get; set; }
        public string Licencia { get; set; }
        public string Rol { get; set; } 
    }
}
