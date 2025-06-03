using System;
using System.Drawing;
using System.Windows.Forms;
using RegistroDeHospitales.Modelos;
using RegistroDeHospitales.Datos;
using System.Linq;

namespace RegistroDeHospitales.Formularios
{
    public class Form1 : Form
    {
        private TextBox txtMedicoID, txtNombre, txtEspecializacion, txtHorario, txtLicencia;
        private ComboBox cboRol;
        private Button btnAgregar, btnEditar, btnEliminar, btnLimpiar;
        private DataGridView dgvMedicos;
        private MedicoDAL dal = new MedicoDAL();
        private Button btnAsignarPersonal;

        public Form1()
        {
            this.Text = "Gestión de Personal Médico";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);

            InicializarControles();
            CargarDatos();
        }

        private void InicializarControles()
        {
            Label lblID = new Label() { Text = "ID", Left = 20, Top = 20 };
            txtMedicoID = new TextBox() { Left = 150, Top = 20, Width = 200, Enabled = false };

            Label lblNombre = new Label() { Text = "Nombre", Left = 20, Top = 60 };
            txtNombre = new TextBox() { Left = 150, Top = 60, Width = 200 };

            Label lblEspecializacion = new Label() { Text = "Especialización", Left = 20, Top = 100 };
            txtEspecializacion = new TextBox() { Left = 150, Top = 100, Width = 200 };

            Label lblHorario = new Label() { Text = "Horario", Left = 20, Top = 140 };
            txtHorario = new TextBox() { Left = 150, Top = 140, Width = 200 };

            Label lblLicencia = new Label() { Text = "Licencia", Left = 20, Top = 180 };
            txtLicencia = new TextBox() { Left = 150, Top = 180, Width = 200 };

            Label lblRol = new Label() { Text = "Rol", Left = 20, Top = 220 };
            cboRol = new ComboBox() { Left = 150, Top = 220, Width = 200 };
            cboRol.Items.AddRange(new string[] { "Medico", "Enfermero", "Otro" });
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.SelectedIndex = 0;

            btnAgregar = new Button() { Text = "Agregar", Left = 400, Top = 20 };
            btnEditar = new Button() { Text = "Editar", Left = 400, Top = 60 };
            btnEliminar = new Button() { Text = "Eliminar", Left = 400, Top = 100 };
            btnLimpiar = new Button() { Text = "Limpiar", Left = 400, Top = 140 };

            dgvMedicos = new DataGridView()
            {
                Left = 20,
                Top = 270,
                Width = 740,
                Height = 250,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar.Click += (s, e) => LimpiarCampos();
            dgvMedicos.CellClick += DgvMedicos_CellClick;

            this.Controls.AddRange(new Control[] {
                lblID, txtMedicoID, lblNombre, txtNombre,
                lblEspecializacion, txtEspecializacion, lblHorario, txtHorario,
                lblLicencia, txtLicencia, lblRol, cboRol,
                btnAgregar, btnEditar, btnEliminar, btnLimpiar,
                dgvMedicos
            });

            btnAsignarPersonal = new Button();
            btnAsignarPersonal.Text = "Asignar Médico a Paciente";
            btnAsignarPersonal.Location = new System.Drawing.Point(600, 50); // ajusta posición
            btnAsignarPersonal.Click += BtnAbrirFormAsignar_Click;
            this.Controls.Add(btnAsignarPersonal);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            try
            {
                dgvMedicos.DataSource = null;
                dgvMedicos.DataSource = dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var medico = new Medico
                {
                    Nombre = txtNombre.Text,
                    Especializacion = txtEspecializacion.Text,
                    Horario = txtHorario.Text,
                    Licencia = txtLicencia.Text,
                    Rol = cboRol.SelectedItem.ToString()
                };

                dal.Insertar(medico);
                CargarDatos();
                LimpiarCampos();
                MessageBox.Show("Personal agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicoID.Text))
            {
                MessageBox.Show("Seleccione un registro para editar.");
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                var medico = new Medico
                {
                    MedicoID = int.Parse(txtMedicoID.Text),
                    Nombre = txtNombre.Text,
                    Especializacion = txtEspecializacion.Text,
                    Horario = txtHorario.Text,
                    Licencia = txtLicencia.Text,
                    Rol = cboRol.SelectedItem.ToString()
                };

                dal.Actualizar(medico);
                CargarDatos();
                LimpiarCampos();
                MessageBox.Show("Registro actualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicoID.Text))
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
                return;
            }

            try
            {
                int id = int.Parse(txtMedicoID.Text);
                dal.Eliminar(id);
                CargarDatos();
                LimpiarCampos();
                MessageBox.Show("Registro eliminado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void DgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMedicos.CurrentRow != null)
            {
                var row = dgvMedicos.CurrentRow;
                txtMedicoID.Text = row.Cells["MedicoID"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtEspecializacion.Text = row.Cells["Especializacion"].Value.ToString();
                txtHorario.Text = row.Cells["Horario"].Value.ToString();
                txtLicencia.Text = row.Cells["Licencia"].Value.ToString();
                cboRol.SelectedItem = row.Cells["Rol"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtMedicoID.Clear();
            txtNombre.Clear();
            txtEspecializacion.Clear();
            txtHorario.Clear();
            txtLicencia.Clear();
            cboRol.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEspecializacion.Text) ||
                string.IsNullOrWhiteSpace(txtHorario.Text) ||
                string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Todos los campos deben estar completos.");
                return false;
            }
            return true;
        }

        private void BtnAbrirFormAsignar_Click(object sender, EventArgs e)
        {
            FormAsignarPersonal formAsignar = new FormAsignarPersonal();
            formAsignar.ShowDialog();
        }
    }
}
