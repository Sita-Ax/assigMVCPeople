﻿using assigMVCPeople.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;

namespace assigMVCPeople.Models.Repos
{
    public class DbCityRepo : ICityRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DbCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public City Create(City city)
        {
           // City city = new City(cityName, zipCode);
            _peopleDbContext.Cities.Add(city);
            _peopleDbContext.SaveChanges();
            return city;
        }
        
        public List<City> Read()
        {
            return _peopleDbContext.Cities!.Include(city => city.Country).ToList();
        }

        public City Read(int id)
        {
            return _peopleDbContext.Cities!.Include(city => city.Country).SingleOrDefault(city => city.CityId ==id);
        }

        public bool Update(City city)
        {
            _peopleDbContext.Cities!.Update(city);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }

        public bool Delete(City city)
        {
            _peopleDbContext.Cities!.Remove(city);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }
    }
}
