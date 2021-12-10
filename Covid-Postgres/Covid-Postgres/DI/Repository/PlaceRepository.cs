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
    public class PlaceRepository : IPlaceRepository
    {
        //Thêm nơi điều trị mới
        NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;User Id=postgres;database=Covid;Password=kiprao123");

        public int AddPlace(PlaceOfTreatment request)
        {      
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into placeoftreatment (placeoftreatmentname,capacity,currentquantity) Values(@placename,@capacity,@current)";
            comm.Parameters.AddWithValue("@placename", request.PlaceName);
            comm.Parameters.AddWithValue("@capacity", request.Capacity);
            comm.Parameters.AddWithValue("@current", request.CurrenQuantity);
            comm.ExecuteNonQuery();
            conn.Close();
            return 1;
        }

        public void ChangeQuantity(int idfirst, int idlast)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "update  placeoftreatment set currentquantity=currentquantity+1 where placeoftreatmentid=@placeid";
            comm.Parameters.AddWithValue("@placeid", idfirst);
            comm.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            comm.CommandText = "update  placeoftreatment set currentquantity=currentquantity-1 where placeoftreatmentid=@placeid";
            comm.Parameters.AddWithValue("@placeid", idlast);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int placeid)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "delete from placeoftreatment where placeoftreatmentid=@placeid";
            comm.Parameters.AddWithValue("@placeid", placeid);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void EditPlace(PlaceOfTreatment request)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "update placeoftreatment set placeoftreatmentname = @name, capacity = @capacity,currentquantity=@currentquantity where placeoftreatmentid = @id";
            comm.Parameters.AddWithValue("@id", request.PlaceId);
            comm.Parameters.AddWithValue("@name", request.PlaceName);
            comm.Parameters.AddWithValue("@capacity", request.Capacity);
            comm.Parameters.AddWithValue("@currentquantity", request.CurrenQuantity);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        //Gọi tất cả nơi điều trị
        public List<PlaceOfTreatment> GetAllPlace()
        {
            List<PlaceOfTreatment> places = new List<PlaceOfTreatment>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from placeoftreatment";

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                var x = new PlaceOfTreatment();
                x.PlaceId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                x.PlaceName = sdr["placeoftreatmentname"].ToString();
                x.Capacity = Convert.ToInt32(sdr["capacity"]);
                x.CurrenQuantity = Convert.ToInt32(sdr["currentquantity"]);
                places.Add(x);
            }
            conn.Close();
            return places;
        }

        public PlaceOfTreatment GetPlace(int placeid)
        {;
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;User Id=postgres;database=Covid;Password=kiprao123");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from placeoftreatment where placeoftreatmentid=@placeid";
            comm.Parameters.AddWithValue("@placeid",placeid);

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var x = new PlaceOfTreatment();
            while (sdr.Read())
            {
                
                x.PlaceId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                x.PlaceName = sdr["placeoftreatmentname"].ToString();
                x.Capacity = Convert.ToInt32(sdr["capacity"]);
                x.CurrenQuantity = Convert.ToInt32(sdr["currentquantity"]);
            }
            conn.Close();
            return x;
        }
    }
}
