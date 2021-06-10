using System;
using System.ComponentModel;

namespace ViewModels.Contracts.Base
{
    public interface IBaseViewModel : IDisposable, INotifyPropertyChanged
    {
    }
}