using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assigMVCPeople.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Person(string? name, string? phoneNumber)
        {            
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public Person()
        {

        }
       
       // [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City? City { get; set; }
        public List<Language>? Languages { get; set; }
        
    }
}
