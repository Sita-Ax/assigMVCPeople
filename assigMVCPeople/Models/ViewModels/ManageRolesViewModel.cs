using Microsoft.AspNetCore.Identity;

namespace assigMVCPeople.Models.ViewModels
{
    public class ManageRolesViewModel
    {
        public IdentityRole Role { get; set; }
        public IList<AppUser> UsersWithRole { get; set; }
        public IList<AppUser> UsersNoRole { get; set; }

    }
}
