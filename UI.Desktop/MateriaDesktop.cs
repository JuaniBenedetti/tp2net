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
    public partial class MateriaDesktop : ApplicationForm
    {
        protected Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            MapearDeDatos();
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                MateriaLogic ml = new MateriaLogic();
                this.txtID.Text = (ml.NextId() + 1).ToString();
            }

            else
            {
                this.txtID.Text = this.MateriaActual.ID.ToString();
                this.txtDescripcion.Text = this.MateriaActual.Desc_materia;
                this.txtHsSemanales.Text = this.MateriaActual.Hs_semanales;
                this.txtHsTotales.Text = this.MateriaActual.Hs_totales;
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
                    Materia mate = new Materia();
                    MateriaActual = mate;
                    this.MateriaActual.State = BusinessEntity.States.New;
                }
                else this.MateriaActual.State = BusinessEntity.States.Modified;

                this.MateriaActual.Desc_materia = this.txtDescripcion.Text;
                this.MateriaActual.Hs_semanales = this.txtHsSemanales.Text;
                this.MateriaActual.Hs_totales = this.txtHsTotales.Text;
            }
            else if (this.Modo == ModoForm.Baja) this.MateriaActual.State = BusinessEntity.States.Deleted;
            else this.MateriaActual.State = BusinessEntity.States.Unmodified;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(this.MateriaActual);
        }

        public override bool Validar()
        {
            if (
                (this.txtID.Text == "") ||
                (this.txtDescripcion.Text == "") ||
                (this.txtHsSemanales.Text == "") ||
                (this.txtHsTotales.Text == "")
                )
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()) GuardarCambios();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Validar()) GuardarCambios();
            Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
