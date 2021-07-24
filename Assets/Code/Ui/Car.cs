using Assets.Code.Upgrade;

namespace Assets.Code.Ui
{
    class Car : IUpgradableCar
    {
        private readonly float _defaultSpeed;

        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        public float Speed 
        {
            get;set;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}
