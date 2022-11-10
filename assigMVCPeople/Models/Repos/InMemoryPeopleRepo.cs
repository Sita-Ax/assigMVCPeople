namespace assigMVCPeople.Models.Repos
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        //Save every people
        public Person Create(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read(string search)
        {
            throw new NotImplementedException();
        }

        public Person Read(int id)
        {
            throw new NotImplementedException();
        }

        bool IPeopleRepo.Delete(Person person)
        {
            throw new NotImplementedException();
        }

        bool IPeopleRepo.Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
