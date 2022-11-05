using Business.Entities;
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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        protected Especialidades _especialidadesActual;
        public Especialidades EspecialidadActual
        {
            get {return _especialidadesActual; }
            set { _especialidadesActual = value; }
        }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            MapearDeDatos();
        }
        public EspecialidadDesktop(ModoForm modo , int id) : this()
        {
            Modo =modo;
            EspecialidadLogic esp = new EspecialidadLogic();
            this.EspecialidadActual = esp.getOne(id);
            MapearDeDatos();
        }

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                EspecialidadLogic cl = new EspecialidadLogic();
                this.textBoxID.Text = (cl.NextId() + 1).ToString();
            }

            else
            {
                this.textBoxID.Text = this.EspecialidadActual.ID.ToString();
                this.textBoxDesc.Text = this.EspecialidadActual.DescEspecialidad;
               
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
                    Especialidades com = new Especialidades();
                    EspecialidadActual = com;
                    this.EspecialidadActual.State = BusinessEntity.States.New;
                }
                else this.EspecialidadActual.State = BusinessEntity.States.Modified;

                this.EspecialidadActual.DescEspecialidad = this.textBoxDesc.Text;
                this.EspecialidadActual.ID = Int32.Parse(this.textBoxID.Text);
            }
            else if (this.Modo == ModoForm.Baja) this.EspecialidadActual.State = BusinessEntity.States.Deleted;
            else this.EspecialidadActual.State = BusinessEntity.States.Unmodified;
        }

        public override bool Validar()
        {
            if(this.textBoxDesc.Text != "")
            {
                return true;
            } else {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic esp = new EspecialidadLogic();
            esp.Save(this.EspecialidadActual);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()) GuardarCambios();
            Close();
        }
    }
}
