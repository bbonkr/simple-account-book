using System.Collections.Generic;

namespace SimpleAccountBook.Entities
{
    public class User : EntityBase
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public bool IsEmailVerified { get; set; } = false;

        public bool IsLocked { get; set; } = false;

        public int FailureCount { get; set; } = 0;

        public virtual ICollection<Business> Businesses { get; set; }
    }
}
