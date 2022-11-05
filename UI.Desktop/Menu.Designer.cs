
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenuUsuarios = new System.Windows.Forms.Button();
            this.btnMenuCursos = new System.Windows.Forms.Button();
            this.btnMenuMaterias = new System.Windows.Forms.Button();
            this.btnMenuComisiones = new System.Windows.Forms.Button();
            this.btnMenuEspecialidad = new System.Windows.Forms.Button();
            this.btnPlanes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenidos, elija la opcion que desee!";
            // 
            // btnMenuUsuarios
            // 
            this.btnMenuUsuarios.Location = new System.Drawing.Point(53, 49);
            this.btnMenuUsuarios.Name = "btnMenuUsuarios";
            this.btnMenuUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnMenuUsuarios.TabIndex = 1;
            this.btnMenuUsuarios.Text = "Usuarios";
            this.btnMenuUsuarios.UseVisualStyleBackColor = true;
            this.btnMenuUsuarios.Click += new System.EventHandler(this.btnMenuUsuarios_Click);
            // 
            // btnMenuCursos
            // 
            this.btnMenuCursos.Location = new System.Drawing.Point(154, 49);
            this.btnMenuCursos.Name = "btnMenuCursos";
            this.btnMenuCursos.Size = new System.Drawing.Size(75, 23);
            this.btnMenuCursos.TabIndex = 2;
            this.btnMenuCursos.Text = "Cursos";
            this.btnMenuCursos.UseVisualStyleBackColor = true;
            this.btnMenuCursos.Click += new System.EventHandler(this.btnMenuCursos_Click);
            // 
            // btnMenuMaterias
            // 
            this.btnMenuMaterias.Location = new System.Drawing.Point(253, 49);
            this.btnMenuMaterias.Name = "btnMenuMaterias";
            this.btnMenuMaterias.Size = new System.Drawing.Size(75, 23);
            this.btnMenuMaterias.TabIndex = 3;
            this.btnMenuMaterias.Text = "Materias";
            this.btnMenuMaterias.UseVisualStyleBackColor = true;
            this.btnMenuMaterias.Click += new System.EventHandler(this.btnMenuMaterias_Click);
            // 
            // btnMenuComisiones
            // 
            this.btnMenuComisiones.Location = new System.Drawing.Point(359, 49);
            this.btnMenuComisiones.Name = "btnMenuComisiones";
            this.btnMenuComisiones.Size = new System.Drawing.Size(75, 23);
            this.btnMenuComisiones.TabIndex = 4;
            this.btnMenuComisiones.Text = "Comisiones";
            this.btnMenuComisiones.UseVisualStyleBackColor = true;
            this.btnMenuComisiones.Click += new System.EventHandler(this.btnMenuComisiones_Click);
            // 
            // btnMenuEspecialidad
            // 
            this.btnMenuEspecialidad.Location = new System.Drawing.Point(53, 92);
            this.btnMenuEspecialidad.Name = "btnMenuEspecialidad";
            this.btnMenuEspecialidad.Size = new System.Drawing.Size(75, 23);
            this.btnMenuEspecialidad.TabIndex = 5;
            this.btnMenuEspecialidad.Text = "Especialidad";
            this.btnMenuEspecialidad.UseVisualStyleBackColor = true;
            this.btnMenuEspecialidad.Click += new System.EventHandler(this.btnMenuEspecialidad_Click);
            // 
            // btnPlanes
            // 
            this.btnPlanes.Location = new System.Drawing.Point(156, 92);
            this.btnPlanes.Name = "btnPlanes";
            this.btnPlanes.Size = new System.Drawing.Size(75, 23);
            this.btnPlanes.TabIndex = 6;
            this.btnPlanes.Text = "Planes";
            this.btnPlanes.UseVisualStyleBackColor = true;
            this.btnPlanes.Click += new System.EventHandler(this.btnPlanes_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 140);
            this.Controls.Add(this.btnPlanes);
            this.Controls.Add(this.btnMenuEspecialidad);
            this.Controls.Add(this.btnMenuComisiones);
            this.Controls.Add(this.btnMenuMaterias);
            this.Controls.Add(this.btnMenuCursos);
            this.Controls.Add(this.btnMenuUsuarios);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenuUsuarios;
        private System.Windows.Forms.Button btnMenuCursos;
        private System.Windows.Forms.Button btnMenuMaterias;
        private System.Windows.Forms.Button btnMenuComisiones;
        private System.Windows.Forms.Button btnMenuEspecialidad;
        private System.Windows.Forms.Button btnPlanes;
    }
}