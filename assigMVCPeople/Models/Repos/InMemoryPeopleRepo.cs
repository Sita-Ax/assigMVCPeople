namespace assigMVCPeople.Models.Repos
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        //Save every people and give them an id
        static int idCounter = 0;
        static List<Person> persons = new List<Person>();
        public Person Create(string name,string phoneNumber, string city)
        {
            Person person = new Person(name, phoneNumber, city);
            person.Id = ++idCounter;
            person.Name = name;
            person.PhoneNumber = phoneNumber;
            person.City = city;
            persons.Add(person);
            return person;
        }

        public List<Person> GetAll()
        {
            return persons;
        }

        public List<Person> Read(string search)
        {
            List<Person> personList = new List<Person>();
            if(!string.IsNullOrEmpty(search))
            {
                persons = new List<Person>();
            }
            foreach(Person aPerson in persons)
            {
                if(aPerson.Name == search)
                {
                    personList.Add(aPerson);
                }
            }
            return personList;
        }

        public Person? Read(int id)
        {
            Person? person = null;
            foreach(Person aPerson in persons)
            {
                if(aPerson.Id == id)
                {
                    person = aPerson;
                    break;
                }
            }
            return person;
        }

        public bool Delete(Person person)
        {
            return persons.Remove(person);
        }

        public bool Update(Person person)
        {
            Person? personToUpdate = Read(person.Id);
            if(personToUpdate != null)
            {
                personToUpdate.Name = person.Name;
                personToUpdate.PhoneNumber = person.PhoneNumber;
                personToUpdate.City = person.City;
            }
            return true;
        }
    }
}
