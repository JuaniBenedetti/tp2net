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
    public partial class Menu : ApplicationForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnMenuUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios ud = new Usuarios();
            ud.ShowDialog();
        }

        private void btnMenuCursos_Click(object sender, EventArgs e)
        {
            Cursos ud = new Cursos();
            ud.ShowDialog();
        }

        private void btnMenuMaterias_Click(object sender, EventArgs e)
        {
            Materias ud = new Materias();
            ud.ShowDialog();
        }

        private void btnMenuComisiones_Click(object sender, EventArgs e)
        {
            Comisiones ud = new Comisiones();
            ud.ShowDialog();
        }

        private void btnMenuEspecialidad_Click(object sender, EventArgs e)
        {
            EspecialidadesList ud = new EspecialidadesList();
            ud.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
           Planes ud = new Planes();
            ud.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas pd = new Personas();
            pd.ShowDialog();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            AlumnosInscripciones aid = new AlumnosInscripciones();
            aid.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
