using System;
using System.Windows.Forms;
using RegistroDeHospitales.Modelos;

namespace RegistroDeHospitales.Formularios
{
    public class FrmSalaDialog : Form
    {
        private TextBox txtTipo;
        private NumericUpDown nudCapacidad;
        private ComboBox cbxEstado;
        private Button btnGuardar, btnCancelar;

        public Sala Sala { get; private set; }

        public FrmSalaDialog(Sala salaExistente = null)
        {
            Sala = salaExistente ?? new Sala();
            InitializeComponents();
            if (salaExistente != null) CargarDatosExistentes();
        }

        private void InitializeComponents()
        {
            this.Text = Sala.SalaID > 0 ? "Editar Sala" : "Nueva Sala";
            this.Size = new System.Drawing.Size(300, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblTipo = new Label { Text = "Tipo:", Left = 20, Top = 20 };
            txtTipo = new TextBox { Left = 100, Top = 20, Width = 150 };

            var lblCapacidad = new Label { Text = "Capacidad:", Left = 20, Top = 60 };
            nudCapacidad = new NumericUpDown { Left = 100, Top = 60, Width = 150, Minimum = 1, Maximum = 1000 };

            var lblEstado = new Label { Text = "Estado:", Left = 20, Top = 100 };
            cbxEstado = new ComboBox { Left = 100, Top = 100, Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cbxEstado.Items.AddRange(new[] { "Disponible", "Ocupada", "Mantenimiento", "Cerrada" });

            btnGuardar = new Button { Text = "Guardar", Left = 40, Top = 150, Width = 80 };
            btnCancelar = new Button { Text = "Cancelar", Left = 150, Top = 150, Width = 80 };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] {
                lblTipo, txtTipo, lblCapacidad, nudCapacidad, lblEstado, cbxEstado,
                btnGuardar, btnCancelar
            });
        }

        private void CargarDatosExistentes()
        {
            txtTipo.Text = Sala.Tipo;
            nudCapacidad.Value = Sala.Capacidad;
            cbxEstado.SelectedItem = Sala.Estado;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmSalaDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmSalaDialog";
            this.Load += new System.EventHandler(this.FrmSalaDialog_Load);
            this.ResumeLayout(false);

        }

        private void FrmSalaDialog_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("El tipo de sala es obligatorio.");
                return;
            }

            if (cbxEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado.");
                return;
            }

            Sala.Tipo = txtTipo.Text.Trim();
            Sala.Capacidad = (int)nudCapacidad.Value;
            Sala.Estado = cbxEstado.SelectedItem.ToString();

            this.DialogResult = DialogResult.OK;
        }
    }
}
