using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assigMVCPeople.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string? CityName { get; set; }
        public string? ZipCode { get; set; }
        public City(string? cityName, string? zipCode)
        {
            CityName = cityName;
            ZipCode = zipCode;
        }
        //Empty constructor to get other things from this
        public City()
        {

        }
       
        //Navigation Property of list of person
        public List<Person>? Peoples { get; set; }
        //PeopleDbContext ForeignKay from country
        //[ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
       
    }
}
