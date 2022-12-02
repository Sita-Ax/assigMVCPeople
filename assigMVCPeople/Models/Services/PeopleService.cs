using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Services
{
    public class PeopleService : IPeopleService
    {
        //Get the mathods that the interface have as contract. 
        IPeopleRepo _peopleRepo;
        private readonly ICityRepo _cityRepo;
        private ILanguageRepo _languageRepo;
        //Use constructor to get access from the repos
        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo, ILanguageRepo languageRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
            _languageRepo = languageRepo;
        }

        public Person Create(CreatePersonViewModel createPerson)
        {
            if (string.IsNullOrWhiteSpace(createPerson.Name) || string.IsNullOrWhiteSpace(createPerson.PhoneNumber))
            {
                throw new ArgumentException("Name, PhoneNumber is not allowed white any space.");
            }

            var city = _cityRepo.Read(createPerson.CityId);
            if(city == null)
            {
                throw new ArgumentException("City is empty, plizz choose your city.");
            }
            var language = _languageRepo.Read(createPerson.LanguageId);
            if(language == null)
            {
                throw new ArgumentException("Language is empty, can´t you speak?");
            }
            Person person = new Person()
            {
                Name = createPerson.Name,
                PhoneNumber = createPerson.PhoneNumber,
                City = city,
            };
            return _peopleRepo.Create(person);
        }

        public List<Person> GetAll()
        {
            return _peopleRepo.Read();
        }

        public Person FindById(int id)
        {
            Person findPerson = _peopleRepo.Read(id);
            return findPerson;
        }

        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
            Person person = FindById(id);
            if (person != null)
            {
                person.Name = editPerson.Name;
                person.PhoneNumber = editPerson.PhoneNumber;
            }
            return _peopleRepo.Update(person);
        }

        public bool Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            bool success = _peopleRepo.Delete(person);
            return success;

        }

        public List<Person> Search(string search)
        {
            List<Person> searchPerson = _peopleRepo.Read();
            foreach (Person person in _peopleRepo.Read())
            {
                if (person.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchPerson = searchPerson.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
                    searchPerson.Add(person);
                }
            }
            if (searchPerson.Count == 0)
            {
                throw new ArgumentException("Could not find, try another");
            }
            return searchPerson;
        }
    }
}
