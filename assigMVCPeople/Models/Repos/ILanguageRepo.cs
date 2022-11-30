using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Repos
{
    public interface ILanguageRepo
    {
         Create Language (Language language);

        //READ

        List<Language> Read();
        Language Read(int id);

        //UPDATE
        bool Update(Language language);
        //DELETE
        bool Delete(Language? language);
    }
}

