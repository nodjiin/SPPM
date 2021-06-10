using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Utils.Mediator
{
    public class MessageMediator : IMessageMediator
    {
        private readonly IDictionary<MediatorToken, List<Action<string>>> _actionDictionary;

        public MessageMediator()
        {
            _actionDictionary = new Dictionary<MediatorToken, List<Action<string>>>();
        }

        public void Register(MediatorToken token, Action<string> callback)
        {
            if (!_actionDictionary.ContainsKey(token))
            {
                _actionDictionary.Add(token, new List<Action<string>> { callback });
                return;
            }
            
            if(_actionDictionary[token].All(i => i.Method.ToString() != callback.Method.ToString()))
                _actionDictionary[token].Add(callback);
        }

        public void Unregister(MediatorToken token, Action<string> callback)
        {
            if (_actionDictionary.ContainsKey(token))
                _actionDictionary[token].Remove(callback);
        }

        public void SendMessage(MediatorToken token, string message)
        {
            if (_actionDictionary.ContainsKey(token))
                _actionDictionary[token].ForEach(callback => callback?.Invoke(message));
        }
    }
}