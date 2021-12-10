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
    public class AnalystRepository : IAnalystRepository
    {
        
        NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;User Id=postgres;database=Covid;Password=kiprao123");

        //tính tổng số người chết
        public int CountDied()
        {
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select COUNT (personid) from person where datedied is not null ";

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;
        }

        //tính tổng số người chết hôm nay
        public int CountDiedToDay()
        {
            var day = DateTime.Now.ToString("MM-dd-yyyy");
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from person where datedied = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;
        }

        //tính tổng số người chết theo ngày
        public int CountDiedPerDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from person where datedied = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;
        }

        //tính tổng số ca xuất viện
        public int CountExport()
        {
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select COUNT (personid) from person where dateexport is not null ";

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;

        }

        //tính tổng số ca xuất viện hôm nay
        public int CountExportToday()
        {
            var day = DateTime.Now.ToString("MM-dd-yyyy");
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from person where dateexport = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;
        }

        //tính tổng số ca nhập viện hôm nay
        public int CountInputToday()
        {
            var day = DateTime.Now.ToString("MM-dd-yyyy");
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from person where dateadded = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;
        }

        //tính tổng số ca nhập viện theo ngày
        public int InputDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from person where dateadded = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;
        }

        //tính tổng số ca xuất viện theo ngày
        public int OutpuDate(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            int count = 0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from person where dateexport = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                count = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return count;
        }

        //Tổng số lượng F0
        public int QuantityOfF0()
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 0";
            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        //Tổng số lượng F0 theo ngày
        public int QuantityOfF0PerDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 0 and dateadded = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        //Tổng số lượng F1
        public int QuantityOfF1()
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 1";
            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        //Tổng số lượng F1 theo ngày
        public int QuantityOfF1PerDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 1 and dateadded = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        //Tổng số lượng F2
        public int QuantityOfF2()
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 2";
            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        //Tổng số lượng F2 theo ngày
        public int QuantityOfF2PerDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 2 and dateadded = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        //Tổng số lượng F3
        public int QuantityOfF3()
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 3";
            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        //Tổng số lượng F3 theo ngày
        public int QuantityOfF3PerDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count (*) from person where personstatus = 3 and dateadded = @date ::date ";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            int quantity = 99;
            while (sdr.Read())
            {
                quantity = Convert.ToInt32(sdr["count"]);
            }
            conn.Close();
            return quantity;
        }

        public List<Person> QuantityOfChangeStatus()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetTreatment()
        {
           
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person where dateexport is  null and datedied is null "
;

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }

        public List<Person> GetDied()
        {
            Person person = new Person();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person where dateexport is  null and datedied is not null"
;

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }

        public List<Person> GetExport()
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person where dateexport is not null and datedied is null"
;

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }

        public List<Person> GetPeople()
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person "
;

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }

        public List<Person> GetTreatmentDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person where dateexport is  null and datedied is null and dateadded = @date ::date";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }

        public List<Person> GetDiedDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person where dateexport is  null and datedied is not null and datedied = @date ::date";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }

        public List<Person> GetExportDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person where dateexport is not null and datedied is null and dateexport = @date ::date";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }

        public List<Person> GetPeopleDay(DateTime request)
        {
            var day = request.ToString("MM-dd-yyyy");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select *  from person where dateadded = @date ::date";
            comm.Parameters.AddWithValue("@date", day);

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var listperson = new List<Person>();
            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirh = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }

                if (sdr["changestatus"] == DBNull.Value)
                {
                    x.ChangeStatus = null;
                }
                else
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                x.CreateDate = sdr["dateadded"].ToString();
                x.DateExport = sdr["dateexport"].ToString();
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
                x.Datedied = sdr["datedied"].ToString();
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                listperson.Add(x);
            }
            conn.Close();
            return listperson;
        }
    }
}
