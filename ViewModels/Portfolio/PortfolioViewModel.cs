using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Application.Utils.Mediator;
using Domain.Model;
using ViewModels.Base;
using ViewModels.Contracts.Portfolio;

namespace ViewModels.Portfolio
{
    public class PortfolioViewModel : BaseViewModel, IPortfolioViewModel
    {
        public PortfolioViewModel(IMessageMediator mediator) : base(mediator)
        {
        }

        public ObservableCollection<Account> Accounts { get; }
        public ICommand SaveCommand { get; }
    }
}