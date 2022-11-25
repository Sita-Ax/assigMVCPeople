namespace assigMVCPeople.Models.Repos
{
    public interface ICityRepo
    {
        City Create(string cityName, string zipCode);

        //READ
        List<City> GetAll();
        List<City> Read();
        public City Read(int id);

        //UPDATE
        bool Update(City? city);
        //DELETE
        bool Delete(City? city);
    }
}

