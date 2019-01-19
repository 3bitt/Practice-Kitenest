using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Models
{
    public class SchoolTime
    {
        public int id { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [DataType(DataType.Time), Display(Name = "Opening at")]
        public DateTime openHour { get; set; }

        [DataType(DataType.Time), Display(Name = "Closing at")]
        public DateTime closeHour { get; set; }

        [DataType(DataType.Date), Display(Name = "Working from")]
        public DateTime workingFrom { get; set; }

        [DataType(DataType.Date), Display(Name = "Working to")]
        public DateTime workingTo { get; set; }
        
    }
}
