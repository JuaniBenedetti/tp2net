using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


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
                    crs.Año_calendario = 2022;
                    crs.Cupo = 1;

                    _Cursos.Add(crs);
                
                }
                return _Cursos;
            }
        }
        #endregion

        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader drCursos = cmdCurso.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Id_comision = (int)drCursos["id_comision"];
                    cur.Id_materia = (int)drCursos["id_materia"];


                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return cursos;
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            Curso cur = new Curso();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();

                while (drCursos.Read())
                {
                    

                    cur.ID = (int)drCursos["id_curso"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Id_comision = (int)drCursos["id_comision"];
                    cur.Id_materia = (int)drCursos["id_materia"];

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return cur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            //Cursos.Remove(this.GetOne(ID));
        }
        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET anio_calendario=@anio_calendario, cupo=@cupo, id_Materia=@id_materia, id_comision=@id_comision " +
                    "WHERE id_curso=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50).Value = curso.Año_calendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.Id_materia;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.Id_comision;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO cursos( anio_calendario, cupo, id_materia, id_comision) " +
                    "values( @anio_calendario, @cupo, @id_materia, @id_comision) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50).Value = curso.Año_calendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.Id_materia;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.Id_comision;

                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
           

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
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
            foreach (Curso cur in Cursos)
            {
                if (cur.ID > NextID)
                {
                    NextID = cur.ID;
                }
            }
            return NextID;
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {

                //Curso.ID = NextId() + 1;
                //Cursos.Add(Curso);
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                //Cursos[Cursos.FindIndex(delegate (Curso cur) { return cur.ID == curso.ID; })] = curso;
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
