using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigMVCPeople.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Key]
        [Display(Name = "CountryName")]
        [Required]
        public string? CountryName { get; set; }
        [Display(Name = "InternationalCallingCode")]
        [Required]
        public string? InternationalCallingCode { get; set; }
        public List<City> CityList
        {
            get; set;
        }
    }
}
