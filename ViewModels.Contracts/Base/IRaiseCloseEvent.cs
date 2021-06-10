using System;

namespace ViewModels.Contracts.Base
{
    public interface IRaiseCloseEvent
    {
        public event EventHandler Closed;
    }
}