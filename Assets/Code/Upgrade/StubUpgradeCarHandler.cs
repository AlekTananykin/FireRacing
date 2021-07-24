using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Upgrade
{
    class StubUpgradeCarHandler : IUpgradeCarHandler
    {
        public static readonly IUpgradeCarHandler Default = 
            new StubUpgradeCarHandler();

        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            return upgradableCar;
        }
    }
}
