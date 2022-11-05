
namespace UI.Desktop
{
    partial class AlumnoInscripcionDesktop
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
            this.tlpInscripcion = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lIDAlumno = new System.Windows.Forms.Label();
            this.lIDCurso = new System.Windows.Forms.Label();
            this.lCondicion = new System.Windows.Forms.Label();
            this.lNota = new System.Windows.Forms.Label();
            this.txtIDAlumno = new System.Windows.Forms.TextBox();
            this.cbCondicion = new System.Windows.Forms.ComboBox();
            this.txtIDCurso = new System.Windows.Forms.TextBox();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.tlpInscripcion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpInscripcion
            // 
            this.tlpInscripcion.ColumnCount = 4;
            this.tlpInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInscripcion.Controls.Add(this.btnAceptar, 2, 2);
            this.tlpInscripcion.Controls.Add(this.btnCancelar, 3, 2);
            this.tlpInscripcion.Controls.Add(this.lIDAlumno, 0, 0);
            this.tlpInscripcion.Controls.Add(this.lIDCurso, 0, 1);
            this.tlpInscripcion.Controls.Add(this.lCondicion, 2, 0);
            this.tlpInscripcion.Controls.Add(this.lNota, 2, 1);
            this.tlpInscripcion.Controls.Add(this.txtIDAlumno, 1, 0);
            this.tlpInscripcion.Controls.Add(this.cbCondicion, 3, 0);
            this.tlpInscripcion.Controls.Add(this.txtIDCurso, 1, 1);
            this.tlpInscripcion.Controls.Add(this.txtNota, 3, 1);
            this.tlpInscripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInscripcion.Location = new System.Drawing.Point(0, 0);
            this.tlpInscripcion.Name = "tlpInscripcion";
            this.tlpInscripcion.RowCount = 3;
            this.tlpInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInscripcion.Size = new System.Drawing.Size(451, 98);
            this.tlpInscripcion.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.Location = new System.Drawing.Point(214, 72);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(295, 72);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lIDAlumno
            // 
            this.lIDAlumno.AutoSize = true;
            this.lIDAlumno.Location = new System.Drawing.Point(3, 0);
            this.lIDAlumno.Name = "lIDAlumno";
            this.lIDAlumno.Size = new System.Drawing.Size(56, 13);
            this.lIDAlumno.TabIndex = 2;
            this.lIDAlumno.Text = "ID Alumno";
            // 
            // lIDCurso
            // 
            this.lIDCurso.AutoSize = true;
            this.lIDCurso.Location = new System.Drawing.Point(3, 27);
            this.lIDCurso.Name = "lIDCurso";
            this.lIDCurso.Size = new System.Drawing.Size(48, 13);
            this.lIDCurso.TabIndex = 3;
            this.lIDCurso.Text = "ID Curso";
            // 
            // lCondicion
            // 
            this.lCondicion.AutoSize = true;
            this.lCondicion.Location = new System.Drawing.Point(214, 0);
            this.lCondicion.Name = "lCondicion";
            this.lCondicion.Size = new System.Drawing.Size(54, 13);
            this.lCondicion.TabIndex = 4;
            this.lCondicion.Text = "Condicion";
            // 
            // lNota
            // 
            this.lNota.AutoSize = true;
            this.lNota.Location = new System.Drawing.Point(214, 27);
            this.lNota.Name = "lNota";
            this.lNota.Size = new System.Drawing.Size(30, 13);
            this.lNota.TabIndex = 5;
            this.lNota.Text = "Nota";
            // 
            // txtIDAlumno
            // 
            this.txtIDAlumno.Location = new System.Drawing.Point(65, 3);
            this.txtIDAlumno.Name = "txtIDAlumno";
            this.txtIDAlumno.Size = new System.Drawing.Size(143, 20);
            this.txtIDAlumno.TabIndex = 11;
            // 
            // cbCondicion
            // 
            this.cbCondicion.FormattingEnabled = true;
            this.cbCondicion.Items.AddRange(new object[] {
            "Inscripto",
            "Regular",
            "Aprobado",
            "Recursante"});
            this.cbCondicion.Location = new System.Drawing.Point(295, 3);
            this.cbCondicion.Name = "cbCondicion";
            this.cbCondicion.Size = new System.Drawing.Size(143, 21);
            this.cbCondicion.TabIndex = 20;
            this.cbCondicion.Text = "Inscripto";
            // 
            // txtIDCurso
            // 
            this.txtIDCurso.Location = new System.Drawing.Point(65, 30);
            this.txtIDCurso.Name = "txtIDCurso";
            this.txtIDCurso.Size = new System.Drawing.Size(143, 20);
            this.txtIDCurso.TabIndex = 21;
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(295, 30);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(143, 20);
            this.txtNota.TabIndex = 22;
            // 
            // AlumnoInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 98);
            this.Controls.Add(this.tlpInscripcion);
            this.Name = "AlumnoInscripcionDesktop";
            this.Text = "Inscripcion";
            this.tlpInscripcion.ResumeLayout(false);
            this.tlpInscripcion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpInscripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lIDAlumno;
        private System.Windows.Forms.Label lIDCurso;
        private System.Windows.Forms.Label lCondicion;
        private System.Windows.Forms.Label lNota;
        private System.Windows.Forms.TextBox txtIDAlumno;
        private System.Windows.Forms.ComboBox cbCondicion;
        private System.Windows.Forms.TextBox txtIDCurso;
        private System.Windows.Forms.TextBox txtNota;
    }
}