using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Models
{
    public class Continent
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual IEnumerable<School> Schools { get; set; }
        public virtual IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Continent> getContinents { get; set; }
        
    }
}
