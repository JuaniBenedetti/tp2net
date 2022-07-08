using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private string _Desc_comision;
        public string Desc_comision
        {
            get { return _Desc_comision; }
            set { _Desc_comision = value; }
        }

        private string _Anio_especialidad;
        public string Anio_especialidad
        {
            get { return _Anio_especialidad; }
            set { _Anio_especialidad = value; }
        }
    }
}
