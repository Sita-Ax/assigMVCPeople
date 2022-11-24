using Microsoft.EntityFrameworkCore;

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
    }
}
