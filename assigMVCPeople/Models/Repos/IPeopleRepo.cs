namespace assigMVCPeople.Models.Repos
{
    public interface IPeopleRepo
    {
        //CRUD
        //CREATE
        Person Create(string name, string phoneNumber, string city);

        //READ
        List<Person> GetAll();
        List<Person> Read();
        public Person Read(int id);
       
        //UPDATE
        bool Update(Person? person);
        //DELETE
        bool Delete(Person? person);
    }
}
