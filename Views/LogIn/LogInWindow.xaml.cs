using System;
using System.Windows;
using ViewModels.Contracts.Login;

namespace Views.LogIn
{
    public partial class LogInWindow : Window
    {
        private ILoginViewModel _viewModel;
        public LogInWindow(ILoginViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            _viewModel.Closed += (_,_) => Close();
            InitializeComponent();
        }

        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}