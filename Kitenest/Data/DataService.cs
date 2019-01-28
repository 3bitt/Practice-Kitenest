using Kitenest.Models;
using Kitenest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Data
{
    public class DataService : IDataService    {

        private readonly KitenestDbContext _context;

        public DataService(KitenestDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> getCities()
        {
            return _context.City;
        }

        public IEnumerable<Continent> getContinents()
        {
            return _context.Continent;
        }

        public IEnumerable<Country> getCountries()
        {
            return _context.Country;
        }

        public IEnumerable<School> getSchools()
        {
            return _context.School;
        }
    }
}
