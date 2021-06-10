using System;
using System.Windows.Input;
using Application.Utils.Command;
using Application.Utils.Mediator;
using DomainModel.Contracts.Services;
using ViewModels.Base;
using ViewModels.Contracts.Login;

namespace ViewModels.Login
{
    public class LoginViewModel : RaiseCloseEventBaseViewModel, ILoginViewModel
    {
        private readonly IMessageMediator _mediator;
        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(IMessageMediator mediator, IAuthenticationService authenticationService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _authenticationService =
                authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            AuthenticateCommand = new RelayCommand<string>(Authenticate);
        }

        public string Username { get; set; }
        public ICommand AuthenticateCommand { get; private set; }

        private async void Authenticate(string password)
        {
            var response = await _authenticationService.AuthenticateAsync(Username, password);

            if (!response.AuthenticationSuccessful)
                _mediator.SendMessage(MediatorToken.LoginToken, response.AuthenticationError);
            else
                RaiseCloseEvent();
        }

        public override void Dispose()
        {
            AuthenticateCommand = null;
            // TODO dispose AuthenticationService
        }
    }
}