using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeHospitales.Datos
{
    public class Consulta
    {
        public int ConsultaID { get; set; }
        public int PacienteID { get; set; }
        public string NombrePaciente { get; set; }
        public int MedicoID { get; set; }
        public string NombreMedico { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string TipoConsulta { get; set; }
    }
}
