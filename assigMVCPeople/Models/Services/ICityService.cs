using assigMVCPeople.Models.ViewModels;
using assigMVCPeople.Models;

namespace assigMVCPeople.Models.Services
{
    public interface ICityService
    {
        //Create from viewmodel
        City Create(CreateCityViewModels createCity);

        //The list over all city
        List<City> GetAll();

        List<City> Search(string search);

        //Find by id
        City FindById(int id);

        //Update
        bool Edit(int id, CreateCityViewModels editCity);
        //Delete
        bool Remove(int id);

    }
}
