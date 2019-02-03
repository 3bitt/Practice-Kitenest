using Kitenest.Models;
using Kitenest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.ViewModels
{
    public class SchoolsViewModel : IPagination
    {

        public IEnumerable<School> Schools { get; set; }
     
        public String Name { get; set; }
        public int Mobile { get; set; }
        public Continent Continent { get; set; }
        public string Country { get; set; }
        public City City { get; set; }        

        public int CurrentPage { get; set; } = 0;

        public int TotalPages { get; set; } = 1;
    }
}
