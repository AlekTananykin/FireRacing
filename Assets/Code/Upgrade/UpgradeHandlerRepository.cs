using Assets.Code.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Upgrade
{
    class UpgradeHandlerRepository : BaseController
    {
        public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => 
            _upgradeItemsMapById;

        private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById =
            new Dictionary<int, IUpgradeCarHandler>();

        public UpgradeHandlerRepository(
            List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
        }

        private void PopulateItems(
            ref Dictionary<int, IUpgradeCarHandler> upgradeItemsMapById, 
            List<UpgradeItemConfig> configs)
        {
            foreach (var config in configs)
                if (upgradeItemsMapById.ContainsKey(config.Id))
                    upgradeItemsMapById.Add(config.Id, 
                        CreateHandlerByType(config));
        }

        private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.Type)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeCarHandler(config.Value);
                default:
                    return StubUpgradeCarHandler.Default;
            }
        }

        protected override void OnDispose()
        {
        }
    }
}
