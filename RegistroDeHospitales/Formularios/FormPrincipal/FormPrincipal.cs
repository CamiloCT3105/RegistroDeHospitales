using System;
using System.Windows.Forms;

namespace RegistroDeHospitales.Formularios
{
    public class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            this.Text = "Vista Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(800, 600);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
