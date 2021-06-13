using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Application.Utils.Command;
using Application.Utils.Mediator;
using Domain.Model;
using Infrastructure.Contracts.Repositories.Foundation;
using Infrastructure.Repository;
using ViewModels.Base;
using ViewModels.Contracts.Portfolio;

namespace ViewModels.Portfolio
{
    public class PortfolioViewModel : BaseViewModel, IPortfolioViewModel
    {
        private IUnitOfWork _unitOfWork;
        public PortfolioViewModel(IMessageMediator mediator, IUnitOfWork unitOfWork) : base(mediator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(UnitOfWork));
            SaveCommand = new RelayCommand(Save);
            Accounts = new ObservableCollection<Account>();
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            foreach (var account in _unitOfWork.Accounts.GetAll())
            {
                Accounts.Add(account);
            }
        }

        private void Save(object _)
        {
        }

        public ObservableCollection<Account> Accounts { get; }
        public ICommand SaveCommand { get; }
    }
}