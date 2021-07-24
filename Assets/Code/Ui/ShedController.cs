
using Assets.Code.Data;
using Assets.Code.Item;
using Assets.Code.Upgrade;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.Ui
{
    class ShedController : BaseController, IShedController
    {
        private readonly Car _car;

        private readonly UpgradeHandlerRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryController _inventoryController;
        private readonly IInventoryView _inventoryView;

        public ShedController(
            [NotNull] List<UpgradeItemConfig> upgradeItemConfigs,
            [NotNull] Car car)
        {
            if (null == upgradeItemConfigs)
                throw new ArgumentNullException(nameof(upgradeItemConfigs));

            _car = car ?? throw new ArgumentNullException(nameof(car));
            _upgradeHandlersRepository = 
                new UpgradeHandlerRepository(upgradeItemConfigs);

            AddController(_upgradeHandlersRepository);

            _upgradeItemsRepository =
                new ItemsRepository(upgradeItemConfigs.Select(value=>
                value.ItemConfig).ToList());

            _inventoryView = new InventoryView();
            _inventoryModel = new InventoryModel();
            _inventoryController =
                new InventoryController(_inventoryModel, 
                _upgradeItemsRepository, _inventoryView);

            AddController(_inventoryController);
        }

        public void Enter()
        {
            _inventoryController.ShowInventory(Exit);
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _car, _inventoryModel.GetEquippedItems(), 
                _upgradeHandlersRepository.UpgradeItems);
        }

        private void UpgradeCarWithEquippedItems(
            Car upgradableCar, IReadOnlyList<IItem> equippedItems, 
            IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                {
                    handler.Upgrade(upgradableCar);
                }
            }
        }

        protected override void OnDispose()
        {
        }
    }
}
