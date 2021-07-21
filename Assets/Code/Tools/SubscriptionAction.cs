using System;

namespace Assets.Code.Tools
{
    class SubscriptionAction : IReadOnlySubscriptionAction
    {
        Action _action;

        public void Invoke()
        {
            _action?.Invoke();
        }
        public void SubscribeOnChange(Action subscribeAction)
        {
            _action += subscribeAction;
        }

        public void UnSubscribeOnChange(Action unsubscriptionAction)
        {
            _action -= unsubscriptionAction;
        }
    }
}
