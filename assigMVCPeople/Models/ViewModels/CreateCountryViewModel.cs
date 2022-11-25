using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigMVCPeople.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        
        [Display(Name = "Country")]
        [Required]
        public string? CountryName { get; set; }
        [Display(Name = "InternationalCallingCode")]
        [Required]
        public string? InternationalCallingCode { get; set; }
        public List<City> Cities { get; set; }
        public CreateCountryViewModel() { Cities = new List<City>(); }
    }
}
