using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Services
{
    public interface IPeopleService
    {
        //Create from viewmodel
        People Create(CreatePeopleViewModel createPeople);

        //The list over all people
        List<People> GetAll();
        //The list from cities
        List<People> GetCities(string city);

        //Find by id
        People FindById(int id);
        //Find by city
        People FindByCities(string city);

        //Update
        void Edit(int id, CreatePeopleViewModel editPeople);
        //Delete
        void Remove(int id);

    }
}
