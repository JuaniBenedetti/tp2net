using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Business.Entities;


namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        protected List<Plan> _ListPlanes;
        public List<Plan> ListPlanes
        {
            get
            {

                _ListPlanes = this.getAll();
                return _ListPlanes;
            }

        }
        public List<Plan> getAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("SELECT * FROM planes", SqlConn);
                SqlDataReader drPlan = cmdPlan.ExecuteReader();
                while (drPlan.Read())
                {
                    Plan pl = new Plan();
                    pl.ID = (int)drPlan["id_plan"];
                    pl.DescPlan = (string)drPlan["desc_plan"];
                    pl.IdEspecialidad = (int)drPlan["id_especialidad"];
                    planes.Add(pl);
                } drPlan.Close();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("eror en conexion con planes", ex);
                throw ExceptionManejada;
            }
            finally { this.CloseConnection(); }

            return planes;
        }
        public Plan getOne(int id)
        {
            Plan pl = new Plan();

            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("SELECT * FROM planes WHERE id_plan = @id", SqlConn);
                cmdPlan.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader drPlan = cmdPlan.ExecuteReader();
                while (drPlan.Read())
                {
                    pl.ID = (int)drPlan["id_plan"];
                    pl.DescPlan = (string)drPlan["desc_plan"];
                    pl.IdEspecialidad = (int)drPlan["id_especialidad"];
                }
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("eror en conexion con planes", ex);
                throw ExceptionManejada;
            }
            finally { this.CloseConnection(); }

            return pl;

        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdEsp = new SqlCommand("DELETE planes WHERE id_plan = @id", SqlConn);
                cmdEsp.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdEsp.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar plan", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }
        }

        public void updatePlan(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("UPDATE planes SET desc_plan=@desc_plan, id_especialidad=@id_especialidad" +
                    " WHERE id_plan = @id ", SqlConn);
                cmdPlan.Parameters.Add("@desc_plan", System.Data.SqlDbType.NVarChar, 50).Value = plan.DescPlan;
                cmdPlan.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = plan.ID;
                cmdPlan.Parameters.Add("@id_especialidad", System.Data.SqlDbType.NVarChar, 50).Value = plan.IdEspecialidad;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("eror en conexion con planes", ex);
                throw ExceptionManejada;
            }
            finally { this.CloseConnection(); }
        }

        public void Insert(Plan plan) {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("INSERT INTO planes(desc_plan, id_especialidad ) " +
                    "VALUES(@desc_plan, @id_especialidad)", SqlConn);
                cmdPlan.Parameters.Add("@desc_plan", System.Data.SqlDbType.NVarChar, 50).Value = plan.DescPlan;
                cmdPlan.Parameters.Add("@id_especialidad", System.Data.SqlDbType.Int).Value = plan.IdEspecialidad;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("eror en conexion con planes", ex);
                throw ExceptionManejada;
            }
            finally { this.CloseConnection(); }
        }
        public int NextId()
        {
            int NextID = 0;
            foreach (Plan pl in ListPlanes)
            {
                if (pl.ID > NextID)
                {
                    NextID = pl.ID;
                }
            }
            return NextID;
        }

        public void Save(Plan pl)
        {
            if (pl.State == BusinessEntity.States.New)
            {

                // com.ID = NextId() + 1;
                //Comisiones.Add(com);
                this.Insert(pl);
            }
            else if (pl.State == BusinessEntity.States.Deleted)
            {
                this.Delete(pl.ID);
            }
            else if (pl.State == BusinessEntity.States.Modified)
            {
                //Comisiones[Comisiones.FindIndex(delegate (Comision c) { return c.ID == com.ID; })] = com;
                this.updatePlan(pl);
            }
            pl.State = BusinessEntity.States.Unmodified;
        }

    }
}
