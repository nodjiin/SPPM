using System;
using System.Windows.Input;
using Application.Utils.Command;
using ViewModels.Contracts.Login;

namespace ViewModels.Login
{
    public class LoginViewModel : ILoginViewModel
    {
        public string Username { get; set; }
        public ICommand AuthenticateCommand { get; }
        
        public LoginViewModel()
        {
            AuthenticateCommand = new RelayCommand(Authenticate);
        }

        private void Authenticate(object obj)
        {
            // TODO authenticate
        }
    }
}