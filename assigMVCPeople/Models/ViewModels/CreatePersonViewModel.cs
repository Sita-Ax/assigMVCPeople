using System.ComponentModel.DataAnnotations;

namespace assigMVCPeople.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        //What´s displayed
        [Display(Name="First and last name")]
        [Required]
         public string?  Name { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required]
         public string? PhoneNumber { get; set; }
        [Display(Name ="City")]
        [Required]
        public int CityId { get; set; }
        [Display(Name = "Language")]
        [Required]
        public int LanguageId { get; set; } 

        public List<City>? Cities { get; set; }

        public List<Language>? Languages { get; set; }
        
    }
}
