using System.Windows;
using ViewModels.Contracts.Portfolio;

namespace Views.Portfolio
{
    public partial class PortfolioWindow : Window
    {
        public PortfolioWindow(IPortfolioViewModel portfolioViewModel)
        {
            InitializeComponent();
        }
        
        private void CloseWindowButtonClick(object sender, RoutedEventArgs e) => Close();
    }
}