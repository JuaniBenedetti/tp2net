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
    public partial class CursoDesktop : ApplicationForm
    {
        protected Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }
        public CursoDesktop()
        {
            InitializeComponent();
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            MapearDeDatos();
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic ml = new CursoLogic();
            CursoActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                CursoLogic ml = new CursoLogic();
                this.txtID.Text = (ml.NextId() + 1).ToString();
            }

            else
            {
                this.txtID.Text = this.CursoActual.ID.ToString();
              
                this.txtAño_calendario.Text = this.CursoActual.Año_calendario.ToString();
                this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion) this.btnAceptar.Text = "Guardar";
            else if (this.Modo == ModoForm.Baja) this.btnAceptar.Text = "Eliminar";
            else this.btnAceptar.Text = "Aceptar";
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    Curso cur = new Curso();
                    CursoActual = cur;
                    this.CursoActual.State = BusinessEntity.States.New;
                }
                else this.CursoActual.State = BusinessEntity.States.Modified;

              
                this.CursoActual.Año_calendario = Int32.Parse(this.txtAño_calendario.Text);
                this.CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
            }
            else if (this.Modo == ModoForm.Baja) this.CursoActual.State = BusinessEntity.States.Deleted;
            else this.CursoActual.State = BusinessEntity.States.Unmodified;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic ml = new CursoLogic();
            ml.Save(this.CursoActual);
        }

        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }
        public override bool Validar()
        {
            if (
                (this.txtID.Text == "") ||
                
                (this.txtAño_calendario.Text == "") ||
                (this.txtCupo.Text == "")
                )
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CursoDesktop_Load(object sender, EventArgs e)
        {

        }

        private void txtID_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
