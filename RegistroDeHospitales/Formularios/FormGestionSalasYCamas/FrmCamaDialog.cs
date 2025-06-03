using System;
using System.Windows.Forms;
using RegistroDeHospitales.Datos;
using RegistroDeHospitales.Modelos;

namespace RegistroDeHospitales.Formularios
{
    public class FrmCamaDialog : Form
    {
        private ComboBox cbxSala;
        private TextBox txtNumero;
        private ComboBox cbxEstado;
        private Button btnGuardar, btnCancelar;

        public Cama Cama { get; private set; }

        public FrmCamaDialog(Cama camaExistente = null)
        {
            Cama = camaExistente ?? new Cama();
            InitializeComponents();
            CargarSalas();
            if (camaExistente != null) CargarDatosExistentes();
        }

        private void InitializeComponents()
        {
            this.Text = Cama.CamaID > 0 ? "Editar Cama" : "Nueva Cama";
            this.Size = new System.Drawing.Size(300, 220);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblSala = new Label { Text = "Sala:", Left = 20, Top = 20 };
            cbxSala = new ComboBox { Left = 100, Top = 20, Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblNumero = new Label { Text = "Número:", Left = 20, Top = 60 };
            txtNumero = new TextBox { Left = 100, Top = 60, Width = 150 };

            var lblEstado = new Label { Text = "Estado:", Left = 20, Top = 100 };
            cbxEstado = new ComboBox { Left = 100, Top = 100, Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cbxEstado.Items.AddRange(new[] { "Disponible", "Ocupada", "Mantenimiento" });

            btnGuardar = new Button { Text = "Guardar", Left = 40, Top = 150, Width = 80 };
            btnCancelar = new Button { Text = "Cancelar", Left = 150, Top = 150, Width = 80 };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] {
                lblSala, cbxSala, lblNumero, txtNumero, lblEstado, cbxEstado,
                btnGuardar, btnCancelar
            });
        }

        private void CargarSalas()
        {
            var salaDAL = new SalaDAL();
            cbxSala.DataSource = salaDAL.ObtenerTodas();
            cbxSala.DisplayMember = "Tipo";
            cbxSala.ValueMember = "SalaID";
        }

        private void CargarDatosExistentes()
        {
            txtNumero.Text = Cama.Numero;
            cbxSala.SelectedValue = Cama.SalaID;
            cbxEstado.SelectedItem = Cama.Estado;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmCamaDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmCamaDialog";
            this.Load += new System.EventHandler(this.FrmCamaDialog_Load);
            this.ResumeLayout(false);

        }

        private void FrmCamaDialog_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cbxSala.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una sala.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("El número de cama es obligatorio.");
                return;
            }

            if (cbxEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado.");
                return;
            }

            Cama.SalaID = (int)cbxSala.SelectedValue;
            Cama.Numero = txtNumero.Text.Trim();
            Cama.Estado = cbxEstado.SelectedItem.ToString();

            this.DialogResult = DialogResult.OK;
        }
    }
}
