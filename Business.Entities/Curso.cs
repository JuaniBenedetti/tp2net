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
        
        private int _Año_calendario;
        public int Año_calendario 
        {
            get { return _Año_calendario; }
            set { _Año_calendario = value; }
        }
        private int _Cupo;
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
    }
}
