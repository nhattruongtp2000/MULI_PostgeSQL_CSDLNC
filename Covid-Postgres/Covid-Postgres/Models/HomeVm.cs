using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Models
{
    public class HomeVm
    {
        public List<Person> People { get; set; }
        public Person Person { get; set; }

        public List<PlaceOfTreatment> Place { get; set; }
        public List<Person> RelatedPerson { get; set; }
    }
}
