using assigMVCPeople.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assigMVCPeople.Models.ViewModels
{
    public class CityViewModels
    {
       // [Display(Name = "CitiesListView")]
        public List<City> CitiesListView { get; set; }
       // [Display(Name = "FilterString")]
        public string? FilterString { get; set; }

        public CityViewModels()
        {
            CitiesListView = new List<City>();
        }
    }
}
