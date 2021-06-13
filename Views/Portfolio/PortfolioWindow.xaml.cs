using System;
using System.Windows;
using ViewModels.Contracts.Portfolio;

namespace Views.Portfolio
{
    public partial class PortfolioWindow : Window
    {
        public PortfolioWindow(IPortfolioViewModel portfolioViewModel)
        {
            DataContext = portfolioViewModel;
            InitializeComponent();
        }
        
        private void CloseWindowButtonClick(object sender, RoutedEventArgs e) => System.Windows.Application.Current.Shutdown();
    }
}