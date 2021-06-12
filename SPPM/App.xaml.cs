using System;
using System.Windows;
using Microsoft.Extensions.Hosting;

namespace SPPM
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private GuiManager _guiManager;
        private readonly IHost _host;

        public App()
        {
            _host = StartupManager.CreateHostBuilder(null).Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            _guiManager = new GuiManager(_host);
            _guiManager.DisplayLoginWindow();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}