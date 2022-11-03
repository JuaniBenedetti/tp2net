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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
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
    }
}
