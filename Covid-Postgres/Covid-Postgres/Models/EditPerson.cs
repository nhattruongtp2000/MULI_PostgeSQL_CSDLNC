using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Models
{
    public class EditPerson
    {
        public int PersonId { get; set; }
        public string PersonFullName { get; set; }
        public int PlaceOfTreatmentId { get; set; }
        public string PersonAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string PatientId { get; set; }

    }
}
