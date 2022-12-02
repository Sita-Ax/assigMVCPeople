using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Repos
{
    public interface ILanguageRepo
    {
        Language Create(Language language);

        List<Language> Read();
        Language Read(int id);

        bool Update(Language language);
        bool Delete(Language? language);
    }
}

