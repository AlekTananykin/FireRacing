
using Assets.Code.Data;
using Assets.Code.Item;
using Assets.Code.Tools;
using Assets.Code.Upgrade;
using Assets.Profile;
using Assets.Tools;
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

        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;

        public ShedController(
            [NotNull] IReadOnlySubscriptionProperty<float> leftMove,
            [NotNull] IReadOnlySubscriptionProperty<float> rightMove,
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

            _inventoryModel = new InventoryModel();
            _inventoryController =
                new InventoryController(_inventoryModel, 
                _upgradeItemsRepository);

            AddController(_inventoryController);


            _distanceValue = new SubscriptionProperty<float>();

            _shedView = LoadView();
            _shedView.OnEnter += OnEnter;
            _distanceValue.SubscribeOnChange(_shedView.Move);

            _leftMove = leftMove;
            _rightMove = rightMove;

            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
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
            Enter();
        }


        private readonly SubscriptionProperty<float> _distanceValue;

        private void Move(float value)
        {
            _distanceValue.Value = value;
        }

        protected override void OnDispose()
        {
            _shedView.OnEnter -= OnEnter;

            _leftMove.UnsubscribeOnChange(Move);
            _rightMove.UnsubscribeOnChange(Move);

            _distanceValue.UnsubscribeOnChange(_shedView.Move);

        }
    }
}
