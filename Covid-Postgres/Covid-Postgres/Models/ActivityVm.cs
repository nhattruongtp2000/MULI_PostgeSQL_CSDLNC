using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Models
{
    public class ActivityVm
    {
        public int ActivityId { get; set; }
        [DisplayName("Tên tài khoản")]
        public string UserName { get; set; }
        public int PersonId { get; set; }
        [DisplayName("Hoạt động")]
        public string Activity { get; set; }
        [DisplayName("Ngày thiết lập")]
        public string DayCreate { get; set; }
    }
}
