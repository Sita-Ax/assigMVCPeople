using assigMVCPeople.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigMVCPeople.Models.ViewModels
{
    public class CreateCityViewModels
    {
       // [Key]
        [Display(Name = "CityName")]
        [Required]
        public string? CityName { get; set; }
        [Display(Name = "ZipCode")]
        [Required]
        public string? ZipCode { get; set; }

        public List<Person> People { get; set; }
        public int CountryId { get; set; }
        public List<Country> Countries { get; set; }
        public CreateCityViewModels() { Countries = new List<Country>(); }

    }
}
