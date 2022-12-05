using assigMVCPeople.Models.DB;
using Microsoft.EntityFrameworkCore;

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
            _peopleDbContext.Languages!.Add(language);
            _peopleDbContext.SaveChanges();
            return language;
        }

        public List<Language> Read()
        {
            return _peopleDbContext.Languages!.Include(language => language.LanguageId).ToList();
        }

        public Language Read(int id)
        {
            return _peopleDbContext.Languages!.SingleOrDefault(language => language.LanguageId == id);
        }

        public bool Update(Language language)
        {
            _peopleDbContext.Languages!.Update(language);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }

        public bool Delete(Language language)
        {
            _peopleDbContext.Languages!.Remove(language);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }
    }
}
