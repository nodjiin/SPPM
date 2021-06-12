﻿using Application.Utils.Mediator;
using Domain.Services;
using DomainModel.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<LogInWindow>();
                    services.AddScoped<ILoginViewModel, LoginViewModel>();
                    services.AddScoped<PortfolioWindow>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<IMessageMediator, MessageMediator>();
                });
    }
}