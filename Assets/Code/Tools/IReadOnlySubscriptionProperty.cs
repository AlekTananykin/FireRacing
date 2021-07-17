using System;

namespace Assets.Tools
{
    public interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnsubscribeOnChange(Action<T> unsubscribeAction);
    }
}
