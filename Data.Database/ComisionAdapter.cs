using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

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
                    com.Anio_especialidad = 2020;
                    _Comisiones.Add(com);
                }
                return _Comisiones;
            }
        }
        #endregion

        public List<Comision> GetAll()
        {
            //return new List<Comision>(Comisions);
            List<Comision> comisions = new List<Comision>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisions = new SqlCommand("SELECT * FROM comisiones", SqlConn);

                SqlDataReader drComisions = cmdComisions.ExecuteReader();

                while (drComisions.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComisions["id_comision"];
                    com.Desc_comision = (string)drComisions["desc_comision"];
                    com.Anio_especialidad = (int)drComisions["anio_especialidad"];
                    com.Id_Plan = (int)drComisions["id_plan"];
                    

                    comisions.Add(com);
                }

                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisions", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return comisions;
        }


        public Business.Entities.Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisions = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", SqlConn);
                cmdComisions.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisions = cmdComisions.ExecuteReader();

                while (drComisions.Read())
                {
                    com.ID = (int)drComisions["id_comision"];
                    com.Desc_comision = (string)drComisions["desc_comision"];
                    com.Anio_especialidad = (int)drComisions["anio_especialidad"];
                    com.Id_Plan = (int)drComisions["id_plan"];// Esto va comentado porque no esta en la BBDD.// 10.07 si esta
                   
                }

                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar Comision", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return com;

            //return Comisions.Find(delegate(Comision u) { return u.ID == ID; });
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            //comisions.Remove(this.GetOne(ID));
        }

        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE comisiones SET desc_comision=@desc_comision, anio_especialidad=@anio_especialidad, " +
                    "id_plan=@id_plan WHERE id_comision=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Desc_comision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar, 50).Value = comision.Anio_especialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = comision.Id_Plan;
      

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan) " +
                    "values(@desc_comision, @anio_especialidad, @id_plan) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Desc_comision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar, 50).Value = comision.Anio_especialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = comision.Id_Plan;

                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
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

                // com.ID = NextId() + 1;
                //Comisiones.Add(com);
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                //Comisiones[Comisiones.FindIndex(delegate (Comision c) { return c.ID == com.ID; })] = com;
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }
    }
}
