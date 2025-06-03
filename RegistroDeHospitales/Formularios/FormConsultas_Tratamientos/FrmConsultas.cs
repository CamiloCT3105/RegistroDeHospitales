using RegistroDeHospitales.Datos;
using RegistroDeHospitales.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroDeHospitales.Formularios.FormConsultas_Tratamientos
{
    public partial class FrmConsultas : Form
    {

        private ConsultaRepository repo = new ConsultaRepository();
        public FrmConsultas()
        {
            InitializeComponent();
            CargarCombos();
            CargarConsultas();
        }

        private void CargarCombos()
        {
            var pacienteRepo = new PacienteRepository();
            cmbPacientes.DataSource = pacienteRepo.Listar();
            cmbPacientes.DisplayMember = "Nombre";
            cmbPacientes.ValueMember = "PacienteID";

            var medicoRepo = new MedicoDAL();
            cmbMedicos.DataSource = medicoRepo.ObtenerTodos();
            cmbMedicos.DisplayMember = "Nombre";
            cmbMedicos.ValueMember = "MedicoID";
        }

        private void CargarConsultas()
        {
            dgvConsultas.DataSource = null;
            dgvConsultas.DataSource = repo.Listar();
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            if (cmbPacientes.SelectedItem != null && cmbMedicos.SelectedItem != null)
            {
                Consulta c = new Consulta
                {
                    PacienteID = (int)cmbPacientes.SelectedValue,
                    MedicoID = (int)cmbMedicos.SelectedValue,
                    FechaConsulta = dtpFechaConsulta.Value,
                    TipoConsulta = txtTipoConsulta.Text
                };

                string tipoConsulta = txtTipoConsulta.Text.ToLower();
                string especialidadMedico = "";

                var medico = (Medico)cmbMedicos.SelectedItem;
                especialidadMedico = medico.Especializacion.ToLower();

                if (!tipoConsulta.Contains(especialidadMedico))
                {
                    MessageBox.Show("El médico seleccionado no tiene la especialización adecuada para esta consulta.");
                    return;
                }

                repo.ProgramarConsulta(c);
                MessageBox.Show("Consulta programada.");
                CargarConsultas();


            }
        }
    }
}
