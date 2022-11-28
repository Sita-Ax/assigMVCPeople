using assigMVCPeople.Models.DB;
using Microsoft.EntityFrameworkCore;
using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models;
using System.Linq;
using System;

namespace assigMVCPeople.Models.Repos
{
    public class DbPeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DbPeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Person Create(string name, string phoneNumber)
        {
            Person person = new Person(name, phoneNumber);
            _peopleDbContext.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

        public List<Person> Read()
        {
            return _peopleDbContext.People.Include(person => person.City).ThenInclude(person => person.Country).ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.People.SingleOrDefault(person => person.Id == id);
        }

        public bool Update(Person person)
        {
            _peopleDbContext.Update(person);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }
        public bool Delete(Person person)
        {
            _peopleDbContext.Remove(person);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }
    }
}
