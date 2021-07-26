using Assets.Code.Item;
using Assets.Code.Tools;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Ui
{
    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;
        private GameObject _objView;

        private Action _hideAction;

        private readonly ResourcePath _viewPath = new ResourcePath { 
            PathResource = "Prefabs/Inventory" };

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository)
        {
            _inventoryModel = inventoryModel ?? 
                throw new ArgumentNullException(nameof(inventoryModel));

            _itemsRepository = itemsRepository ??
                throw new ArgumentNullException(nameof(itemsRepository));

            _objView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));

            _inventoryView = _objView.GetComponent<InventoryView>();
            var backButtonView = _objView.GetComponent<BackButtonView>();
            backButtonView.Init(HideInventory);
        }

        public void HideInventory()
        {
            _objView.SetActive(false);
            _hideAction?.Invoke();
        }

        public void ShowInventory(Action hideAction)
        {
            _hideAction = hideAction;
            _objView.SetActive(true);
            _inventoryView.Display(_itemsRepository.Items.Values.ToList());
        }

        protected override void OnDispose()
        {
        }
    }
}
