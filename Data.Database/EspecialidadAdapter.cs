using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        protected  List<Especialidades> _ListEspecialidades;
        public  List<Especialidades> ListEspecialidades
        {
            get {
                /* if (_ListEspecialidades == null)
                 {
                     _ListEspecialidades = new List<Business.Entities.Especialidades>();
                     Business.Entities.Especialidades com;
                     com = new Business.Entities.Especialidades();
                     com.ID = 1;
                     com.State = Business.Entities.BusinessEntity.States.Unmodified;
                     com.DescEspecialidad = "Quimica";
                     _ListEspecialidades.Add(com);
                 }*/
                _ListEspecialidades = this.GetAll();
                return _ListEspecialidades;
            }
           
        }

        public List<Especialidades> GetAll()
        {
            List<Especialidades> especialidades = new List<Especialidades>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", SqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidades especialidades1 = new Especialidades();
                    especialidades1.DescEspecialidad = (string)drEspecialidades["desc_especialidad"];
                    especialidades1.ID = (int)drEspecialidades["id_especialidad"];

                    especialidades.Add(especialidades1);
                }
                drEspecialidades.Close();
            }
            catch ( Exception ex )
            {
                Exception ExceptionManejada = new Exception("eror en conexion con especialidades", ex);
                throw ExceptionManejada;
            }
            finally { this.CloseConnection(); } 
            return especialidades;
        }

        public Especialidades getOne(int id)
        {
            Especialidades esp = new Especialidades();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEsp = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad = @id", SqlConn);
                cmdEsp.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drEsp = cmdEsp.ExecuteReader();
                while (drEsp.Read())
                {
                    esp.ID = (int)drEsp["id_especialidad"];
                    esp.DescEspecialidad = (string)drEsp["desc_especialidad"];
                }

            }catch(Exception ex)
            {
                Exception ExceptionManejada = new Exception("eror en conexion con especialidades", ex);
                throw ExceptionManejada;
            }
            finally { this.CloseConnection(); }
            return esp;
        }

        public Especialidades updateEspecialidad(Especialidades especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdEsp = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc_especialidad " +
                    "WHERE id_especialidad = @id", SqlConn);
                cmdEsp.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdEsp.Parameters.Add("@desc_especialidad", SqlDbType.NVarChar, 50).Value = especialidad.DescEspecialidad;
                cmdEsp.ExecuteNonQuery();
            } catch(Exception ex)
            {
                Exception ExceptionManejada = new Exception(" error al conectar especialidades", ex);
                throw ExceptionManejada;
            }

            return null;
        }

        public void Insert(Especialidades especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdEsp = new SqlCommand("INSERT INTO especialidades(desc_especialidad) " +
                    "values (@desc_especialidades)", SqlConn);
                cmdEsp.Parameters.Add("@desc_especialidades", SqlDbType.NVarChar, 50).Value = especialidad.DescEspecialidad;
               cmdEsp.ExecuteScalar();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdEsp = new SqlCommand("DELETE especialidades WHERE id_especialidad = @id", SqlConn);
                cmdEsp.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdEsp.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }
        }

        public int NextId()
        {
            int NextID = 0;
            foreach (Especialidades esp in ListEspecialidades)
            {
                if (esp.ID > NextID)
                {
                    NextID = esp.ID;
                }
            }
            return NextID;
        }

        public void Save(Especialidades esp)
        {
            if (esp.State == BusinessEntity.States.New)
            {

                // com.ID = NextId() + 1;
                //Comisiones.Add(com);
               this.Insert(esp);
            }
            else if (esp.State == BusinessEntity.States.Deleted)
            {
               this.Delete(esp.ID);
            }
            else if (esp.State == BusinessEntity.States.Modified)
            {
                //Comisiones[Comisiones.FindIndex(delegate (Comision c) { return c.ID == com.ID; })] = com;
                this.updateEspecialidad(esp);
            }
            esp.State = BusinessEntity.States.Unmodified;
        }
    }
 }
        








