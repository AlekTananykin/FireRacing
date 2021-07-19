using Assets.Code;
using Assets.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Profile
{
    public class ProfilePlayer
    {
        public ProfilePlayer(float carSpeed)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(carSpeed);
            AnalyticTools = new UnityAnalyticTools();
        }

        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticsTools AnalyticTools { get; }
    }
}
