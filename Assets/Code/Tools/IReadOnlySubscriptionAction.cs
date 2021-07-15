using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Tools
{
    internal interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscribeAction);
        void UnSubscribeOnChange(Action unsubscriptionAction);
    }
}
