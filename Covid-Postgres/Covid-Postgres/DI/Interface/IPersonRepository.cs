using Covid_Postgres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Covid_Postgres.DI.Interface
{
    public interface IPersonRepository
    {
        List<Person> GetAllPerson();

        Person GetPerson(int PersonId);

        int AddPerson(Person request);

        List<Person> SearchWithCode(int personid);

        List<Person> SearchWithName(string name);

        EditPerson GetEditPerson(int personid);

        void EditPerson(EditPerson request);

        List<Person> OrderByName();

        List<Person> OrderByCreateDate();

        List<Person> OrderById();

        void DeletePerson(int personid);





        List<Person> GetRelatedPerson(int personid);

        void ChangeStatusPerson(int personid,string newstatus);

        List<int> GetListPersonId();

        void ExportPerson(int personid);

        void DiedPerson(int personid);

        IPagedList<Person> GetAllListPerson(int? page);
    }
}
