namespace RegistroDeHospitales.Formularios.FormConsultas_Tratamientos
{
    partial class FrmConsultas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_paciente = new System.Windows.Forms.Label();
            this.cmbPacientes = new System.Windows.Forms.ComboBox();
            this.cmbMedicos = new System.Windows.Forms.ComboBox();
            this.lbl_medico = new System.Windows.Forms.Label();
            this.lbl_tipo_de_consulta = new System.Windows.Forms.Label();
            this.txtTipoConsulta = new System.Windows.Forms.TextBox();
            this.lbl_fecha_consulta = new System.Windows.Forms.Label();
            this.dtpFechaConsulta = new System.Windows.Forms.DateTimePicker();
            this.btnProgramar = new System.Windows.Forms.Button();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.lbl_consultas_programadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_paciente
            // 
            this.lbl_paciente.AutoSize = true;
            this.lbl_paciente.Location = new System.Drawing.Point(161, 45);
            this.lbl_paciente.Name = "lbl_paciente";
            this.lbl_paciente.Size = new System.Drawing.Size(63, 16);
            this.lbl_paciente.TabIndex = 0;
            this.lbl_paciente.Text = "Paciente:";
            // 
            // cmbPacientes
            // 
            this.cmbPacientes.FormattingEnabled = true;
            this.cmbPacientes.Location = new System.Drawing.Point(230, 42);
            this.cmbPacientes.Name = "cmbPacientes";
            this.cmbPacientes.Size = new System.Drawing.Size(389, 24);
            this.cmbPacientes.TabIndex = 1;
            // 
            // cmbMedicos
            // 
            this.cmbMedicos.FormattingEnabled = true;
            this.cmbMedicos.Location = new System.Drawing.Point(222, 72);
            this.cmbMedicos.Name = "cmbMedicos";
            this.cmbMedicos.Size = new System.Drawing.Size(397, 24);
            this.cmbMedicos.TabIndex = 3;
            // 
            // lbl_medico
            // 
            this.lbl_medico.AutoSize = true;
            this.lbl_medico.Location = new System.Drawing.Point(161, 75);
            this.lbl_medico.Name = "lbl_medico";
            this.lbl_medico.Size = new System.Drawing.Size(55, 16);
            this.lbl_medico.TabIndex = 2;
            this.lbl_medico.Text = "Médico:";
            // 
            // lbl_tipo_de_consulta
            // 
            this.lbl_tipo_de_consulta.AutoSize = true;
            this.lbl_tipo_de_consulta.Location = new System.Drawing.Point(161, 105);
            this.lbl_tipo_de_consulta.Name = "lbl_tipo_de_consulta";
            this.lbl_tipo_de_consulta.Size = new System.Drawing.Size(112, 16);
            this.lbl_tipo_de_consulta.TabIndex = 4;
            this.lbl_tipo_de_consulta.Text = "Tipo de Consulta:";
            // 
            // txtTipoConsulta
            // 
            this.txtTipoConsulta.Location = new System.Drawing.Point(279, 102);
            this.txtTipoConsulta.Name = "txtTipoConsulta";
            this.txtTipoConsulta.Size = new System.Drawing.Size(340, 22);
            this.txtTipoConsulta.TabIndex = 5;
            // 
            // lbl_fecha_consulta
            // 
            this.lbl_fecha_consulta.AutoSize = true;
            this.lbl_fecha_consulta.Location = new System.Drawing.Point(161, 136);
            this.lbl_fecha_consulta.Name = "lbl_fecha_consulta";
            this.lbl_fecha_consulta.Size = new System.Drawing.Size(122, 16);
            this.lbl_fecha_consulta.TabIndex = 6;
            this.lbl_fecha_consulta.Text = "Fecha de Consulta:";
            // 
            // dtpFechaConsulta
            // 
            this.dtpFechaConsulta.Location = new System.Drawing.Point(289, 131);
            this.dtpFechaConsulta.Name = "dtpFechaConsulta";
            this.dtpFechaConsulta.Size = new System.Drawing.Size(330, 22);
            this.dtpFechaConsulta.TabIndex = 7;
            // 
            // btnProgramar
            // 
            this.btnProgramar.Location = new System.Drawing.Point(327, 182);
            this.btnProgramar.Name = "btnProgramar";
            this.btnProgramar.Size = new System.Drawing.Size(160, 52);
            this.btnProgramar.TabIndex = 8;
            this.btnProgramar.Text = "Programar";
            this.btnProgramar.UseVisualStyleBackColor = true;
            this.btnProgramar.Click += new System.EventHandler(this.btnProgramar_Click);
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Location = new System.Drawing.Point(62, 341);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.RowHeadersWidth = 51;
            this.dgvConsultas.RowTemplate.Height = 24;
            this.dgvConsultas.Size = new System.Drawing.Size(667, 242);
            this.dgvConsultas.TabIndex = 9;
            // 
            // lbl_consultas_programadas
            // 
            this.lbl_consultas_programadas.AutoSize = true;
            this.lbl_consultas_programadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_consultas_programadas.Location = new System.Drawing.Point(242, 298);
            this.lbl_consultas_programadas.Name = "lbl_consultas_programadas";
            this.lbl_consultas_programadas.Size = new System.Drawing.Size(320, 25);
            this.lbl_consultas_programadas.TabIndex = 10;
            this.lbl_consultas_programadas.Text = "CONSULTAS PROGRAMADAS";
            // 
            // FrmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 623);
            this.Controls.Add(this.lbl_consultas_programadas);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.btnProgramar);
            this.Controls.Add(this.dtpFechaConsulta);
            this.Controls.Add(this.lbl_fecha_consulta);
            this.Controls.Add(this.txtTipoConsulta);
            this.Controls.Add(this.lbl_tipo_de_consulta);
            this.Controls.Add(this.cmbMedicos);
            this.Controls.Add(this.lbl_medico);
            this.Controls.Add(this.cmbPacientes);
            this.Controls.Add(this.lbl_paciente);
            this.Name = "FrmConsultas";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_paciente;
        private System.Windows.Forms.ComboBox cmbPacientes;
        private System.Windows.Forms.ComboBox cmbMedicos;
        private System.Windows.Forms.Label lbl_medico;
        private System.Windows.Forms.Label lbl_tipo_de_consulta;
        private System.Windows.Forms.TextBox txtTipoConsulta;
        private System.Windows.Forms.Label lbl_fecha_consulta;
        private System.Windows.Forms.DateTimePicker dtpFechaConsulta;
        private System.Windows.Forms.Button btnProgramar;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Label lbl_consultas_programadas;
    }
}