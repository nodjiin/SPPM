using DomainModel.Contracts.Foundation;

#nullable disable

namespace DomainModel
{
    public class Account : IHasId, IHasUsername, IHasPassword
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Password { get; set; }
        public string Target { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
