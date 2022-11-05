
namespace UI.Desktop
{
    partial class AlumnosInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnosInscripciones));
            this.tscInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlpInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvInscripciones = new System.Windows.Forms.DataGridView();
            this.id_alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsInscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscInscripciones.ContentPanel.SuspendLayout();
            this.tscInscripciones.TopToolStripPanel.SuspendLayout();
            this.tscInscripciones.SuspendLayout();
            this.tlpInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).BeginInit();
            this.tsInscripciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscInscripciones
            // 
            // 
            // tscInscripciones.ContentPanel
            // 
            this.tscInscripciones.ContentPanel.Controls.Add(this.tlpInscripciones);
            this.tscInscripciones.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tscInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tscInscripciones.Name = "tscInscripciones";
            this.tscInscripciones.Size = new System.Drawing.Size(800, 450);
            this.tscInscripciones.TabIndex = 0;
            this.tscInscripciones.Text = "toolStripContainer1";
            // 
            // tscInscripciones.TopToolStripPanel
            // 
            this.tscInscripciones.TopToolStripPanel.Controls.Add(this.tsInscripciones);
            // 
            // tlpInscripciones
            // 
            this.tlpInscripciones.ColumnCount = 2;
            this.tlpInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInscripciones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlpInscripciones.Controls.Add(this.btnSalir, 1, 1);
            this.tlpInscripciones.Controls.Add(this.dgvInscripciones, 0, 0);
            this.tlpInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlpInscripciones.Name = "tlpInscripciones";
            this.tlpInscripciones.RowCount = 2;
            this.tlpInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInscripciones.Size = new System.Drawing.Size(800, 425);
            this.tlpInscripciones.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(641, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvInscripciones
            // 
            this.dgvInscripciones.AllowUserToAddRows = false;
            this.dgvInscripciones.AllowUserToDeleteRows = false;
            this.dgvInscripciones.AllowUserToResizeColumns = false;
            this.dgvInscripciones.AllowUserToResizeRows = false;
            this.dgvInscripciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_alumno,
            this.id_curso,
            this.condicion,
            this.nota});
            this.tlpInscripciones.SetColumnSpan(this.dgvInscripciones, 2);
            this.dgvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripciones.Location = new System.Drawing.Point(3, 3);
            this.dgvInscripciones.MultiSelect = false;
            this.dgvInscripciones.Name = "dgvInscripciones";
            this.dgvInscripciones.ReadOnly = true;
            this.dgvInscripciones.RowHeadersVisible = false;
            this.dgvInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripciones.Size = new System.Drawing.Size(794, 390);
            this.dgvInscripciones.TabIndex = 2;
            this.dgvInscripciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInscripciones_CellFormatting);
            // 
            // id_alumno
            // 
            this.id_alumno.DataPropertyName = "IDAlumno";
            this.id_alumno.HeaderText = "ID Alumno";
            this.id_alumno.Name = "id_alumno";
            this.id_alumno.ReadOnly = true;
            // 
            // id_curso
            // 
            this.id_curso.DataPropertyName = "IDCurso";
            this.id_curso.HeaderText = "ID Curso";
            this.id_curso.Name = "id_curso";
            this.id_curso.ReadOnly = true;
            // 
            // condicion
            // 
            this.condicion.DataPropertyName = "Condicion";
            this.condicion.HeaderText = "Condicion";
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            // 
            // nota
            // 
            this.nota.DataPropertyName = "Nota";
            this.nota.HeaderText = "Nota";
            this.nota.Name = "nota";
            this.nota.ReadOnly = true;
            // 
            // tsInscripciones
            // 
            this.tsInscripciones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsInscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsInscripciones.Location = new System.Drawing.Point(3, 0);
            this.tsInscripciones.Name = "tsInscripciones";
            this.tsInscripciones.Size = new System.Drawing.Size(81, 25);
            this.tsInscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // AlumnosInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscInscripciones);
            this.Name = "AlumnosInscripciones";
            this.Text = "Inscripcion a cursado";
            this.Load += new System.EventHandler(this.alumnosInscripciones_Load);
            this.tscInscripciones.ContentPanel.ResumeLayout(false);
            this.tscInscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tscInscripciones.TopToolStripPanel.PerformLayout();
            this.tscInscripciones.ResumeLayout(false);
            this.tscInscripciones.PerformLayout();
            this.tlpInscripciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).EndInit();
            this.tsInscripciones.ResumeLayout(false);
            this.tsInscripciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscInscripciones;
        private System.Windows.Forms.TableLayoutPanel tlpInscripciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvInscripciones;
        private System.Windows.Forms.ToolStrip tsInscripciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}