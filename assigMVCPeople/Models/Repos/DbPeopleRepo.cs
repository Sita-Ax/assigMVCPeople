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
        public Person Create(Person person)
        {
            //Person person = new Person(name, phoneNumber);
            _peopleDbContext.People!.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

        public List<Person> Read()
        {
          //  if (_peopleDbContext.People == null) throw new Exception();
            return _peopleDbContext.People!.Include(person => person.City).Include(person => person.Languages).ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.People.Include(person => person.City).Include(person => person.Languages).SingleOrDefault(person => person.Id == id);
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
            _peopleDbContext.People!.Remove(person);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0) { return false; }
            return true;
        }
    }
}
