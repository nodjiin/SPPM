using System;

namespace Application.Utils.Mediator
{
    public interface IMessageMediator
    {
        void Register(MediatorToken token, Action<string> callback);
        void Unregister(MediatorToken token, Action<string> callback);
        void SendMessage(MediatorToken token, string message);
    }
}