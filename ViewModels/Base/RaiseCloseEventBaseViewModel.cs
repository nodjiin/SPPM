using System;
using ViewModels.Contracts.Base;

namespace ViewModels.Base
{
    public abstract class RaiseCloseEventBaseViewModel : BaseViewModel, IRaiseCloseEvent
    {
        public event EventHandler Closed;

        protected void RaiseCloseEvent() => Closed?.Invoke(this, EventArgs.Empty);
    }
}