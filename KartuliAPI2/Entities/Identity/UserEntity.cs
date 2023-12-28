using Microsoft.AspNetCore.Identity;

namespace KartuliAPI2.Entities.Identity
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
