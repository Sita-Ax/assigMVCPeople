using assigMVCPeople.Models.DB;

namespace assigMVCPeople.Models.Repos
{
    public class DbPeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DbPeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Person Create(string name, string phoneNumber, string city)
        {
            Person person = new Person(name, phoneNumber, city);
            _peopleDbContext.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

        public List<Person> GetAll()
        {
            return _peopleDbContext.Peoples.ToList();
        }

        public List<Person> Read()
        {
            return _peopleDbContext.Peoples.ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.Peoples.SingleOrDefault(person => person.Id == id);
        }

        public bool Update(Person? person)
        {
            _peopleDbContext.Update(person);
            _peopleDbContext.SaveChanges();
            return true;
        }
        public bool Delete(Person? person)
        {
            _peopleDbContext.Remove(person);
            _peopleDbContext.SaveChanges();
            return true;
        }
    }
}
