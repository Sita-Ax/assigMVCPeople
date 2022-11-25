using Microsoft.EntityFrameworkCore;
using assigMVCPeople.Models;
using assigMVCPeople.Models.ViewModels;

namespace assigMVCPeople.Models.DB
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }
        public DbSet<Person>? Peoples
        {
            get; set;
        }
        public DbSet<assigMVCPeople.Models.Country> Country { get; set; }
        public DbSet<assigMVCPeople.Models.ViewModels.CreateCountryViewModel> CreateCountryViewModel { get; set; }
        public DbSet<assigMVCPeople.Models.City> City { get; set; }
    }
}
