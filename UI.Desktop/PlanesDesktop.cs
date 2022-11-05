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
    public partial class PlanesDesktop : ApplicationForm
    {
        protected Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public PlanesDesktop()
        {
            InitializeComponent();
        }
        public PlanesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            MapearDeDatos();
        }
        public PlanesDesktop(ModoForm modo, int id) : this()
        {
            Modo = modo;
            PlanLogic esp = new PlanLogic();
            this.PlanActual = esp.getOne(id);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                PlanLogic cl = new PlanLogic();
                this.textBoxID.Text = (cl.NextId() + 1).ToString();
            }

            else
            {
                this.textBoxID.Text = this.PlanActual.ID.ToString();
                this.textBoxDesc.Text = this.PlanActual.DescPlan;
                this.textBoxIDEsp.Text = this.PlanActual.IdEspecialidad.ToString();

            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion) this.btnAceptar.Text = "Guardar";
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.textBoxDesc.Enabled = true;
            }
            else this.btnAceptar.Text = "Aceptar";
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    Plan com = new Plan();
                    PlanActual = com;
                    this.PlanActual.State = BusinessEntity.States.New;
                }
                else this.PlanActual.State = BusinessEntity.States.Modified;

                this.PlanActual.DescPlan = this.textBoxDesc.Text;
                this.PlanActual.ID = Int32.Parse(this.textBoxID.Text);
                this.PlanActual.IdEspecialidad = Int32.Parse(this.textBoxIDEsp.Text);
            }
            else if (this.Modo == ModoForm.Baja) this.PlanActual.State = BusinessEntity.States.Deleted;
            else this.PlanActual.State = BusinessEntity.States.Unmodified;
        }

        public override bool Validar()
        {
            if (this.textBoxDesc.Text != "")
            {
                return true;
            }
            else
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PlanLogic esp = new PlanLogic();
                esp.Save(this.PlanActual);
            }
            catch (Exception ex)
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Validar()) GuardarCambios();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
