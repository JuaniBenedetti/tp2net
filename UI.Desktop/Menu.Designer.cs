
namespace UI.Desktop
{
    partial class Menu
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
            this.lMenu = new System.Windows.Forms.Label();
            this.btnMenuUsuarios = new System.Windows.Forms.Button();
            this.btnMenuCursos = new System.Windows.Forms.Button();
            this.btnMenuMaterias = new System.Windows.Forms.Button();
            this.btnMenuComisiones = new System.Windows.Forms.Button();
            this.btnMenuEspecialidad = new System.Windows.Forms.Button();
            this.btnPlanes = new System.Windows.Forms.Button();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.btnInscribir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lMenu
            // 
            this.lMenu.AutoSize = true;
            this.lMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lMenu.Location = new System.Drawing.Point(22, 21);
            this.lMenu.Name = "lMenu";
            this.lMenu.Size = new System.Drawing.Size(205, 24);
            this.lMenu.TabIndex = 0;
            this.lMenu.Text = "Seleccione una opción";
            this.lMenu.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnMenuUsuarios
            // 
            this.btnMenuUsuarios.Location = new System.Drawing.Point(53, 91);
            this.btnMenuUsuarios.Name = "btnMenuUsuarios";
            this.btnMenuUsuarios.Size = new System.Drawing.Size(125, 25);
            this.btnMenuUsuarios.TabIndex = 1;
            this.btnMenuUsuarios.Text = "Usuarios";
            this.btnMenuUsuarios.UseVisualStyleBackColor = true;
            this.btnMenuUsuarios.Click += new System.EventHandler(this.btnMenuUsuarios_Click);
            // 
            // btnMenuCursos
            // 
            this.btnMenuCursos.Location = new System.Drawing.Point(53, 122);
            this.btnMenuCursos.Name = "btnMenuCursos";
            this.btnMenuCursos.Size = new System.Drawing.Size(125, 25);
            this.btnMenuCursos.TabIndex = 2;
            this.btnMenuCursos.Text = "Cursos";
            this.btnMenuCursos.UseVisualStyleBackColor = true;
            this.btnMenuCursos.Click += new System.EventHandler(this.btnMenuCursos_Click);
            // 
            // btnMenuMaterias
            // 
            this.btnMenuMaterias.Location = new System.Drawing.Point(53, 248);
            this.btnMenuMaterias.Name = "btnMenuMaterias";
            this.btnMenuMaterias.Size = new System.Drawing.Size(125, 25);
            this.btnMenuMaterias.TabIndex = 3;
            this.btnMenuMaterias.Text = "Materias";
            this.btnMenuMaterias.UseVisualStyleBackColor = true;
            this.btnMenuMaterias.Click += new System.EventHandler(this.btnMenuMaterias_Click);
            // 
            // btnMenuComisiones
            // 
            this.btnMenuComisiones.Location = new System.Drawing.Point(53, 279);
            this.btnMenuComisiones.Name = "btnMenuComisiones";
            this.btnMenuComisiones.Size = new System.Drawing.Size(125, 25);
            this.btnMenuComisiones.TabIndex = 4;
            this.btnMenuComisiones.Text = "Comisiones";
            this.btnMenuComisiones.UseVisualStyleBackColor = true;
            this.btnMenuComisiones.Click += new System.EventHandler(this.btnMenuComisiones_Click);
            // 
            // btnMenuEspecialidad
            // 
            this.btnMenuEspecialidad.Location = new System.Drawing.Point(53, 186);
            this.btnMenuEspecialidad.Name = "btnMenuEspecialidad";
            this.btnMenuEspecialidad.Size = new System.Drawing.Size(125, 25);
            this.btnMenuEspecialidad.TabIndex = 5;
            this.btnMenuEspecialidad.Text = "Especialidad";
            this.btnMenuEspecialidad.UseVisualStyleBackColor = true;
            this.btnMenuEspecialidad.Click += new System.EventHandler(this.btnMenuEspecialidad_Click);
            // 
            // btnPlanes
            // 
            this.btnPlanes.Location = new System.Drawing.Point(53, 217);
            this.btnPlanes.Name = "btnPlanes";
            this.btnPlanes.Size = new System.Drawing.Size(125, 25);
            this.btnPlanes.TabIndex = 6;
            this.btnPlanes.Text = "Planes";
            this.btnPlanes.UseVisualStyleBackColor = true;
            this.btnPlanes.Click += new System.EventHandler(this.btnPlanes_Click);
            // 
            // btnPersonas
            // 
            this.btnPersonas.Location = new System.Drawing.Point(53, 60);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(125, 25);
            this.btnPersonas.TabIndex = 6;
            this.btnPersonas.Text = "Personas";
            this.btnPersonas.UseVisualStyleBackColor = true;
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            // 
            // btnInscribir
            // 
            this.btnInscribir.Location = new System.Drawing.Point(53, 155);
            this.btnInscribir.Name = "btnInscribir";
            this.btnInscribir.Size = new System.Drawing.Size(125, 25);
            this.btnInscribir.TabIndex = 7;
            this.btnInscribir.Text = "Inscribir alumno";
            this.btnInscribir.UseVisualStyleBackColor = true;
            this.btnInscribir.Click += new System.EventHandler(this.btnInscribir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 313);
            this.Controls.Add(this.btnPlanes);
            this.Controls.Add(this.btnInscribir);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.btnMenuEspecialidad);
            this.Controls.Add(this.btnMenuComisiones);
            this.Controls.Add(this.btnMenuMaterias);
            this.Controls.Add(this.btnMenuCursos);
            this.Controls.Add(this.btnMenuUsuarios);
            this.Controls.Add(this.lMenu);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lMenu;
        private System.Windows.Forms.Button btnMenuUsuarios;
        private System.Windows.Forms.Button btnMenuCursos;
        private System.Windows.Forms.Button btnMenuMaterias;
        private System.Windows.Forms.Button btnMenuComisiones;
        private System.Windows.Forms.Button btnMenuEspecialidad;
        private System.Windows.Forms.Button btnPlanes;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.Button btnInscribir;
    }
}