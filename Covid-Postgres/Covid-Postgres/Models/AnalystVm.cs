using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Models
{
    public class AnalystVm
    {
        public int F0 { get; set; }
        public int F1 { get; set; }
        public int F2 { get; set; }
        public int F3 { get; set; }
        public int F4 { get; set; }

        public int Input { get; set; }
        public int Output { get; set; }
        public int Process { get; set; }

        public int Died { get; set; }


    }
}
