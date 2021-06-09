using System.Windows;
using ViewModels.Contracts.Login;

namespace Views.LogIn
{
    public partial class LogInWindow : Window
    {
        private ILoginViewModel _viewModel;
        public LogInWindow(ILoginViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}