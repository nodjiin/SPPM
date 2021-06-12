using System;
using Application.Utils.Mediator;
using ViewModels.Contracts.Base;

namespace ViewModels.Base
{
    public abstract class RaiseCloseEventBaseViewModel : BaseViewModel, IRaiseCloseEvent
    {
        protected RaiseCloseEventBaseViewModel(IMessageMediator mediator) : base(mediator)
        {
        }
        
        public event EventHandler Closed;

        protected void RaiseCloseEvent() => Closed?.Invoke(this, EventArgs.Empty);
    }
}