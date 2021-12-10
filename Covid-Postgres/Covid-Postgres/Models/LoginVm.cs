using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Models
{
    public class LoginVm
    {
        [DisplayName("Tên tài khoản")]
        public string Username { get; set; }
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
    }
}
