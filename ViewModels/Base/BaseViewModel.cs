using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Application.Utils.Mediator;
using ViewModels.Contracts.Base;

namespace ViewModels.Base
{
    public abstract class BaseViewModel : IBaseViewModel
    {
        protected readonly IMessageMediator Mediator;

        protected BaseViewModel(IMessageMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}