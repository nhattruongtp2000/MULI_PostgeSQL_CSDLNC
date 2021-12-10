using Covid_Postgres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.DI.Interface
{
    public interface IPlaceRepository
    {
        List<PlaceOfTreatment> GetAllPlace();

        int AddPlace(PlaceOfTreatment request);

        void Delete(int placeid);

        void EditPlace(PlaceOfTreatment request);

        PlaceOfTreatment GetPlace(int placeid);

        void ChangeQuantity(int idfirst,int idlast);
    }
}
