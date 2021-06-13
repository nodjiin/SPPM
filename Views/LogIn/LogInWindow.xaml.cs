﻿using System;
using System.Windows;
using Application.Utils.Mediator;
using ViewModels.Contracts.Base;
using ViewModels.Contracts.Login;

namespace Views.LogIn
{
    public partial class LogInWindow : Window
    {
        private readonly IMessageMediator _mediator;

        public LogInWindow(IMessageMediator mediator, ILoginViewModel viewModel)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            
            _mediator.Register(MediatorToken.LoginToken, Callback);
            WeakEventManager<IRaiseCloseEvent, EventArgs>.AddHandler(viewModel, nameof(IRaiseCloseEvent.Closed), (_,_) => Close());
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            _mediator.Unregister(MediatorToken.LoginToken, Callback);
            base.OnClosed(e);
        }
        
        private void Callback(string message) => MessageBox.Show(message);
        private void CloseWindowButtonClick(object sender, RoutedEventArgs e) => Close();
    }
}