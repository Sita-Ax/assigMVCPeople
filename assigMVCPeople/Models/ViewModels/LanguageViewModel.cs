namespace assigMVCPeople.Models.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> LanguagesListView { get; set; }
        // [Display(Name = "CountriesString")]
        public string? CountriesString { get; set; }
        public LanguageViewModel()
        {
            LanguagesListView = new List<Language>();
        }
    }
}
