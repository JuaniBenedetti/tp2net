using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class ComisionAdapter : Adapter 
    {
        #region DatosEnMemoria
        private static List<Comision> _Comisiones;

        private static List<Comision> Comisiones
        {
            get
            {
                if (_Comisiones == null)
                {
                    _Comisiones = new List<Business.Entities.Comision>();
                    Business.Entities.Comision com;
                    com = new Business.Entities.Comision();
                    com.ID = 1;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.Desc_comision = "4k4";
                    com.Anio_especialidad = "2020";
                    _Comisiones.Add(com);
                }
                return _Comisiones;
            }
        }
        #endregion

        public List<Comision> GetAll()
        {
            return new List<Comision>(Comisiones);
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            return Comisiones.Find(delegate (Comision com) { return com.ID == ID; });
        }

        public void Delete(int ID)
        {
            Comisiones.Remove(this.GetOne(ID));
        }

        public int NextId()
        {
            int NextID = 0;
            foreach (Comision com in Comisiones)
            {
                if (com.ID > NextID)
                {
                    NextID = com.ID;
                }
            }
            return NextID;
        }

        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.New)
            {

                com.ID = NextId() + 1;
                Comisiones.Add(com);
            }
            else if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                Comisiones[Comisiones.FindIndex(delegate (Comision c) { return c.ID == com.ID; })] = com;
            }
            com.State = BusinessEntity.States.Unmodified;
        }
    }
}
