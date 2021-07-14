using System;

namespace Assets.Tools
{
    interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnSubscriptionInChange(Action<T> unsubscribeAction);
    }
}
