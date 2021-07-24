namespace Assets.Code.Upgrade
{
    public interface IUpgradableCar
    {
        float Speed { get; set; }
        void Restore();
    }
}