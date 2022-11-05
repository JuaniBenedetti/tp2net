using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class EspecilidadesForm : System.Web.UI.Page
    {
        public Especialidades Entity
        {
            get;
            set;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.GridView1.DataSource = el.GetAll();
            this.GridView1.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            if(this.TextDNI.Text != "")
            {
                
               // el.getOne(this.TextDNI.Text);
               
            }
            else { }
        }
    }
}