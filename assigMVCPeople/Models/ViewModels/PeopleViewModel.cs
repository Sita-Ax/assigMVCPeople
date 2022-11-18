using System.ComponentModel.DataAnnotations;

namespace assigMVCPeople.Models.ViewModels
{
    public class PeopleViewModel
    {
        [Display(Name = "PeopleListView")]
        public List<Person> PeopleListView { get; set; }
        [Display(Name = "FilterString")]
        public string? FilterString { get; set; }

        public PeopleViewModel()
        {
            PeopleListView = new List<Person>();
        }
    }
}
