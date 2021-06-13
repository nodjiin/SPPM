using System.Security;
using System.Threading.Tasks;
using DomainModel.Contracts.Authentication;

namespace DomainModel.Contracts.Services
{
    public interface IAuthenticationService
    {
        public AuthenticationStatus Status { get; }
        Task<IAuthenticationResponse> AuthenticateAsync(string username, SecureString password, params object[] args);
    }
}