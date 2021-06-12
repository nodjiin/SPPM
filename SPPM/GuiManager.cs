using System;
using System.Windows;
using DomainModel.Contracts.Authentication;
using DomainModel.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Views.LogIn;
using Views.Portfolio;

namespace SPPM
{
    public class GuiManager : IDisposable
    {
        private readonly IHost _host;

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
            var loginWindow = _host.Services.GetService<LogInWindow>();

            if (loginWindow is null)
                TraceAndExit(nameof(LogInWindow));
            else
            {
                loginWindow.Closed += HandleLoginFinishedAsync;
                loginWindow.Show();
            }
        }

        private void HandleLoginFinishedAsync(object sender, EventArgs e)
        {
            var loginService = _host.Services.GetService<IAuthenticationService>();
            if (loginService?.Status == AuthenticationStatus.Connected)
                this.DisplayAccountsPortfolioWindow();
        }

        private void DisplayAccountsPortfolioWindow()
        {
            var portfolioWindow = _host.Services.GetService<PortfolioWindow>();

            if (portfolioWindow is null) 
                TraceAndExit(nameof(PortfolioWindow));
            else
                portfolioWindow.Show();
        }

        private void TraceAndExit(string className)
        {
            // TODO trace
            Environment.Exit(-1);
        }
    }
}