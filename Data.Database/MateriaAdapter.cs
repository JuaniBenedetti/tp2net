using System;
using System.Collections.Generic;
using System.Linq;
using Business.Entities;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        #region DatosEnMemoria
        private static List<Materia> _Materias;

        private static List<Materia> Materias
        {
            get
            {
                if (_Materias == null)
                {
                    _Materias = new List<Business.Entities.Materia>();
                    Business.Entities.Materia mate;
                    mate = new Business.Entities.Materia();
                    mate.ID = 1;
                    mate.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mate.Desc_materia = ".Net";
                    mate.Hs_semanales = "4";
                    mate.Hs_totales = "80";
                    _Materias.Add(mate);
                }
                return _Materias;
            }
        }
        #endregion

        public List<Materia> GetAll()
        {
            return new List<Materia>(Materias);
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            return Materias.Find(delegate (Materia m) { return m.ID == ID; });
        }

        public void Delete(int ID)
        {
            Materias.Remove(this.GetOne(ID));
        }

        public int NextId()
        {
            int NextID = 0;
            foreach (Materia materia in Materias)
            {
                if (materia.ID > NextID)
                {
                    NextID = materia.ID;
                }
            }
            return NextID;
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {

                materia.ID = NextId() + 1;
                Materias.Add(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                Materias[Materias.FindIndex(delegate (Materia m) { return m.ID == materia.ID; })] = materia;
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
