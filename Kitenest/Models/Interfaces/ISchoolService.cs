using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Models.Interfaces
{
    public interface ISchoolService
    {
        IEnumerable<School> GetAll();
        School GetById(int id);
        void Add(School newSchool);
        string getName(int id);
        string getCountry(int id);
        string getContinent(int id);
        string getCity(int id);
        int getMobileNumber(int id);
        DateTime getOpenHour(int id);
        DateTime getCloseHour(int id);
        DateTime getWorkingFrom(int id);
        DateTime getWorkingTo(int id);

    }
}
