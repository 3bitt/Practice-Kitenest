﻿using Kitenest.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitenest.Models
{

    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 3)]
        public String Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Mobile { get; set; }

        [Required]
        [Display(Name = "Continent")]
        public int Continent_id { get; set; }

        [ForeignKey("Continent_id")]
        public virtual Continent Continent { get; set; }

        [CountryValidator]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "City")]
        public int City_id { get; set; }

        [ForeignKey("City_id")]
        public virtual City City { get; set; }

        public IEnumerable<School> getSchools { get; set; }

       
    }
}
