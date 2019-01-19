using Kitenest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.ViewModels
{
    public class WorldViewModel
    {
        public IEnumerable<Continent> Continents { get; set; } 
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
