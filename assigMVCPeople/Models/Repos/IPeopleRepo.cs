namespace assigMVCPeople.Models.Repos
{
    public interface IPeopleRepo
    {
        //CRUD
        //CREATE
        Person Create(string name, string phoneNumber);

        //READ
        List<Person> Read();
        Person Read(int id);
       
        //UPDATE
        bool Update(Person person);
        //DELETE
        bool Delete(Person person);
    }
}
