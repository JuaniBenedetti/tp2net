using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class EspecialidadesList : ApplicationForm
    {
        public EspecialidadesList()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.EspecialidadesDesktop_Load);
            this.dataGridView1.AutoGenerateColumns = false;
        }

        public void Listar ()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dataGridView1.DataSource = el.GetAll();
        }
        private void EspecialidadesDesktop_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop esp = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            esp.ShowDialog();
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Especialidades)this.dataGridView1.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop cd = new EspecialidadDesktop(ApplicationForm.ModoForm.Modificacion, ID);
                cd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Especialidades)this.dataGridView1.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop cd = new EspecialidadDesktop(ApplicationForm.ModoForm.Baja, ID);
                cd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
