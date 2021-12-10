using Covid_Postgres.DI.Interface;
using Covid_Postgres.Models;
using Microsoft.AspNetCore.Http;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Covid_Postgres.DI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        //Thêm bệnh nhân mới
        NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;User Id=postgres;database=Covid;Password=kiprao123");
        public int AddPerson(Person request)
        {
            int status=0;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            DateTime dob = DateTime.Parse(request.DateOfBirh);
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            if (request.RelatedPersonId != 0)
            {
                comm.CommandText = "select personstatus from person where personid=@personid";
                comm.Parameters.AddWithValue("@personid", request.RelatedPersonId);
                NpgsqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    status = Convert.ToInt32(sdr["personstatus"]);
                }
            }
            conn.Close();
            conn.Open();

            comm.CommandText = "call usp_addperson (@fullname,@date,@address,@status,@place,@changestatus,@dateadded,@dateexport,@gender,@phone,@patienid,@relatedpersonid)";
            comm.Parameters.AddWithValue("@fullname",request.PersonFullName);
            comm.Parameters.AddWithValue("@date", dob);
            comm.Parameters.AddWithValue("@address", request.PersonAddress);

            if (request.RelatedPersonId != 0)
            {
                comm.Parameters.AddWithValue("@relatedpersonid",request.RelatedPersonId);
                comm.Parameters.AddWithValue("@status", status + 1);
            }
            else
            {
                comm.Parameters.AddWithValue("@status", request.PersonStatus);
                comm.Parameters.AddWithValue("@relatedpersonid", DBNull.Value);
            }
            comm.Parameters.AddWithValue("@place", request.PlaceOfTreatmentId);
            comm.Parameters.AddWithValue("@changestatus", DBNull.Value);
            comm.Parameters.AddWithValue("@dateexport", DBNull.Value);        
            comm.Parameters.AddWithValue("@dateadded", DateTime.Now);
            comm.Parameters.AddWithValue("@gender", request.Gender);
            comm.Parameters.AddWithValue("@phone", request.Phone);
            comm.Parameters.AddWithValue("@patienid", request.PatientId);
            comm.Parameters.AddWithValue("@datedied", DBNull.Value);
            comm.ExecuteNonQuery();
            conn.Close();
            return 1;

            ////////////////////////////////
         
        }

        //Thay đổi tình trạng bệnh nhân
        public void ChangeStatusPerson(int personid,string newstatus)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            var x = Convert.ToInt32(newstatus);
            comm.CommandText = "call usp_changesatus(@changestatus,@personid)";
            comm.Parameters.AddWithValue("@changestatus", x);
            comm.Parameters.AddWithValue("@personid", personid);
            comm.ExecuteNonQuery();
            conn.Close();
            
        }

        public void DeletePerson(int personid)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "call usp_DeletePer(@personid)";
            comm.Parameters.AddWithValue("@personid", personid);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        //Xác nhận bệnh nhân đã chết
        public void DiedPerson(int personid)
        {
            var day = DateTime.Now;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "call usp_Died(@personid,@date)";
            comm.Parameters.AddWithValue("@personId", personid);
            comm.Parameters.AddWithValue("@date", day);

            comm.ExecuteReader();
            conn.Close();
        }

        //Edit person
        public void EditPerson(EditPerson request)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            DateTime dob = DateTime.Parse(request.DateOfBirth);
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "update person set placeoftreatmentid =@place,personfullname =@namee,personaddress =@address,dob=@dob,phone=@phone,gender=@gender,patienid =@patienid where personid =@personid";
            comm.Parameters.AddWithValue("@personid", request.PersonId);
            comm.Parameters.AddWithValue("@address", request.PersonAddress);
            comm.Parameters.AddWithValue("@namee", request.PersonFullName);
            comm.Parameters.AddWithValue("@place", request.PlaceOfTreatmentId);
            comm.Parameters.AddWithValue("@phone", request.Phone);
            comm.Parameters.AddWithValue("@dob", dob);
            comm.Parameters.AddWithValue("@gender", request.Gender);
            comm.Parameters.AddWithValue("@patienid", request.PatientId);
            comm.ExecuteNonQuery();
            conn.Close();
        }


        //Cho bệnh nhân Xuất viện
        public void ExportPerson(int personid)
        {
            var day = DateTime.Now;
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
           
            comm.CommandText = "call usp_Export(@personid,@date)";
            comm.Parameters.AddWithValue("@personId", personid);
            comm.Parameters.AddWithValue("@date", day);

            comm.ExecuteReader();
            conn.Close();

        }

        public IPagedList<Person> GetAllListPerson(int? page)
        {
            List<Person> lovelies = new List<Person>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from Person";

            NpgsqlDataReader sdr = comm.ExecuteReader();

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
                    x.ChangeStatus = null;              
                else
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
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
                lovelies.Add(x);
            }
            var pageNumber = page ?? 1;
            int pageSize = 9;
            var xx = lovelies.ToPagedList(pageNumber, pageSize);
            conn.Close();
            return xx;
        }

        //Show tất cả bệnh nhân

        public List<Person> GetAllPerson()
        {
            List<Person> lovelies = new List<Person>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from Person";

            NpgsqlDataReader sdr = comm.ExecuteReader();

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
                if(sdr["changestatus"] == DBNull.Value)
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
                lovelies.Add(x);
            }
            conn.Close();
            return lovelies;

        }

        //dung để selectedlist item
        public List<int> GetListPersonId()
        {
            List<int> listint = new List<int>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select personid from Person";

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                var x = Convert.ToInt32(sdr["personid"]);
                listint.Add(x);
            }
            conn.Close();
            return listint;
        }

        //gọi từng bệnh nhân
        public Person GetPerson(int PersonId)
        {
            Person person = new Person();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

                comm.CommandText = "select * from Person where personid=@PersonId";
                comm.Parameters.AddWithValue("@PersonId", PersonId);

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var x = new Person();
            while (sdr.Read())
            {
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
            }
            conn.Close();
            return x;
        }

        //gọi bệnh nhân liên quan
        public List<Person> GetRelatedPerson(int personid)
        {
            List<Person> people = new List<Person>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from Person where relatedpersonid=@personid";
            comm.Parameters.AddWithValue("@personid" , personid);

            NpgsqlDataReader sdr = comm.ExecuteReader();

            while (sdr.Read())
            {
                var x = new Person();
                x.PersonID = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.PersonStatus = Convert.ToInt32(sdr["PersonStatus"]);
                if (x.ChangeStatus != null)
                {
                    x.ChangeStatus = Convert.ToInt32(sdr["changestatus"]);
                }
                people.Add(x);
            }
            conn.Close();
            return people;
        }

        //sắp xếp theo ngày nhập viện
        public List<Person> OrderByCreateDate()
        {
            List<Person> people = new List<Person>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from Person order by dateadded asc ";
            NpgsqlDataReader sdr = comm.ExecuteReader();

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
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                people.Add(x);
            }
            conn.Close();
            return people;
        }

        public List<Person> OrderById()
        {
            List<Person> people = new List<Person>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from Person order by personid  ";
            NpgsqlDataReader sdr = comm.ExecuteReader();

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
                if (sdr["relatedpersonid"] == DBNull.Value)
                {
                    x.RelatedPersonId = 0;
                }
                else
                {
                    x.RelatedPersonId = Convert.ToInt32(sdr["relatedpersonid"]);
                }
                people.Add(x);
            }
            conn.Close();
            return people;
        }

        //Sắp xếp theo tên
        public List<Person> OrderByName()
        {
            List<Person> people = new List<Person>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from Person order by personfullname";
            NpgsqlDataReader sdr = comm.ExecuteReader();

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
                people.Add(x);
            }
            conn.Close();
            return people;
        }


        //Tìm kiếm theo mã bệnh nhân
        public List<Person> SearchWithCode(int personid)
        {

            List<Person> people = new List<Person>();
            if (personid != 0)
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select * from Person Where personid=@personid ";
                comm.Parameters.AddWithValue("@personid", personid);
                NpgsqlDataReader sdr = comm.ExecuteReader();
                          
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
                    people.Add(x);
                }
                conn.Close();
            }
            
            return people;
        }

        public List<Person> SearchWithName(string name)
        {
            List<Person> people = new List<Person>();
            if (name != "")
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select * from person WHERE personfullname ilike @name ";
                comm.Parameters.AddWithValue("@name","%"+name+"%");
                NpgsqlDataReader sdr = comm.ExecuteReader();

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
                    people.Add(x);
                }
                conn.Close();
            }

            return people;
        }

        public EditPerson GetEditPerson(int personid)
        {
            Person person = new Person();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;

            comm.CommandText = "select * from Person where personid=@PersonId";
            comm.Parameters.AddWithValue("@PersonId", personid);

            NpgsqlDataReader sdr = comm.ExecuteReader();
            var x = new EditPerson();
            while (sdr.Read())
            {
                x.PersonId = Convert.ToInt32(sdr["personid"]);
                x.PersonFullName = sdr["PersonFullName"].ToString();
                x.DateOfBirth = sdr["DOB"].ToString();
                x.PersonAddress = sdr["PersonAddress"].ToString();
                if (sdr["placeoftreatmentid"] == DBNull.Value)
                {
                    x.PlaceOfTreatmentId = 0;
                }
                else
                {
                    x.PlaceOfTreatmentId = Convert.ToInt32(sdr["placeoftreatmentid"]);
                }
                x.Gender = Convert.ToInt32(sdr["Gender"]);
                x.PatientId = sdr["PatienId"].ToString();
                x.Phone = sdr["Phone"].ToString();
            }
            conn.Close();
            return x;
        }
    }
}
