using System;
using System.Windows;
using Application.Utils.Mediator;
using ViewModels.Contracts.Base;
using ViewModels.Contracts.Login;
using Views.Base;

namespace Views.LogIn
{
    public partial class LogInWindow : BaseWindow
    {
        public LogInWindow(IMessageMediator mediator, ILoginViewModel viewModel) : base(mediator, viewModel)
        {
            mediator.Register(MediatorToken.LoginToken, Callback);
            WeakEventManager<IRaiseCloseEvent, EventArgs>.AddHandler(viewModel, nameof(IRaiseCloseEvent.Closed), (_,_) => Close());
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            Mediator.Unregister(MediatorToken.LoginToken, Callback);
            base.OnClosed(e);
        }
        
        private void CloseWindowButtonClick(object sender, RoutedEventArgs e) => Close();
    }
}