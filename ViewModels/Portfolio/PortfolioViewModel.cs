using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Application.Utils.Command;
using Application.Utils.Extension;
using Application.Utils.Mediator;
using Domain.Model;
using Infrastructure.Contracts.Repositories.Foundation;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using ViewModels.Base;
using ViewModels.Contracts.Portfolio;

namespace ViewModels.Portfolio
{
    public class PortfolioViewModel : BaseViewModel, IPortfolioViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _profileId;
        private readonly ILogger<PortfolioViewModel> _logger;
        
        public PortfolioViewModel(IMessageMediator mediator, IUnitOfWork unitOfWork, ILogger<PortfolioViewModel> logger) : base(mediator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(UnitOfWork));
            _logger = logger;
            // TODO checks to Enable save command
            SaveCommand = new RelayCommand(Save);
            Accounts = new ObservableCollection<Account>();
            _profileId = unitOfWork.Accounts.GetAssociatedProfileId();
            LoadAccounts();
            CollectionChangedEventManager.AddHandler(Accounts, UpdateRepositoryOnAccountChanges);
        }

        public ObservableCollection<Account> Accounts { get; }
        public ICommand SaveCommand { get; }

        private void LoadAccounts() => _unitOfWork.Accounts.GetAll().ForEach(a => Accounts.Add(a));
        private void Save(object _) => _unitOfWork.Complete();
        
        // private void UpdateRepositoryOnAccountChanges(object sender, NotifyCollectionChangedEventArgs e) => e.Action switch
        //     {
        //         NotifyCollectionChangedAction.Add => _unitOfWork.Accounts.AddRange((IEnumerable<Account>) e.NewItems),
        //     };

        private void UpdateRepositoryOnAccountChanges(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddNewAccounts(e.NewItems?.OfType<Account>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _unitOfWork.Accounts.RemoveRange(e.OldItems?.OfType<Account>());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddNewAccounts(IEnumerable<Account> accounts)
        {
            if (!accounts.Any()) _logger.LogError($"argument {accounts} is empty");
            _unitOfWork.Accounts.AddRange(accounts.Select(a => UpdateAccount(a)));
        }

        private Account UpdateAccount(Account account)
        {
            account.Id = _unitOfWork.Accounts.GetNewValidId();
            account.ProfileId = _profileId;
            return account;
        }
    }
}