using System;
using System.Windows;
using Application.Utils.Extension;
using DomainModel.Contracts.Authentication;
using DomainModel.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Views.LogIn;
using Views.Portfolio;

namespace SPPM
{
    public class GuiManager
    {
        private readonly IHost _host;
        private readonly ILogger<GuiManager> _logger;

        public GuiManager(IHost host, ILogger<GuiManager> logger)
        {
            _host = host;
            _logger = logger;
        }

        public void DisplayLoginWindow()
        {
            _logger.LogInformation("Initializing login window");
            var loginWindow = _host.Services.GetService<LogInWindow>();

            if (loginWindow is null)
                _logger.TraceMissingServiceAndExit(nameof(LogInWindow));
            else
            {
                WeakEventManager<LogInWindow, EventArgs>.AddHandler(loginWindow, nameof(LogInWindow.Closed), HandleLoginFinishedAsync);
                loginWindow.Show();
            }
        }

        private void HandleLoginFinishedAsync(object sender, EventArgs e)
        {
            var loginService = _host.Services.GetService<IAuthenticationService>();
            if (loginService?.Status == AuthenticationStatus.Authenticated)
                DisplayAccountsPortfolioWindow();
            else
            {
                _logger.LogError(
                    $"Authentication status after login is: {Enum.GetName(typeof(AuthenticationStatus), loginService?.Status ?? AuthenticationStatus.Unknown)} ");
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void DisplayAccountsPortfolioWindow()
        {
            _logger.LogInformation("Initializing portfolio window");
            var portfolioWindow = _host.Services.GetService<PortfolioWindow>();

            if (portfolioWindow is null) 
                _logger.TraceMissingServiceAndExit(nameof(PortfolioWindow));
            else
                portfolioWindow.Show();
        }
    }
}