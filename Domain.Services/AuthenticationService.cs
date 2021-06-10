using System.Threading.Tasks;
using DomainModel.Contracts.Authentication;
using DomainModel.Contracts.Services;

namespace Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public IAuthenticationStatus Status { get; }

        public AuthenticationService()
        {
        }

        public Task<IAuthenticationResponse> AuthenticateAsync(string username, string password, params object[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}