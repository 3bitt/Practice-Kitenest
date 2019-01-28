using Kitenest.Data;
using Kitenest.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.Validators
{
    public class CityValidator : ValidationAttribute, IClientModelValidator
    {
        
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{

        //    var service = (KitenestDbContext)validationContext
        //                 .GetService(typeof(KitenestDbContext));

        //    var checkIfExists = service.City.Where(e => e.Name == value.ToString());

        //    if (!checkIfExists.Any())
        //        return new ValidationResult(GetErrorMessage());

        //    return ValidationResult.Success;
        //}

        public void AddValidation(ClientModelValidationContext context)
        {
            var cities = new List<City> { };

            {
                context.Attributes.Add("data-val", "true");
                context.Attributes.Add("data-val-error", GetErrorMessage());
                context.Attributes.Add("data-val-cities", cities.ToString());
                
            }
        }

        private string GetErrorMessage()
        {
            return $"I can't recognize this city";
        }
    }
}
