using System;
using System.Windows.Forms;

namespace RegistroDeHospitales.Formularios
{
    public class FormDashboardAdmin : Form
    {
        private Button btnPacientes;
        private Button btnPersonalMedico;
        private Button btnAsignarCamas;
        private Button btnHistorial;
        private Button btnCerrarSesion;

        public FormDashboardAdmin()
        {
            this.Text = "Dashboard Administrador";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(400, 300);

            InicializarControles();
        }

        private void InicializarControles()
        {
            btnPacientes = new Button()
            {
                Text = "Gestión de Pacientes",
                Left = 50,
                Top = 30,
                Width = 250
            };
            btnPacientes.Click += (s, e) =>
            {
                FrmPacientes frm = new FrmPacientes();
                frm.ShowDialog();
            };

            btnPersonalMedico = new Button()
            {
                Text = "Gestión de Personal Médico",
                Left = 50,
                Top = 70,
                Width = 250
            };
            btnPersonalMedico.Click += (s, e) =>
            {
                Form1 frm = new Form1(); // Tu formulario de médicos
                frm.ShowDialog();
            };

            btnAsignarCamas = new Button()
            {
                Text = "Asignación de Salas y Camas",
                Left = 50,
                Top = 110,
                Width = 250
            };
            btnAsignarCamas.Click += (s, e) =>
            {
                FormGGestionSalasYCamas frm = new FormGGestionSalasYCamas();
                frm.ShowDialog();
            };

            btnHistorial = new Button()
            {
                Text = "Ver Historial Médico",
                Left = 50,
                Top = 150,
                Width = 250
            };
            btnHistorial.Click += (s, e) =>
            {
                MessageBox.Show("Funcionalidad de historial médico pendiente.");
            };

            btnCerrarSesion = new Button()
            {
                Text = "Cerrar Sesión",
                Left = 50,
                Top = 200,
                Width = 250
            };
            btnCerrarSesion.Click += (s, e) =>
            {
                this.Close(); // Opcional: podrías regresar al login
                Application.Restart(); // Reinicia la app para volver al login
            };

            this.Controls.AddRange(new Control[]
            {
                btnPacientes,
                btnPersonalMedico,
                btnAsignarCamas,
                btnHistorial,
                btnCerrarSesion
            });
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DashboardAdmin
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "DashboardAdmin";
            this.Load += new System.EventHandler(this.DashboardAdmin_Load);
            this.ResumeLayout(false);

        }

        private void DashboardAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
