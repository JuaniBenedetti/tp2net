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
           Curso cursos = new Curso();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.Año_calendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return cursos;
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
