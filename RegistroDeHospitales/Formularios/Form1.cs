using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalMedicoApp.Modelos;
using PersonalMedicoApp.Datos;

namespace RegistroDeHospitales.Formularios
{
    public partial class Form1 : Form
    {

        private MedicoDAL dal = new MedicoDAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            dgvMedicos.DataSource = dal.ObtenerTodos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void Limpiar()
        {
            txtMedicoID.Clear();
            txtNombre.Clear();
            txtEspecializacion.Clear();
            txtHorario.Clear();
            txtLicencia.Clear();
        } 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Medico m = new Medico
            {
                Nombre = txtNombre.Text,
                Especializacion = txtEspecializacion.Text,
                Horario = txtHorario.Text,
                Licencia = txtLicencia.Text
            };

            dal.Insertar(m);
            CargarDatos();
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Medico m = new Medico
            {
                MedicoID = int.Parse(txtMedicoID.Text),
                Nombre = txtNombre.Text,
                Especializacion = txtEspecializacion.Text,
                Horario = txtHorario.Text,
                Licencia = txtLicencia.Text
            };

            dal.Actualizar(m);
            CargarDatos();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMedicoID.Text);
            dal.Eliminar(id);
            CargarDatos();
            Limpiar();
        }

        private void dgvMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}
