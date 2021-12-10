using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Models
{
    public class PlaceOfTreatment
    {
        public int PlaceId { get; set; }
        [DisplayName("Tên Nơi điều trị")]
        public string PlaceName { get; set; }
        [DisplayName("Tổng sức chứa")]
        public int Capacity { get; set; }
        [DisplayName("Sức chứa hiện tại")]
        public int CurrenQuantity { get; set; }
        public override string ToString()
        {
            return PlaceName;
        }
    }
}
