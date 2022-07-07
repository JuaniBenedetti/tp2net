using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        // id_curso, año calendario, cupo
        private string _Desc_curso;
        public string Desc_curso
        {
            get { return _Desc_curso; }
            set { _Desc_curso = value; }
        }
        private string _Año_calendario;
        public string Año_calendario 
        {
            get { return _Año_calendario; }
            set { _Año_calendario = value; }
        }
        private string _Cupo;
        public string Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
    }
}
