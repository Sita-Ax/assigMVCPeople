using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assigMVCPeople.Models
{
    public class Country
    {
        //primary key to set the foringkey in city
        [Key]
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? InternationalCallingCode { get; set; }

        public Country(string? countryName, string? internationalCallingCode)
        {
            CountryName = countryName;
            InternationalCallingCode = internationalCallingCode;
        }
        public Country()
        {

        }
        //Have navigations propoties anly the list of cities
        public List<City>? Cities { get; set; }
    }
}
