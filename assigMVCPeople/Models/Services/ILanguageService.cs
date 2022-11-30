using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.Services
{
    public interface ILanguageService
    {
        Language Create(CreateLanguageViewModel createLanguage);
        List<Language> GetAll();
        List<Language> Search(string search);
        Language FindById(int id);

        //Update
        bool Edit(int id, CreateLanguageViewModel editLanguage);
        //Delete
        bool Remove(int id);
    }
}
