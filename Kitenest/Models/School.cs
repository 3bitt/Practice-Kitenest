﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Models
{
    public class School
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 3)]
        public String Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Mobile { get; set; }


        [Display(Name = "Continent")]
        public int Continent_id { get; set; }

        [ForeignKey("Continent_id")]
        public virtual Continent Continent { get; set; }


        
        public int Country_id { get; set; }

        [ForeignKey("Country_id")]
        [Display(Name = "Country")]
        public virtual Country Country { get; set; }

        [Display(Name = "City")]
        public int City_id { get; set; }

        [ForeignKey("City_id")]
        public virtual City City { get; set; }


        [Display(Name = "Active Periods")]
        public int School_Time_id { get; set; }

        [ForeignKey("School_Time_id")]
        public virtual SchoolTime SchoolTime { get; set; }

        public IEnumerable<School> getAll { get; set; }        

    }
}
