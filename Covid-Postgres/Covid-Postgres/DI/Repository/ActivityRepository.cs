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
    public class ActivityRepository : IActivityRepository
    {
        public int AddActivity(string UserName,string Activity)
        {
            var day = DateTime.Now;
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;User Id=postgres;database=Covid;Password=kiprao123");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into activity (username,activity,daycreate) Values(@username,@activity,@daycreate)";
            comm.Parameters.AddWithValue("@username", UserName);
            comm.Parameters.AddWithValue("@activity", Activity);
            comm.Parameters.AddWithValue("@daycreate", day);
            comm.ExecuteNonQuery();
            conn.Close();
            return 1;
        }

        public List<ActivityVm> GetAllActi()
        {
            List<ActivityVm> acti = new List<ActivityVm>();
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;User Id=postgres;database=Covid;Password=kiprao123");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from activity";

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                var x = new ActivityVm();
                x.ActivityId = Convert.ToInt32(sdr["activityid"]);
                x.Activity = sdr["activity"].ToString();
                x.UserName = sdr["username"].ToString();
                x.DayCreate = sdr["daycreate"].ToString();

                acti.Add(x);
            }
            conn.Close();
            return acti;
        }
    }
}
