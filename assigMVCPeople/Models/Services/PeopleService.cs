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
            Person person = _peopleRepo.Create(createPerson.Name, createPerson.PhoneNumber, createPerson.City);
            if (string.IsNullOrWhiteSpace(createPerson.Name) || string.IsNullOrWhiteSpace(createPerson.PhoneNumber) || string.IsNullOrWhiteSpace(createPerson.City))
            {
                throw new ArgumentException("Name,PhoneNumber, City is not allowed white any space.");
            }
            
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

        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
           Person person = _peopleRepo.Read(id);
            _peopleRepo.Update(person);
            if(person != null)
            {
                person.Name = editPerson.Name;
                person.City = editPerson.City;
                person.PhoneNumber = editPerson.PhoneNumber;

            }
            return true;
        }

        public bool Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            bool success = _peopleRepo.Delete(person);
            return success;
            
        }
    }
}
