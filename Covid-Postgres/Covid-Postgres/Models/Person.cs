using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Models
{
    public class Person
    {
        [DisplayName("Mã bênh nhân")]
        public int PersonID {get;set;}
        [DisplayName("Tên bênh nhân")]
        public string PersonFullName { get; set; }

        [DisplayName("Ngày sinh")]
        public string DateOfBirh { get; set; }
        [DisplayName("Địa chỉ")]
        public string PersonAddress { get; set; }
        [DisplayName("Trạng thái ban đầu")]
        public int PersonStatus { get; set; }
        [DisplayName("Nơi điều trị")]
        public int PlaceOfTreatmentId { get; set; }
        [DisplayName("Trạng thái hiện tại")]
        public int? ChangeStatus { get; set; }
        [DisplayName("Ngày nhập viện")]
        public string CreateDate { get; set; }
        [DisplayName("Ngày xuất viện")]
        public string DateExport { get; set; }
        [DisplayName("Giới tính")]
        public int Gender { get; set; }
        [DisplayName("Số chứng minh nhân dân")]
        public string PatientId { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        [DisplayName("Mã bệnh nhân liên quan")]
        public int RelatedPersonId { get; set; }

        public string Datedied { get; set; }

        public override string ToString()
        {
            return PersonFullName;
        }
    }
}
