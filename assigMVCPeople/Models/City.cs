using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assigMVCPeople.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? ZipCode { get; set; }
        public City(string? cityName, string? zipCode )
        {
            CityName = cityName;
            ZipCode = zipCode;
        }
        //Empty constructor to get other things from this
        public City()
        {

        }
    
        [Required]
        public string? CityName { get; set; }
        //Navigation Property
        public List<Person> Persons { get; set; }
        //PeopleDbContext
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
       
    }
}
