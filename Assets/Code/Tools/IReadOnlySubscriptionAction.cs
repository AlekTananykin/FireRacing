using System;

namespace Assets.Code.Tools
{
    internal interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscribeAction);
        void UnSubscribeOnChange(Action unsubscriptionAction);
    }
}
