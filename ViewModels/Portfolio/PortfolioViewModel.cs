using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Application.Utils.Command;
using Application.Utils.Extension;
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
        private readonly IUnitOfWork _unitOfWork;
        public PortfolioViewModel(IMessageMediator mediator, IUnitOfWork unitOfWork) : base(mediator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(UnitOfWork));
            SaveCommand = new RelayCommand(Save);
            Accounts = new ObservableCollection<Account>();
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
                    // TODO add Username and others mandatory informations.
                    _unitOfWork.Accounts.AddRange(e.NewItems?.OfType<Account>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _unitOfWork.Accounts.RemoveRange(e.OldItems?.OfType<Account>());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}