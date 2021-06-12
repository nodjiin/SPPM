using System;
using System.Threading.Tasks;
using DomainModel.Contracts.Authentication;
using DomainModel.Contracts.Services;

namespace Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationStatus Status { get; }

        public Task<IAuthenticationResponse> AuthenticateAsync(string username, string password, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}