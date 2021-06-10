using System.Windows.Input;
using ViewModels.Contracts.Base;

namespace ViewModels.Contracts.Login
{
    public interface ILoginViewModel : IRaiseCloseEvent
    {
        string Username { get; set; }
        ICommand AuthenticateCommand { get; }
    }
}