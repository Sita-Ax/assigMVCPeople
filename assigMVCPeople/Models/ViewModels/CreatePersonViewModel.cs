using System.ComponentModel.DataAnnotations;

namespace assigMVCPeople.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        //What´s displayed
        [Display(Name="Name")]
        [Required]
         public string?  Name { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required]
         public string? PhoneNumber { get; set; }
        [Display(Name ="City")]
        [Required]
        public string? City { get; set; }

        public List<string> CityList
        {
            get
            {
                return new List<string>
                {
                    "Karlskrona",
                    "Kirunna",
                    "Boden",
                    "Borås",
                    "Gävle",
                    "Umeå",
                    "Lund",
                    "Jönköping",
                    "Norrköping",
                    "Helsinhgborg",
                    "Linkköping",
                    "Växiö",
                    "Västerås"

                };
                                
            }

        }
        
    }
}
