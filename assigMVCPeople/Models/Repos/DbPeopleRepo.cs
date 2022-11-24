namespace assigMVCPeople.Models.Repos
{
    public class DbPeopleRepo : IPeopleRepo
    {
        public DbPeopleRepo()
        {

        }
        public Person Create(string name, string phoneNumber, string city)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            throw new NotImplementedException();
        }

        public Person Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person? person)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Person? person)
        {
            throw new NotImplementedException();
        }
    }
}
