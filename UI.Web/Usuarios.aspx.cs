using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page

    {
        private Usuario Entity
        {
            get;
            set;
        }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic==null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridPanel_DataBinding(object sender, EventArgs e)
        {

        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.EMail;
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
            
        }
        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.EMail = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
        }
        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void formPanel_Load(object sender, EventArgs e)
        {

        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new Usuario();
            this.Entity.ID = this.SelectedID;
            this.Entity.State = BusinessEntity.States.Modified;
            this.LoadEntity(this.Entity);
            this.SaveEntity(this.Entity);
            this.LoadGrid();
            this.formPanel.Visible = false;
        }
        //eliminar usuario

    }
}