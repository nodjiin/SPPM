using System.Collections.ObjectModel;
using System.Windows.Input;
using Domain.Model;

namespace ViewModels.Contracts.Portfolio
{
    public interface IPortfolioViewModel
    {
        ObservableCollection<Account> Accounts { get; }

        ICommand SaveCommand { get; }
    }
}