using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Especialidades : BusinessEntity
    {
        private string _DescEspecialidad;
        public string DescEspecialidad { get { return _DescEspecialidad; } set { _DescEspecialidad = value; } }
    }
}
