using System;
using System.Threading.Tasks;
using Domain.Model.Authentication;
using DomainModel.Contracts.Authentication;
using DomainModel.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private ILogger<AuthenticationService> _logger;
        public AuthenticationService(ILogger<AuthenticationService> logger)
        {
            _logger = logger;
            Status = AuthenticationStatus.Unauthenticated;
        }

        public AuthenticationStatus Status { get; private set; }

        public async Task<IAuthenticationResponse> AuthenticateAsync(string username, string password, params object[] args)
        {
            _logger.LogInformation($"Authenticating user: {username}");
            
            // TODO authentication
            Status = AuthenticationStatus.Authenticated;
            return await Task.Run(() => new AuthenticationResponse(true));
        }
    }
}