using System.Collections.ObjectModel;
using System.Windows.Input;
using Domain.Model;
using ViewModels.Contracts.Base;

namespace ViewModels.Contracts.Portfolio
{
    public interface IPortfolioViewModel : IBaseViewModel
    {
        ObservableCollection<Account> Accounts { get; }

        ICommand SaveCommand { get; }
    }
}