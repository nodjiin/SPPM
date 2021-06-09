using System.Windows.Input;

namespace ViewModels.Contracts.Login
{
    public interface ILoginViewModel
    {
        string Username { get; set; }
        ICommand AuthenticateCommand { get; }
    }
}