using Covid_Postgres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.DI.Interface
{
    public interface IAnalystRepository
    {



        int QuantityOfF0();

        int QuantityOfF1();

        int QuantityOfF2();

        int QuantityOfF3();

        int QuantityOfF0PerDay(DateTime request);

        int QuantityOfF1PerDay(DateTime request);

        int QuantityOfF2PerDay(DateTime request);

        int QuantityOfF3PerDay(DateTime request);

        List<Person> GetTreatment();

        List<Person> GetDied();

        List<Person> GetExport();

        List<Person> GetPeople();

        //
        List<Person> GetTreatmentDay(DateTime request);

        List<Person> GetDiedDay(DateTime request);

        List<Person> GetExportDay(DateTime request);

        List<Person> GetPeopleDay(DateTime request);

    }
}
