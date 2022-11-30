using assigMVCPeople.Models.DB;

namespace assigMVCPeople.Models.Repos
{
    public class DbLanguageRepo : ILanguageRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DbLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Language Create(Language language)
        {
            // City city = new City(cityName, zipCode);
            _peopleDbContext.Cities.Add(Language);
            _peopleDbContext.SaveChanges();
            return Language;
        }

        public List<Language> Read()
        {
            return _peopleDbContext.Languages!.Include(Language => Languag.People).ToList();
        }

        public Language Read(int id)
        {
            return _peopleDbContext.Languages!.Include(Language => Language.People).SingleOrDefault(leanguag => Language.languageId == id);
        }

        public bool Update(Language Language)
        {
            _peopleDbContext.Languages!.Update(Language);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }

        public bool Delete(Language Language)
        {
            _peopleDbContext.Languages!.Remove(language);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }
    }
}
