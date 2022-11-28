namespace assigMVCPeople.Models.Repos
{
    public interface ICountryRepo
    {
        //CRUD
        //CREATE
        Country Create(string countryName, string internationalCallingCode);

        //READ
        List<Country> Read();
        Country Read(int id);

        //UPDATE
        bool Update(Country? country);
        //DELETE
        bool Delete(Country? country);
    }
}
