using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Models.Interfaces
{
    interface IDataService
    {

        IEnumerable<School> getSchools();
        IEnumerable<Continent> getContinents();
        IEnumerable<Country> getCountries();
        IEnumerable<City> getCities();
    }
}
