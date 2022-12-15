using Microsoft.EntityFrameworkCore;
using assigMVCPeople.Models;
using assigMVCPeople.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace assigMVCPeople.Models.DB
{
    public class PeopleDbContext : IdentityDbContext<AppUser>
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }
        public DbSet<Person>? People { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Language>? Languages { get; set; }
        //public DbSet<AppUser>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //      seed data
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<AppUser>().HasKey(p => new AppUser { p.Id, p.Id);
            //    modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Zita Ax", PhoneNumber = "+46703000011", CityId = 1, LanguageId = 1 });
            //    modelBuilder.Entity<Person>().HasMany(p => p.Languages).WithMany(c => c.People).UsingEntity(j => j.HasData(new { PeopleId = 1, Languages = "Swedish" }));
        }
    }
}
