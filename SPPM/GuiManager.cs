using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Views.LogIn;

namespace SPPM
{
    public class GuiManager : IDisposable
    {
        private readonly IHost _host;
        private Window _loginWindow;

        public GuiManager(IHost host)
        {
            _host = host;
        }

        public void Dispose()
        {
            // TODO dispose
            // _loginWindow.Dispose();
        }

        public void DisplayLoginWindow()
        {
            _loginWindow = _host.Services.GetService<LogInWindow>();

            if (_loginWindow is null)
                // TODO log & error message
                Environment.Exit(-1);

            _loginWindow.Closed += DisplayAccountsPortfolioWindow;
            _loginWindow.Show();
        }

        private void DisplayAccountsPortfolioWindow(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}