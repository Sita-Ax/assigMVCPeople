using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigMVCPeople.Models.ViewModels
{
    public class CountriesViewModel
    {
        [Display(Name = "CountriesListView")]
        public List<Country> CountriesListView { get; set; }
        [Display(Name = "FilterString")]
        public string? FilterString { get; set; }
        public CountriesViewModel()
        {
            CountriesListView = new List<Country>();
        }
    }
}
