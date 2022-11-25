using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models.ViewModels;
using assigMVCPeople.Models;

namespace assigMVCPeople.Models.Services
{
    public class CityService : ICityService
    {
        //Get the mathods that the interface have as contract. 
        ICityRepo _cityRepo;

        //Use constructor to get access from the repos
        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public City Create(CreateCityViewModels createCity)
        {
            City city = _cityRepo.Create(createCity.CityName, createCity.ZipCode);
            if (string.IsNullOrWhiteSpace(createCity.CityName)||(string.IsNullOrWhiteSpace(createCity.ZipCode)))
            {
                throw new ArgumentException("City is not allowed white any space.");
            }

            return city;
        }

        public List<City> GetAll()
        {
            return _cityRepo.Read();
        }

        public City FindById(int id)
        {
            City findCity = _cityRepo.Read(id);
            return findCity;
        }

        public bool Edit(int id, CreateCityViewModels editCity)
        {
            City city = FindById(id);
            if (city != null)
            {

                city.CityName = editCity.CityName;
                city.ZipCode = editCity.ZipCode;

            }
            return _cityRepo.Update(city);
        }

        public bool Remove(int id)
        {
            City city = _cityRepo.Read(id);
            bool success = _cityRepo.Delete(city);
            return success;

        }

        public List<City> Search(string search)
        {
            List<City> searchCity = _cityRepo.Read();
            foreach (City city in _cityRepo.Read())
            {
                if (

                    city.CityName.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchCity = searchCity.Where(p => p.CityName.Contains(search.ToUpper())).ToList();
                    searchCity.Add(city);
                }
            }
            if (searchCity.Count == 0)
            {
                throw new ArgumentException("Could not find, try another");
            }
            return searchCity;
        }

    }
}
