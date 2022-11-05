using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        public PlanLogic()
        {
            this.PlanData = new PlanAdapter();
        }
        private PlanAdapter _PlanData;
        public PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public List<Plan> GetAll()
        {
            return PlanData.getAll();
        }
        public Plan getOne(int id)
        {
            return PlanData.getOne(id);
        }
        public void Save(Plan plan)
        {
           PlanData.Save(plan);
        }

        public int NextId()
        {
            return PlanData.NextId();
        }
    }
}
