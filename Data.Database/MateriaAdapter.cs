using System;
using System.Collections.Generic;
using System.Linq;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

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
                   mate.Hs_semanales = 4;
                   mate.Hs_totales = 80;
                    mate.Id_Plan = 1;
                   _Materias.Add(mate);
                }
                return _Materias;
            }
        }
        #endregion

        public List<Materia> GetAll()
        {
            //return new List<Usuario>(Usuarios);
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", SqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Desc_materia = (string)drMaterias["desc_materia"];
                    mat.Hs_semanales = (int)drMaterias["hs_semanales"];
                    mat.Hs_totales = (int)drMaterias["hs_totales"]; //Esto va comentado porque no esta en la BBDD.
                    mat.Id_Plan = (int)drMaterias["id_plan"];

                    materias.Add(mat);
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return materias;
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            //return new List<Usuario>(Usuarios);
            Materia mat = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID; 
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Desc_materia = (string)drMaterias["desc_materia"];
                    mat.Hs_semanales = (int)drMaterias["hs_semanales"];
                    mat.Hs_totales = (int)drMaterias["hs_totales"]; //Esto va comentado porque no esta en la BBDD.
                    mat.Id_Plan = (int)drMaterias["id_plan"];

                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return mat;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            //Usuarios.Remove(this.GetOne(ID));
        }

        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE materias SET desc_materia=@desc_materia, hs_semanales=@hs_semanales," +
                    "hs_totales=@hs_totales, id_plan=@id_plan " +
                    "WHERE id_materia=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Desc_materia;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int, 50).Value = materia.Hs_semanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int, 50).Value = materia.Hs_totales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int, 50).Value = materia.Id_Plan;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO materias ( desc_materia, hs_semanales, hs_totales, id_plan) " +
                    "values(@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Desc_materia;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.VarChar, 50).Value = materia.Hs_semanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.VarChar, 50).Value = materia.Hs_totales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = materia.Id_Plan;

                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }   
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Materia", Ex);
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

                //materia.ID = NextId() + 1;
                //Materias.Add(materia);
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                // Materias[Materias.FindIndex(delegate (Materia m) { return m.ID == materia.ID; })] = materia;
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
