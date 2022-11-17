namespace assigMVCPeople.Models
{
    public class Person
    {
        public Person(string? name, string? phoneNumber, string? city)
        {            
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        
    }
}
