using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Tools
{
    public class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        private T _value;
        private Action<T> _onChangeValue;

        public T Value
        {
            get => _value;
            set 
            {
                _value = value;
                _onChangeValue?.Invoke(_value);
            }
        }

        public void SubscribeOnChange(Action<T> subscriptionAction)
        {
            _onChangeValue += subscriptionAction;
        }

        public void UnsubscribeOnChange(Action<T> unsubscribeAction)
        {
            _onChangeValue -= unsubscribeAction;
        }
    }
}
