using System;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        protected Persona _PersonaActual;
        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            MapearDeDatos();
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            try
            {
                Modo = modo;
                PersonaLogic pl = new PersonaLogic();
                PersonaActual = pl.GetOne(ID);
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
                PersonaLogic pl = new PersonaLogic();
            }
            else if (this.Modo == ModoForm.Consulta)
            {

                Personas per = new Personas();
                per.Listar();

            }
            else
            {
                this.txtNombre.Text = this.PersonaActual.Nombre;
                this.txtApellido.Text = this.PersonaActual.Apellido;
                this.txtDireccion.Text = this.PersonaActual.Direccion;
                this.txtEmail.Text = this.PersonaActual.Email;
                this.txtTelefono.Text = this.PersonaActual.Telefono;
                this.dtpFechaNac.Value = this.PersonaActual.FechaNacimiento;
                this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
                this.txtIDPlan.Text = this.PersonaActual.IDPlan.ToString();
                this.cbTipo.SelectedItem = this.PersonaActual.TipoPersona == 1 ? "Alumno" : "Profesor";
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
                    Persona per = new Persona();
                    PersonaActual = per;
                    this.PersonaActual.State = BusinessEntity.States.New;
                }
                else this.PersonaActual.State = BusinessEntity.States.Modified;

                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.FechaNacimiento = this.dtpFechaNac.Value;
                this.PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                this.PersonaActual.IDPlan = Convert.ToInt32(this.txtIDPlan.Text);
                this.PersonaActual.TipoPersona = this.cbTipo.SelectedItem == "Alumno" ? 1 : 0;
            }
            else if (this.Modo == ModoForm.Baja) this.PersonaActual.State = BusinessEntity.States.Deleted;
            else this.PersonaActual.State = BusinessEntity.States.Unmodified;
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PersonaLogic pl = new PersonaLogic();
                pl.Save(this.PersonaActual);
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            if (
                (this.txtNombre.Text == "") ||
                (this.txtApellido.Text == "") ||
                (this.txtDireccion.Text == "") ||
                (this.txtEmail.Text == "") ||
                (this.txtTelefono.Text == "") ||
                (this.dtpFechaNac.Value == null) ||
                (this.txtLegajo.Text == "") ||
                (this.txtIDPlan.Text == "") ||
                !(this.txtEmail.Text.Contains("@"))
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
