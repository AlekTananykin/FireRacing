
using Assets.Code.Data;
using Assets.Code.Item;
using Assets.Code.Tools;
using Assets.Code.Upgrade;
using Assets.Profile;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Code.Ui
{
    class ShedController : BaseController, IShedController
    {
        private readonly Car _car;

        private readonly ResourcePath _viewPath = 
            new ResourcePath { PathResource = "Prefabs/Shed" };
        private readonly CarView _carView;

        private readonly UpgradeHandlerRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryController _inventoryController;
        private readonly IInventoryView _inventoryView;

        private ShedView _shedView;

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

            _shedView = LoadView();
            _shedView.OnEnter += OnEnter;

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


        private ShedView LoadView()
        {
            var objView = UnityEngine.Object.Instantiate(
                ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(objView);

            return objView.AddComponent<ShedView>();
        }

        private void OnEnter(GameObject guest)
        {
            if (!guest.CompareTag("Player"))
                return;

            Enter();
        }

        protected override void OnDispose()
        {
            _shedView.OnEnter -= OnEnter;
        }
    }
}
