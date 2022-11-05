using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnosInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones", SqlConn);

                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInscripcion aluIns = new AlumnoInscripcion();

                    aluIns.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluIns.IDAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    aluIns.IDCurso = (int)drAlumnosInscripciones["id_curso"];
                    aluIns.Condicion = (string)drAlumnosInscripciones["condicion"];
                    aluIns.Nota = (int)drAlumnosInscripciones["nota"];

                    alumnosInscripciones.Add(aluIns);
                }

                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones a cursos de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return alumnosInscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {

            AlumnoInscripcion aluIns = new AlumnoInscripcion();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnosInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion=@id", SqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                { 
                    aluIns.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluIns.IDAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    aluIns.IDCurso = (int)drAlumnosInscripciones["id_curso"];
                    aluIns.Condicion = (string)drAlumnosInscripciones["condicion"];
                    aluIns.Nota = (int)drAlumnosInscripciones["nota"];
                }

                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar inscripcion a curso de alumno", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return aluIns;
        }

        public void Insert(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO alumnos_inscripciones(id_alumno, id_curso, condicion, nota) " +
                    "values(@idAlumno, @idCurso, @condicion, @nota) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@idAlumno", SqlDbType.Int).Value = alumnoInscripcion.IDAlumno;
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = alumnoInscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                alumnoInscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al inscribir alumno a cursado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripcion a cursado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(AlumnoInscripcion aluIns)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET id_alumno=@idAlumno, id_curso=@idCurso," +
                    "condicion=@condicion, nota=@nota " +
                    "WHERE id_inscripcion=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = aluIns.ID;
                cmdSave.Parameters.Add("@idAlumno", SqlDbType.Int).Value = aluIns.IDAlumno;
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = aluIns.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = aluIns.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = aluIns.Nota;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion a cursado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion aluIns)
        {
            if (aluIns.State == BusinessEntity.States.New)
            {

                this.Insert(aluIns);
            }
            else if (aluIns.State == BusinessEntity.States.Deleted)
            {
                this.Delete(aluIns.ID);
            }
            else if (aluIns.State == BusinessEntity.States.Modified)
            {
                this.Update(aluIns);
            }
            aluIns.State = BusinessEntity.States.Unmodified;
        }
    }
}
