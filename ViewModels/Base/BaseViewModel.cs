using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModels.Contracts.Base;

namespace ViewModels.Base
{
    public abstract class BaseViewModel : IBaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}