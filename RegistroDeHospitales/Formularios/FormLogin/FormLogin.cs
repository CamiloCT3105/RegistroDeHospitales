using System;
using System.Windows.Forms;

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
            // Validación de ejemplo:
            if (txtUsuario.Text == "admin" && txtContrasena.Text == "123")
            {
                FormPrincipal principal = new FormPrincipal();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }
    }
}
