using Covid_Postgres.DI.Interface;
using Covid_Postgres.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.DI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        //Đang nhập
        public bool Login(LoginVm request)
        {
           
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;User Id=postgres;database=Covid;Password=kiprao123");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from users where username=@username";
            comm.Parameters.AddWithValue("@username", request.Username);
            NpgsqlDataReader sdr = comm.ExecuteReader();
            var name="";
            var password="";
            if (sdr.Read())
            {
                name = sdr["username"].ToString();
                password = sdr["pasword"].ToString();

            }
            conn.Close();
            if (name==request.Username && password == request.Password)
            {
                return true;
            }
            return false;
            
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }
    }
}
