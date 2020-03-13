using System;
using System.Collections.Generic;

namespace MyFortAPI.Data
{
    public partial class Users
    {
        public Users()
        {
            InverseLastModifiedByNavigation = new HashSet<Users>();
            Outlets = new HashSet<Outlets>();
            Visits = new HashSet<Visits>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Type { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public int LastModifiedBy { get; set; }

        public virtual Users LastModifiedByNavigation { get; set; }
        public virtual UserTypes TypeNavigation { get; set; }
        public virtual ICollection<Users> InverseLastModifiedByNavigation { get; set; }
        public virtual ICollection<Outlets> Outlets { get; set; }
        public virtual ICollection<Visits> Visits { get; set; }
    }
}
