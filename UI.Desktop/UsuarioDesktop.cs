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
    public partial class UsuarioDesktop : ApplicationForm
    {
        protected Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }


        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this() 
        {
            Modo = modo;
            MapearDeDatos();
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this() 
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }


        public override void MapearDeDatos() 
        {
            if (this.Modo == ModoForm.Alta) 
            {
                UsuarioLogic ul = new UsuarioLogic();
                this.txtID.Text = (ul.NextId()+1).ToString();
            }

            else
            {
                this.txtID.Text = this.UsuarioActual.ID.ToString();
                this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
                this.txtNombre.Text = this.UsuarioActual.Nombre;
                this.txtApellido.Text = this.UsuarioActual.Apellido;
                this.txtEmail.Text = this.UsuarioActual.EMail;
                this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
                this.txtClave.Text = this.UsuarioActual.Clave;
                this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
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
                    Usuario user = new Usuario();
                    UsuarioActual = user;
                    this.UsuarioActual.State = BusinessEntity.States.New;
                }
                else this.UsuarioActual.State = BusinessEntity.States.Modified;

                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
            }
            else if (this.Modo == ModoForm.Baja) this.UsuarioActual.State = BusinessEntity.States.Deleted;
            else this.UsuarioActual.State = BusinessEntity.States.Unmodified;
        }

        public override void GuardarCambios() 
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(this.UsuarioActual);
        }

        public override bool Validar() 
        {
            if (
                (this.txtID.Text == "") ||
                (this.txtNombre.Text == "") ||
                (this.txtApellido.Text == "") ||
                (this.txtEmail.Text == "") ||
                (this.txtUsuario.Text == "") ||
                (this.txtClave.Text == "") ||
                (this.txtConfirmarClave.Text == "") ||
                (this.txtClave.Text.Length < 8) ||
                (this.txtClave.Text != this.txtConfirmarClave.Text) ||
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
