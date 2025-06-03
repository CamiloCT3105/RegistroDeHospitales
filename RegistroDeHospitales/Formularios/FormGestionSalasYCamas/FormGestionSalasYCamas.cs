using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RegistroDeHospitales.Datos;
using RegistroDeHospitales.Modelos;

namespace RegistroDeHospitales.Formularios
{
    public class FormGGestionSalasYCamas : Form
    {
        private readonly SalaDAL _salaDAL = new SalaDAL();
        private readonly CamaDAL _camaDAL = new CamaDAL();
        private readonly PacienteRepository _pacienteRepo = new PacienteRepository();
        private readonly AsignacionDAL _asignacionDAL = new AsignacionDAL();

        private TabControl tabControl;
        private DataGridView dgvSalas, dgvCamas, dgvAsignaciones;
        private ComboBox cbxSala, cbxCama, cbxPaciente;
        private Button btnAgregarSala, btnEditarSala, btnEliminarSala;
        private Button btnAgregarCama, btnEditarCama, btnEliminarCama;
        private Button btnAsignarCama, btnLiberarCama;

        public FormGGestionSalasYCamas()
        {
            InitializeComponents();
            LoadData();
        }

        private void InitializeComponents()
        {
            this.Text = "Gestión de Salas y Camas";
            this.Width = 1000;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl { Dock = DockStyle.Fill };

            var tabSalas = new TabPage("Salas");
            var tabCamas = new TabPage("Camas");
            var tabAsignaciones = new TabPage("Asignaciones");

            dgvSalas = CrearDataGridView();
            dgvCamas = CrearDataGridView();
            dgvAsignaciones = CrearDataGridView();

            tabSalas.Controls.Add(AgregarSeccionSalas());
            tabCamas.Controls.Add(AgregarSeccionCamas());
            tabAsignaciones.Controls.Add(AgregarSeccionAsignaciones());

            tabControl.TabPages.AddRange(new[] { tabSalas, tabCamas, tabAsignaciones });
            this.Controls.Add(tabControl);
        }

        private Control AgregarSeccionSalas()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 50 };

            btnAgregarSala = new Button { Text = "Agregar Sala" };
            btnEditarSala = new Button { Text = "Editar Sala" };
            btnEliminarSala = new Button { Text = "Eliminar Sala" };

            btnAgregarSala.Click += (s, e) => AgregarSala();
            btnEditarSala.Click += (s, e) => EditarSala();
            btnEliminarSala.Click += (s, e) => EliminarSala();

            btnPanel.Controls.AddRange(new Control[] { btnAgregarSala, btnEditarSala, btnEliminarSala });

            panel.Controls.Add(dgvSalas);
            panel.Controls.Add(btnPanel);

            return panel;
        }

        private Control AgregarSeccionCamas()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 50 };

            btnAgregarCama = new Button { Text = "Agregar Cama" };
            btnEditarCama = new Button { Text = "Editar Cama" };
            btnEliminarCama = new Button { Text = "Eliminar Cama" };

            btnAgregarCama.Click += (s, e) => AgregarCama();
            btnEditarCama.Click += (s, e) => EditarCama();
            btnEliminarCama.Click += (s, e) => EliminarCama();

            btnPanel.Controls.AddRange(new Control[] { btnAgregarCama, btnEditarCama, btnEliminarCama });

            panel.Controls.Add(dgvCamas);
            panel.Controls.Add(btnPanel);

            return panel;
        }

        private Control AgregarSeccionAsignaciones()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var controlPanel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 80, AutoSize = true };

            cbxSala = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbxCama = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbxPaciente = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            btnAsignarCama = new Button { Text = "Asignar Cama" };
            btnLiberarCama = new Button { Text = "Liberar Cama" };

            cbxSala.SelectedIndexChanged += (s, e) => CargarCamasDisponibles();
            btnAsignarCama.Click += (s, e) => AsignarCama();
            btnLiberarCama.Click += (s, e) => LiberarCama();

            controlPanel.Controls.AddRange(new Control[] {
                new Label { Text = "Sala:" }, cbxSala,
                new Label { Text = "Cama:" }, cbxCama,
                new Label { Text = "Paciente:" }, cbxPaciente,
                btnAsignarCama, btnLiberarCama
            });

            panel.Controls.Add(controlPanel);
            panel.Controls.Add(dgvAsignaciones);
            dgvAsignaciones.Dock = DockStyle.Fill;

            return panel;
        }

        private void LoadData()
        {
            CargarSalas();
            CargarCamas();
            CargarAsignaciones();
            CargarSalasEnComboBox();
            CargarPacientes();
        }

        private DataGridView CrearDataGridView()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoGenerateColumns = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
        }

        private void CargarSalas()
        {
            dgvSalas.DataSource = _salaDAL.ObtenerTodas();
        }

        private void CargarCamas()
        {
            dgvCamas.DataSource = _camaDAL.ObtenerTodas();
        }

        private void CargarAsignaciones()
        {
            dgvAsignaciones.DataSource = _asignacionDAL.ObtenerTodas();
        }

        private void CargarSalasEnComboBox()
        {
            cbxSala.DataSource = _salaDAL.ObtenerTodas();
            cbxSala.DisplayMember = "Tipo";
            cbxSala.ValueMember = "SalaID";
        }

        private void CargarCamasDisponibles()
        {
            if (cbxSala.SelectedValue is int salaId)
            {
                cbxCama.DataSource = _camaDAL.ObtenerPorSalaDisponibles(salaId);
                cbxCama.DisplayMember = "Numero";
                cbxCama.ValueMember = "CamaID";
            }
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormGestionSalasYCamas
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormGestionSalasYCamas";
            this.Load += new System.EventHandler(this.FormGestionSalasYCamas_Load);
            this.ResumeLayout(false);

        }

        private void FormGestionSalasYCamas_Load(object sender, EventArgs e)
        {

        }

        private void CargarPacientes()
        {
            cbxPaciente.DataSource = _pacienteRepo.ObtenerTodos();
            cbxPaciente.DisplayMember = "NombreCompleto";
            cbxPaciente.ValueMember = "PacienteID";
        }

        private void AgregarSala()
        {
            var frm = new FrmSalaDialog(); // puedes implementar un formulario modal
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _salaDAL.Insertar(frm.Sala);
                CargarSalas();
                CargarSalasEnComboBox();
            }
        }

        private void EditarSala()
        {
            if (dgvSalas.CurrentRow?.DataBoundItem is Sala sala)
            {
                var frm = new FrmSalaDialog(sala);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _salaDAL.Actualizar(frm.Sala);
                    CargarSalas();
                }
            }
        }

        private void EliminarSala()
        {
            if (dgvSalas.CurrentRow?.DataBoundItem is Sala sala)
            {
                if (MessageBox.Show("¿Eliminar esta sala?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _salaDAL.Eliminar(sala.SalaID);
                    CargarSalas();
                    CargarSalasEnComboBox();
                }
            }
        }

        private void AgregarCama()
        {
            var frm = new FrmCamaDialog();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _camaDAL.Insertar(frm.Cama);
                CargarCamas();
            }
        }

        private void EditarCama()
        {
            if (dgvCamas.CurrentRow?.DataBoundItem is Cama cama)
            {
                var frm = new FrmCamaDialog(cama);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _camaDAL.Actualizar(frm.Cama);
                    CargarCamas();
                }
            }
        }

        private void EliminarCama()
        {
            if (dgvCamas.CurrentRow?.DataBoundItem is Cama cama)
            {
                if (MessageBox.Show("¿Eliminar esta cama?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _camaDAL.Eliminar(cama.CamaID);
                    CargarCamas();
                }
            }
        }

        private void AsignarCama()
        {
            if (cbxCama.SelectedValue is int camaId && cbxPaciente.SelectedValue is int pacienteId)
            {
                _asignacionDAL.AsignarCamaPaciente(pacienteId, camaId);
                CargarAsignaciones();
                CargarCamasDisponibles();
            }
        }

        private void LiberarCama()
        {
            if (dgvAsignaciones.CurrentRow?.DataBoundItem is AsignacionCama asignacion)
            {
                if (MessageBox.Show("¿Liberar esta cama?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _asignacionDAL.LiberarCama(asignacion.AsignacionID); // 🟢 CORRECTO
                    CargarAsignaciones();
                    CargarCamasDisponibles();
                }
            }
        }

    }
}
