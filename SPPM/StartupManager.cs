using System;
using System.IO;
using Application.Utils.Mediator;
using Domain.Services;
using DomainModel.Contracts.Services;
using Infrastructure.Contracts.Repositories.Foundation;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ViewModels.Contracts.Login;
using ViewModels.Contracts.Portfolio;
using ViewModels.Login;
using ViewModels.Portfolio;
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
                        .AddScoped<IPortfolioViewModel, PortfolioViewModel>()
                        .AddScoped<IUnitOfWork, UnitOfWork>()
                        .AddSingleton<IAuthenticationService, AuthenticationService>()
                        .AddSingleton<IMessageMediator, MessageMediator>()
                        .AddSingleton<GuiManager>();
                });
    }
}