using Microsoft.AspNetCore.Identity;

namespace assigMVCPeople.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {

        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
