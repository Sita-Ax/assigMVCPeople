﻿namespace assigMVCPeople.Models.Repos
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        //Save every people and give them an id
        static int idCounter = 0;
        static List<Person> persons = new List<Person>();
        public Person Create(string name,string phoneNumber)
        {
            Person person = new Person(name, phoneNumber);
            person.Id = ++idCounter;
            person.Name = name;
            person.PhoneNumber = phoneNumber;
            persons.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return persons;
        }

        public Person Read(int id)
        {
            foreach(Person aPerson in persons)
            {
                if(aPerson.Id == id)
                {
                   return aPerson;
                }
            }
            return null;
        }

        public bool Update(Person person)
        {
            Person? personToUpdate = Read(person.Id);
            if (personToUpdate == null)
            {
                return false;
            }
            else 
            { 
                personToUpdate.Name = person.Name;
                personToUpdate.PhoneNumber = person.PhoneNumber;
                personToUpdate.City = person.City;
                return true;
            }
           
        }
        public bool Delete(Person person)
        {
            return persons.Remove(person);
        }

    }
}
