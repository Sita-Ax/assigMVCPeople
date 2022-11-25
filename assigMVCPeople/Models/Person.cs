using System.ComponentModel.DataAnnotations.Schema;

namespace assigMVCPeople.Models
{
    public class Person
    {
        public Person(string? name, string? phoneNumber)
        {            
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public Person()
        {

        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City? City { get; set; }

        //cityID
        
    }
}
