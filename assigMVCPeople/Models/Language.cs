
using System.ComponentModel.DataAnnotations;

namespace assigMVCPeople.Models
{
    public class Language
    {
        public Language()
        {

        }
        [Key]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public Language(string? languageName)
        {
            
            LanguageName = languageName;    
        }
    }
}
