namespace Assets.Code.Upgrade
{
    internal class SpeedUpgradeCarHandler : IUpgradeCarHandler
    {
        private float _speed;

        public SpeedUpgradeCarHandler(float speed)
        {
            this._speed = speed;
        }

        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            upgradableCar.Speed = _speed;
            return upgradableCar;
        }
    }
}