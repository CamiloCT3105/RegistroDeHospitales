using System;
using System.Windows.Forms;
using RegistroDeHospitales.Modelos;
using RegistroDeHospitales.Servicios;
using RegistroDeHospitales.Formularios;

namespace RegistroDeHospitales.Formularios
{
    public class FormLogin : Form
    {
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnLogin;

        public FormLogin()
        {
            this.Text = "Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(300, 200);

            Label lblUsuario = new Label() { Text = "Usuario", Left = 20, Top = 20, Width = 80 };
            txtUsuario = new TextBox() { Left = 110, Top = 20, Width = 150 };

            Label lblContrasena = new Label() { Text = "Contraseña", Left = 20, Top = 60, Width = 80 };
            txtContrasena = new TextBox() { Left = 110, Top = 60, Width = 150, UseSystemPasswordChar = true };

            btnLogin = new Button() { Text = "Iniciar Sesión", Left = 110, Top = 100, Width = 150 };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.Add(lblUsuario);
            this.Controls.Add(txtUsuario);
            this.Controls.Add(lblContrasena);
            this.Controls.Add(txtContrasena);
            this.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtContrasena.Text.Trim();

            Usuario usuarioLogueado = LoginServicio.ValidarLogin(usuario, clave);

            if (usuarioLogueado != null)
            {
                MessageBox.Show($"Bienvenido, {usuarioLogueado.NombreUsuario} (Rol: {usuarioLogueado.Rol})");

                Form formDestino;

                switch (usuarioLogueado.Rol)
                {
                    case "Admin":
                        Console.WriteLine("Funcionalidad de Admin no implementada aún.");
                        formDestino = new FormDashboardAdmin();
                        break;
                    case "Medico":
                        formDestino = new Form1();
                        Console.WriteLine("Funcionalidad de Medico no implementada aún.");
                        break;
                    case "Recepcion":
                        formDestino = new Form1();
                        Console.WriteLine("Funcionalidad de Recepción no implementada aún.");
                        break;
                    default:
                        MessageBox.Show("Rol no reconocido.");
                        return;
                }

                formDestino.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormLogin
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
