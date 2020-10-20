using Microsoft.AspNetCore.Identity;

namespace Oms.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

    }
}
