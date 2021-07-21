using Assets.Code;
using Assets.Tools;
using UnityEngine.Advertisements;

namespace Assets.Profile
{
    public class ProfilePlayer
    {
        public ProfilePlayer(float carSpeed, UnityAdsTools unityAdsTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(carSpeed);
            AnalyticTools = new UnityAnalyticTools();
            AdsShower = unityAdsTools;
            AdsListener = unityAdsTools;
        }

        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticsTools AnalyticTools { get; }

        public IAdsShower AdsShower { get; }

        public IUnityAdsListener AdsListener { get; }
    }
}
