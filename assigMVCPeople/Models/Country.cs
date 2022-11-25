using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assigMVCPeople.Models
{
    public class Country
    {
        //primary key foringkey
        [Key]
        public int CountryId { get; set; }
        public List<City> Cities { get; set; }
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
    }
}
