using System.Collections.Generic;

namespace SimpleAccountBook.Entities
{
    public class User : EntityBase
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public string IsEmailVerified { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
    }
}
