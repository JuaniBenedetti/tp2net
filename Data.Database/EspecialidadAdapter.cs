using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
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
    }
 }
        
