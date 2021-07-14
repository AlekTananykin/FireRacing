using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void UnSubscriptionOnChange(Action unsubscriptionAction)
        {
            _action -= unsubscriptionAction;
        }
    }
}
