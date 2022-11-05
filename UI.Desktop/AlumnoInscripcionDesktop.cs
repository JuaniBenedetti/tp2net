using System;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {

        protected AlumnoInscripcion _AlumnoInscripcionActual;
        public AlumnoInscripcion AlumnoInscripcionActual
        {
            get { return _AlumnoInscripcionActual; }
            set { _AlumnoInscripcionActual = value; } 
        }

        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
        }

        public AlumnoInscripcionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            MapearDeDatos();
        }

        public AlumnoInscripcionDesktop(int ID, ModoForm modo) : this()
        {
            try
            {
                Modo = modo;
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                AlumnoInscripcionActual = ail.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            }
            else if (this.Modo == ModoForm.Consulta)
            {

                AlumnosInscripciones ais = new AlumnosInscripciones();
                ais.Listar();

            }
            else
            {
                this.txtIDAlumno.Text = this.AlumnoInscripcionActual.IDAlumno.ToString();
                this.txtIDCurso.Text = this.AlumnoInscripcionActual.IDCurso.ToString();
                this.cbCondicion.Text = this.AlumnoInscripcionActual.Condicion;
                this.txtNota.Text = this.AlumnoInscripcionActual.Nota != 0 ? this.AlumnoInscripcionActual.Nota.ToString() : "";
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
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    AlumnoInscripcionActual = ai;
                    this.AlumnoInscripcionActual.State = BusinessEntity.States.New;
                }
                else this.AlumnoInscripcionActual.State = BusinessEntity.States.Modified;

                this.AlumnoInscripcionActual.IDAlumno = Convert.ToInt32(this.txtIDAlumno.Text);
                this.AlumnoInscripcionActual.IDCurso = Convert.ToInt32(this.txtIDCurso.Text);
                this.AlumnoInscripcionActual.Condicion = this.cbCondicion.Text;
                this.AlumnoInscripcionActual.Nota = this.txtNota.Text != "" ? Convert.ToInt32(this.txtNota.Text) : 0;
            }
            else if (this.Modo == ModoForm.Baja) this.AlumnoInscripcionActual.State = BusinessEntity.States.Deleted;
            else this.AlumnoInscripcionActual.State = BusinessEntity.States.Unmodified;
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                ail.Save(this.AlumnoInscripcionActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            if (
                (this.txtIDAlumno.Text == "") ||
                (this.txtIDCurso.Text == "")
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
    }
}
