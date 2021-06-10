using System;
using System.Windows.Input;
using Application.Utils.Command;
using DomainModel.Contracts.Services;
using ViewModels.Base;
using ViewModels.Contracts.Login;

namespace ViewModels.Login
{
    public class LoginViewModel : RaiseCloseEventBaseViewModel, ILoginViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        public string Username { get; set; }
        public ICommand AuthenticateCommand { get; }
        
        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            AuthenticateCommand = new RelayCommand<string>(Authenticate);
        }

        private async void Authenticate(string password)
        {
            var response = await _authenticationService.AuthenticateAsync(Username, password);

            if (!response.AuthenticationSuccessful)
            {
                // TODO display message (add mediator)
                
            }
            else
            {
                RaiseCloseEvent();
            }
        }
    }
}