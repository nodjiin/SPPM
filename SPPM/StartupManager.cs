using System;
using System.IO;
using Application.Utils.Mediator;
using Domain.Services;
using DomainModel.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ViewModels.Contracts.Login;
using ViewModels.Login;
using Views.LogIn;
using Views.Portfolio;

namespace SPPM
{
    public static class StartupManager
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logBuilder =>
                {
                    logBuilder
                        .ClearProviders()
                        .AddDebug()
                        .AddEventLog();
                })
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddScoped<LogInWindow>()
                        .AddScoped<ILoginViewModel, LoginViewModel>()
                        .AddScoped<PortfolioWindow>()
                        .AddSingleton<IAuthenticationService, AuthenticationService>()
                        .AddSingleton<IMessageMediator, MessageMediator>()
                        .AddSingleton<GuiManager>();
                });
    }
}