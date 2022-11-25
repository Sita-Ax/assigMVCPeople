namespace assigMVCPeople.Models
{
    public class City
    {
        public City(string? cityName, string? zipCode )
        {
            CityName = cityName;
            ZipCode = zipCode;
            
        }

        public int CityId { get; set; }
        public string? ZipCode { get; set; }
        public string? CityName { get; set; }

    }
}
