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

        public People Create(CreatePeopleViewModel createPeople)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, CreatePeopleViewModel editPeople)
        {
            throw new NotImplementedException();
        }

        public People FindByCities(string city)
        {
            throw new NotImplementedException();
        }

        public People FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<People> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<People> GetCities(string city)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
