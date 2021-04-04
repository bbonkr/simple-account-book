using System.Collections.Generic;

namespace SimpleAccountBook.Entities
{
    public class User : EntityBase
    {

        public string Password { get; set; }

        public string Email { get; set; }

        public string IsEmailVerified { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
    }
}
