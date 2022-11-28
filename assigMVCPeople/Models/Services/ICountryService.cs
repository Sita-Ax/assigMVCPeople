using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Services
{
    public interface ICountryService
    {
        //Create from viewmodel
        Country Create(CreateCountryViewModel createCountry);

        //The list over all country
        List<Country> GetAll();

        List<Country> Search(string search);

        //Find by id
        Country FindById(int id);

        //Update
        bool Edit(int id, CreateCountryViewModel editCountry);
        //Delete
        bool Remove(int id);
    }
}
