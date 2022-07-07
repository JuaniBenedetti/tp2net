using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        #region DatosEnMemoria
        private static List<Curso> _Cursos;

        private static List<Curso> Cursos
        {
            get
            {
                if (_Cursos == null)
                {
                    _Cursos = new List<Business.Entities.Curso>();
                    Business.Entities.Curso crs;
                    crs = new Business.Entities.Curso();
                    crs.ID = 1;
                    crs.State = Business.Entities.BusinessEntity.States.Unmodified;
                    crs.Desc_curso = "Javascript";
                    crs.Año_calendario = "Html";
                    crs.Cupo = "Css";

                    _Cursos.Add(crs);

                }
                return _Cursos;
            }
        }
        #endregion

        public List<Curso> GetAll()
        {
            return new List<Curso>(Cursos);
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            return Cursos.Find(delegate (Curso cur) { return cur.ID == ID; });
        }

        public void Delete(int ID)
        {
            Cursos.Remove(this.GetOne(ID));
        }

        public int NextId()
        {
            int NextID = 0;
            foreach (Curso cur in Cursos)
            {
                if (cur.ID > NextID)
                {
                    NextID = cur.ID;
                }
            }
            return NextID;
        }

        public void Save(Curso Curso)
        {
            if (Curso.State == BusinessEntity.States.New)
            {

                Curso.ID = NextId() + 1;
                Cursos.Add(Curso);
            }
            else if (Curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Curso.ID);
            }
            else if (Curso.State == BusinessEntity.States.Modified)
            {
                Cursos[Cursos.FindIndex(delegate (Curso cur) { return cur.ID == Curso.ID; })] = Curso;
            }
            Curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
