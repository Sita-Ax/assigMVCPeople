using assigMVCPeople.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;

namespace assigMVCPeople.Models.Repos
{
    public class DbCountryRepo : ICountryRepo
    {
        readonly PeopleDbContext _peopleDbContext;

        public DbCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Country Create(Country country)
        {
            //Country country = new Country(countryName, internationalCallingCode);
            _peopleDbContext.Countries.Add(country);
            _peopleDbContext.SaveChanges();
            return country;
        }

        public List<Country> Read()
        {
            return _peopleDbContext.Countries!.Include(country => country.Cities).ToList();
        }

        public Country Read(int id)
        {
            return _peopleDbContext.Countries!.Include(country => country.Cities).SingleOrDefault(country => country.CountryId == id);
        }

        public bool Update(Country country)
        {
            _peopleDbContext.Countries!.Update(country);
            int result = _peopleDbContext.SaveChanges();
            if(result == 0) { return false; }
            return true;
        }
        public bool Delete(Country country)
        {
            _peopleDbContext.Countries!.Remove(country);
            int result = _peopleDbContext.SaveChanges();
            if(result==0) { return false; }
            return true;
        }

    }
}
