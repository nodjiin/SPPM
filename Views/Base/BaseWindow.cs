using System;
using System.Windows;
using Application.Utils.Mediator;
using ViewModels.Contracts.Base;

namespace Views.Base
{
    public class BaseWindow : Window
    {
        protected readonly IMessageMediator Mediator;

        public BaseWindow(IMessageMediator mediator, IBaseViewModel viewModel)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
        
        protected void Callback(string message) => MessageBox.Show(message);
    }
}