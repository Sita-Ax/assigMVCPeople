using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Create(CreateCountryViewModel createCountry)
        {
            if(string.IsNullOrWhiteSpace(createCountry.CountryName) || string.IsNullOrWhiteSpace(createCountry.InternationalCallingCode))
                {
                throw new ArgumentException("CountryName and InternationalCallingCode is not allowed wíth space.");
            }
            Country country = _countryRepo.Create(createCountry.CountryName, createCountry.InternationalCallingCode);
            return country;
        }

        public List<Country> GetAll()
        {
            return _countryRepo.Read();
        }

        public Country FindById(int id)
        {
            Country countryFound = _countryRepo.Read(id);
            return countryFound;
        }

        public bool Edit(int id, CreateCountryViewModel editCountry)
        {
            Country country = FindById(id);
            if(country != null)
            {
                country.CountryName = editCountry.CountryName;
                country.InternationalCallingCode = editCountry.InternationalCallingCode;
            }
            return _countryRepo.Update(country);
        }

        public bool Remove(int id)
        {
            Country country = _countryRepo.Read(id);
            bool success = _countryRepo.Delete(country);
            return success;
        }

        public List<Country> Search(string search)
        {
            List<Country> searchCountry = _countryRepo.Read();
            foreach (Country country in _countryRepo.Read())
            {
                if (country.CountryName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    country.InternationalCallingCode.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchCountry = searchCountry.Where(p => p.CountryName.ToUpper().Contains(search.ToUpper()) || p.InternationalCallingCode.Contains(search.ToUpper())).ToList();
                    searchCountry.Add(country);
                }
            }
            if (searchCountry.Count == 0)
            {
                throw new ArgumentException("Could not find, try another");
            }
            return searchCountry;
        }
    }
}
