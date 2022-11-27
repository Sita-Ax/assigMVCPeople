using assigMVCPeople.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace assigMVCPeople.Models.Repos
{
    public class DbCityRepo : ICityRepo
    {
        private readonly PeopleDbContext _peopleDbContext;
        public DbCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public City Create(string cityName, string zipCode)
        {
            City city = new City(cityName, zipCode);
            _peopleDbContext.Add(city);
            _peopleDbContext.SaveChanges();
            return city;
        }

        public bool Delete(City? city)
        {
            _peopleDbContext.Cities.Remove(city);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }

        
        public List<City> Read()
        {
            return _peopleDbContext.Cities.Include(city => city.Country).ToList();
        }

        public City Read(int id)
        {
            return _peopleDbContext.Cities.Include(city => city.Country).SingleOrDefault(city => city.CountryId ==id);
        }

        public bool Update(City? city)
        {
            _peopleDbContext.Cities.Update(city);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }
    }
}
