using System.Threading.Tasks;
using DomainModel.Contracts.Authentication;

namespace DomainModel.Contracts.Services
{
    public interface IAuthenticationService
    {
        public AuthenticationStatus Status { get; }
        Task<IAuthenticationResponse> AuthenticateAsync(string username, string password, params object[] args);
    }
}