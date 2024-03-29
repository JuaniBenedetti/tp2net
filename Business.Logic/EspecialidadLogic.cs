﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        public EspecialidadLogic ()
        {
            this.EspecialidadData = new EspecialidadAdapter();
        }
        private EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }

        public List<Especialidades> GetAll()
        {
            return EspecialidadData.GetAll();
        }
        public Especialidades getOne(int id)
        {
            return EspecialidadData.getOne(id);
        }
        public void Save(Especialidades especialidad)
        {
            EspecialidadData.Save(especialidad);
        }

        public int NextId()
        {
            return EspecialidadData.NextId();
        }
    }
}
