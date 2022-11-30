using System.ComponentModel.DataAnnotations;

namespace assigMVCPeople.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Display(Name = "LanguageName")]
        [Required]
        public string LanguageName { get; set; }
        public List<Person>? People { get; set; }

        public CreateLanguageViewModel()
        {
            People = new List<Person>();
        }
    }
}
