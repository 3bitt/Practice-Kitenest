using Kitenest.Data;
using Kitenest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Kitenest.Controllers;
using Kitenest.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kitenest.Validators
{
    public class CountryValidator : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
                      
            School school = (School)validationContext.ObjectInstance;

            var service = (KitenestDbContext)validationContext
                         .GetService(typeof(KitenestDbContext));

            var checkIfExists = service.Country.Where(e => e.Name == value.ToString());
            

            // Validator to be edited becouse of models change

            //if (String.IsNullOrEmpty(school.Country) || String.IsNullOrWhiteSpace(school.Country))
            //{
            //    return new ValidationResult(GetErrorMessage(1, school));
            //}

            if (!checkIfExists.Any())
            {
                return new ValidationResult(GetErrorMessage(3, school));
            }


            return ValidationResult.Success;
        }



        private string GetErrorMessage(int caseId, School school)
        {
            switch(caseId)
            {
                case 1:
                    return "Country name can't be empty";                    
                case 2:
                    return "City name can't be empty";
                case 3:
                    return $"I can't recognize country like \"{school.Country}\"";
                case 4:
                    return $"I can't recognize city like \"{school.City}\"";
                default:
                    return "Something went wrong";
            }
            
        }
    }
}
