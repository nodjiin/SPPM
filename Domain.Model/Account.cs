using System.ComponentModel.DataAnnotations.Schema;
using Domain.Model.Contracts.Foundation;

#nullable disable

namespace Domain.Model
{
    public class Account : IHasId, IHasUsername, IHasPassword
    {
        public int ProfileId { get; set; }
        public string Target { get; set; }
        public string Name { get; set; }

        public virtual Profile Profile { get; set; }
        
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}