


public interface IAnalyticsTools
{
    void SendMessage(string eventName);
    void SendMessage(string eventName, (string, object) data);
}

