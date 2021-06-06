using System.Collections.Generic;
using Domain.Model.Contracts.Foundation;

#nullable disable

namespace Domain.Model
{
    public partial class Profile : IUserIdentity
    {
        public Profile()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
