
using System.Collections.Generic;
using UnityEngine.Analytics;



public class UnityAnalyticTools : IAnalyticsTools
{
    public void SendMessage(string eventName)
    {
        Analytics.CustomEvent(eventName);
    }

    public void SendMessage(string eventName, (string, object) data)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            [data.Item1] = data.Item2
        };
        Analytics.CustomEvent(eventName, parameters);
    }
}

