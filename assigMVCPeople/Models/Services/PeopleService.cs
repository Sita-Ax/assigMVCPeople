using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Services
{
    public class PeopleService : IPeopleService
    {
        //Get the mathods that the interface have as contract. 
        IPeopleRepo _peopleRepo;

        //Use constructor to get access from the repos
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Create(CreatePersonViewModel createPerson)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Person> Search(string search)
        {
            throw new NotImplementedException();
        }

        bool IPeopleService.Edit(int id, CreatePersonViewModel editPerson)
        {
            throw new NotImplementedException();
        }

        bool IPeopleService.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
