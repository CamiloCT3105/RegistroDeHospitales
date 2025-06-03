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

namespace RegistroDeHospitales.Formularios
{
    public partial class FrmPacientes : Form
    {
        private PacienteRepository repo = new PacienteRepository();
        public FrmPacientes()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = repo.Listar();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtContactoEmergencia.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    ContactoEmergencia = int.Parse(txtContactoEmergencia.Text)
                };

                repo.Agregar(paciente);
                MessageBox.Show("Paciente registrado correctamente.");
                LimpiarCampos();
                CargarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow != null)
            {
                try
                {
                    Paciente paciente = new Paciente
                    {
                        PacienteID = Convert.ToInt32(dgvPacientes.CurrentRow.Cells["PacienteID"].Value),
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        FechaNacimiento = dtpFechaNacimiento.Value,
                        ContactoEmergencia = int.Parse(txtContactoEmergencia.Text)
                    };

                    repo.Actualizar(paciente);
                    MessageBox.Show("Paciente actualizado correctamente.");
                    LimpiarCampos();
                    CargarPacientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvPacientes.CurrentRow.Cells["PacienteID"].Value);
                repo.Eliminar(id);
                MessageBox.Show("Paciente eliminado correctamente.");
                LimpiarCampos();
                CargarPacientes();
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPacientes.CurrentRow != null)
            {
                txtNombre.Text = dgvPacientes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvPacientes.CurrentRow.Cells["Apellido"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvPacientes.CurrentRow.Cells["FechaNacimiento"].Value);
                txtContactoEmergencia.Text = dgvPacientes.CurrentRow.Cells["ContactoEmergencia"].Value.ToString();
            }
        }
    }
}
