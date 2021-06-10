using System;
using ViewModels.Contracts.Base;

namespace ViewModels.Base
{
    public class RaiseCloseEventBaseViewModel : IRaiseCloseEvent
    {
        public event EventHandler Closed;

        public void RaiseCloseEvent()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}