﻿using Microsoft.EntityFrameworkCore;
using assigMVCPeople.Models;
using assigMVCPeople.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assigMVCPeople.Models.DB
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }
        public DbSet<Person>? Peoples { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Country>? Countries { get; set; }
    }
}
