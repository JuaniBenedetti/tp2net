using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class AlumnosInscripciones : ApplicationForm
    {
        public AlumnosInscripciones()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            this.dgvInscripciones.DataSource = ail.GetAll();
        }

        private void alumnosInscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop aid = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            aid.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count > 0)
            {
                int ID = ((AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop aid = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                aid.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count > 0)
            {
                int ID = ((AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop aid = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                aid.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvInscripciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Convert.ToInt32(this.dgvInscripciones.Rows[e.RowIndex].Cells[3].Value) == 0) { e.Value = "-"; }
            }
        }
    }
}
