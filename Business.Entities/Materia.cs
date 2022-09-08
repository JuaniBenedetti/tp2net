using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Desc_materia;
        public string Desc_materia
        {
            get { return _Desc_materia; }
            set { _Desc_materia = value; }
        }

        private int _Hs_semanales;
        public int Hs_semanales
        {
            get { return _Hs_semanales; }
            set { _Hs_semanales = value; }
        }

        private int _Hs_totales;
        public int Hs_totales
        {
            get { return _Hs_totales; }
            set { _Hs_totales = value; }
        }
        private int _Id_Plan;
        public int Id_Plan
        {
            get { return _Id_Plan; }
            set { _Id_Plan = value; }
        }
    }
}
