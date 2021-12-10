using Covid_Postgres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.DI.Interface
{
    public interface IActivityRepository
    {
        public int AddActivity(string UserName, string Activity);

        public List<ActivityVm> GetAllActi();
    }
}
