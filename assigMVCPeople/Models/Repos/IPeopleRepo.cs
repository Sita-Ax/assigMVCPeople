namespace assigMVCPeople.Models.Repos
{
    public interface IPeopleRepo
    {
        //CRUD
        //CREATE
        public Person Create(string name, string phoneNumber, string city);

        //READ
        public List<Person> GetAll();
        public List<Person> Read();
        public Person Read(int id);
       
        //UPDATE
        public bool Update(Person? person);
        //DELETE
        public bool Delete(Person? person);
    }
}
