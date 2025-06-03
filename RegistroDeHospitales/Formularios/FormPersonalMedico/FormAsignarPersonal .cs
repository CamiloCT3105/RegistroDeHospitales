using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RegistroDeHospitales.Datos;

namespace RegistroDeHospitales.Formularios
{
    public class FormAsignarPersonal : Form
    {
        private ComboBox cmbPacientes;
        private ComboBox cmbMedicos;
        private Button btnAsignar;
        private MedicoDAL medicoDAL;

        public FormAsignarPersonal()
        {
            this.Text = "Asignar Personal Médico a Paciente";
            this.Size = new System.Drawing.Size(500, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblPaciente = new Label { Text = "Paciente:", Location = new System.Drawing.Point(30, 30), AutoSize = true };
            cmbPacientes = new ComboBox { Location = new System.Drawing.Point(100, 30), Width = 300 };

            Label lblMedico = new Label { Text = "Médico:", Location = new System.Drawing.Point(30, 70), AutoSize = true };
            cmbMedicos = new ComboBox { Location = new System.Drawing.Point(100, 70), Width = 300 };

            btnAsignar = new Button { Text = "Asignar", Location = new System.Drawing.Point(200, 110) };
            btnAsignar.Click += BtnAsignar_Click;

            this.Controls.Add(lblPaciente);
            this.Controls.Add(cmbPacientes);
            this.Controls.Add(lblMedico);
            this.Controls.Add(cmbMedicos);
            this.Controls.Add(btnAsignar);

            medicoDAL = new MedicoDAL();

            CargarPacientes();
            CargarMedicos();
        }

        private void CargarPacientes()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT PacienteID, Nombre + ' ' + Apellido AS NombreCompleto FROM Pacientes", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbPacientes.DataSource = dt;
                cmbPacientes.DisplayMember = "NombreCompleto";
                cmbPacientes.ValueMember = "PacienteID";
            }
        }

        private void CargarMedicos()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MedicoID, Nombre FROM PersonalMedico", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMedicos.DataSource = dt;
                cmbMedicos.DisplayMember = "Nombre";
                cmbMedicos.ValueMember = "MedicoID";
            }
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                int pacienteId = Convert.ToInt32(cmbPacientes.SelectedValue);
                int medicoId = Convert.ToInt32(cmbMedicos.SelectedValue);

                medicoDAL.AsignarMedicoAPaciente(medicoId, pacienteId);

                MessageBox.Show("Médico asignado correctamente al paciente y registrado en el historial.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormAsignarPersonal
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormAsignarPersonal";
            this.Load += new System.EventHandler(this.FormAsignarPersonal_Load);
            this.ResumeLayout(false);

        }

        private void FormAsignarPersonal_Load(object sender, EventArgs e)
        {

        }
    }
}
