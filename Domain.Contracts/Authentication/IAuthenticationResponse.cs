namespace DomainModel.Contracts.Authentication
{
    public interface IAuthenticationResponse
    {
        public bool AuthenticationSuccessful { get; }
        public string AuthenticationError { get; }
    }
}