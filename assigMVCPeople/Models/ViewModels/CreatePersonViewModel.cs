using System.ComponentModel.DataAnnotations;

namespace assigMVCPeople.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        //What´s displayed
        [Display(Name="Person")]
        [Required]
         public string?  Name { get; set; }
         public double PhoneNumber { get; set; }
        [Required]

        public string? City { get; set; }

        
    }
}
