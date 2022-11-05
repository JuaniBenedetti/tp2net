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


namespace UI.Desktop
{
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Planes_Load);
            this.dataGridViewPlanes.AutoGenerateColumns = false;

        }
           

        public void Listar()
        {
            PlanLogic el = new PlanLogic();
            this.dataGridViewPlanes.DataSource = el.GetAll();
        }
        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            // PlanesDesktop esp = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            //esp.ShowDialog();
            Listar();
        }


        private void dataGridViewPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButtonNuevo_Click_1(object sender, EventArgs e)
        {
            PlanesDesktop esp = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            esp.ShowDialog();
            Listar();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButtonEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridViewPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Plan)this.dataGridViewPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop cd = new PlanesDesktop(ApplicationForm.ModoForm.Modificacion, ID);
                cd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripButtonEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridViewPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Plan)this.dataGridViewPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop cd = new PlanesDesktop(ApplicationForm.ModoForm.Baja, ID);
                cd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
