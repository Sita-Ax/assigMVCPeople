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
            if (string.IsNullOrWhiteSpace(createPerson.Name) || string.IsNullOrWhiteSpace(createPerson.City))
            {
                throw new ArgumentException("Name, and city is not allowed white any space.");
            }
            Person person = new Person()
            {
                Name = createPerson.Name,
                City = createPerson.City,
                PhoneNumber = createPerson.PhoneNumber
            };
            person = _peopleRepo.Create(person);
            return person;
        }

        public Person FindById(int id)
        {
            return _peopleRepo.Read(id);
        }

        public List<Person> GetAll()
        {
            return _peopleRepo.GetAll();
        }

        public List<Person> Search(string search)
        {
            return _peopleRepo.Read(search);
        }

        bool IPeopleService.Edit(int id, CreatePersonViewModel editPerson)
        {
           Person person = _peopleRepo.Read(id);
            _peopleRepo.Update(person);
            if(person != null)
            {
              return true;
            }
            return true;
        }

        bool IPeopleService.Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            if(person != null)
            {
                return true;
            }
            return false;
        }
    }
}
