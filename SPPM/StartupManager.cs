using Domain.Services;
using DomainModel.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ViewModels.Contracts.Login;
using ViewModels.Login;
using Views.LogIn;

namespace SPPM
{
    public static class StartupManager
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // services.AddSingleton<ITextService, TextService>();
                    services.AddScoped<LogInWindow>();
                    services.AddScoped<ILoginViewModel, LoginViewModel>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                });
    }
}