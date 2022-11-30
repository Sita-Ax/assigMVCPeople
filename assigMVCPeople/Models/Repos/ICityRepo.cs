namespace assigMVCPeople.Models.Repos
{
    public interface ICityRepo
    {
        City Create(City city);

        //READ
        
        List<City> Read();
        City Read(int id);

        //UPDATE
        bool Update(City city);
        //DELETE
        bool Delete(City? city);
    }
}

