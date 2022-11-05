using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Personas : ApplicationForm
    {
        public Personas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource = pl.GetAll();
        }

        private void personas_Load(object sender, EventArgs e)
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
            PersonaDesktop pd = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                pd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvPersonas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (Convert.ToInt32(this.dgvPersonas.Rows[e.RowIndex].Cells[8].Value) == 1) { e.Value = "ALUMNO"; }
                else { e.Value = "PROFESOR"; }
            }
        }
    }
}
