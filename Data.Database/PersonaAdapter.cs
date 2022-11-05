using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {

            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.TipoPersona = (int)drPersonas["tipo_persona"];

                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
    
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE id_persona=@id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.TipoPersona = (int)drPersonas["tipo_persona"];
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar persona", Ex);
                throw ExcepcionManejada;
            }
            finally { this.CloseConnection(); }

            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET apellido=@apellido, direccion=@direccion," +
                    "email=@email, fecha_nac=@fecha_nac, id_plan=@id_plan," +
                    "legajo=@legajo, nombre=@nombre, telefono=@telefono," +
                    "tipo_persona=@tipo_persona " +
                    "WHERE id_persona=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 50).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                    "values(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
                    "SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 50).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {

                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }

    }
}
