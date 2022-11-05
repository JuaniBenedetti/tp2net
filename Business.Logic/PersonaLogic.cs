using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        public PersonaLogic()
        {
            this.PersonaData = new PersonaAdapter();
        }


        protected PersonaAdapter _PersonaData;
        public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }


        public Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public void Delete(int id)
        {
            PersonaData.Delete(id);
        }

        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }
    }
}
