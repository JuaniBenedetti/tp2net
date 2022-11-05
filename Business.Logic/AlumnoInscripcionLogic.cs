using System.Collections.Generic;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        public AlumnoInscripcionLogic()
        {
            this.AlumnoInscripcion = new AlumnoInscripcionAdapter();
        }

        protected AlumnoInscripcionAdapter _AlumnoInscripcion;
        public AlumnoInscripcionAdapter AlumnoInscripcion
        {
            get { return _AlumnoInscripcion; }
            set { _AlumnoInscripcion = value; }
        }

        public AlumnoInscripcion GetOne(int id)
        {
            return AlumnoInscripcion.GetOne(id);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoInscripcion.GetAll();
        }

        public void Delete(int id)
        {
            AlumnoInscripcion.Delete(id);
        }

        public void Save(AlumnoInscripcion persona)
        {
            AlumnoInscripcion.Save(persona);
        }
    }
}
