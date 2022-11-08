namespace assigMVCPeople.Models.Repos
{
    public interface IPeopleRepo
    {
        //CRUD
        //CREATE
        People Create(People people);

        //READ
        List<People> GetAll();
        People GetById(int id);
        List<People> GetByName(string name);
        List<People> GetByCities(string city);
        //UPDATE
        void Update(People people);
        //DELETE
        void Delete(People people);
    }
}
