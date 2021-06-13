using System;
using System.Windows;
using Application.Utils.Mediator;
using ViewModels.Contracts.Portfolio;
using Views.Base;

namespace Views.Portfolio
{
    public partial class PortfolioWindow : BaseWindow
    {
        public PortfolioWindow(IMessageMediator mediator, IPortfolioViewModel portfolioViewModel) : base(mediator, portfolioViewModel)
        {
            Mediator.Register(MediatorToken.PortfolioToken, Callback);
            DataContext = portfolioViewModel;
            InitializeComponent();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            Mediator.Unregister(MediatorToken.PortfolioToken, Callback);
            base.OnClosed(e);
        }
        
        private void CloseWindowButtonClick(object sender, RoutedEventArgs e) => Close();
    }
}