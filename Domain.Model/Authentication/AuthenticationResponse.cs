using DomainModel.Contracts.Authentication;

namespace Domain.Model.Authentication
{
    public class AuthenticationResponse : IAuthenticationResponse
    {
        public AuthenticationResponse(bool authenticationSuccessful, string authenticationError = null)
        {
            AuthenticationSuccessful = authenticationSuccessful;
            AuthenticationError = authenticationError;
        }

        public bool AuthenticationSuccessful { get; }
        public string AuthenticationError { get; }
    }
}