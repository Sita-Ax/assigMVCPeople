using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Services
{
    public interface IPeopleService
    {
        //Create from viewmodel
        Person Create(CreatePersonViewModel createPerson);

        //The list over all people
        List<Person> GetAll();
        
        List<Person> Search(string search);

        //Find by id
        Person FindById(int id);

        //Update
        bool Edit(int id, CreatePersonViewModel editPerson);
        //Delete
        bool Remove(int id);

    }
}
