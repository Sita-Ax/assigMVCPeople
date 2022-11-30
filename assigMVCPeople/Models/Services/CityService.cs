using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models.ViewModels;
using assigMVCPeople.Models;

namespace assigMVCPeople.Models.Services
{
    public class CityService : ICityService
    {
        //Get the methods that the interface have as contract. 
        ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;

        //Use constructor to get access from the repos
        public CityService(ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }

        public City Create(CreateCityViewModel createCity)
        {
            if (string.IsNullOrWhiteSpace(createCity.CityName)||(string.IsNullOrWhiteSpace(createCity.ZipCode)))
            {
                throw new ArgumentException("CityName and ZipCode is not allowed white any space.");
            }

            var country = _countryRepo.Read(createCity.CountryId);

            if (country == null)
            {
                throw new ArgumentException("Country is empty, plizz choose your country.");
            }


            City city = new City()
            {
                CityName = createCity.CityName,
                ZipCode = createCity.ZipCode,
                Country = country
            };
            return _cityRepo.Create(city);
            
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

        public bool Edit(int id, CreateCityViewModel editCity)
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
                if (city.CityName.Contains(search, StringComparison.OrdinalIgnoreCase))
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
