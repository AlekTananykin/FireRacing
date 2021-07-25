using Assets.Code.Item;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Ui
{
    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;


        public InventoryController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository)
        {
            _inventoryModel = inventoryModel ?? 
                throw new ArgumentNullException(nameof(inventoryModel));

            _itemsRepository = itemsRepository ??
                throw new ArgumentNullException(nameof(itemsRepository));

            _inventoryView = new InventoryView();

        }

        public void HideInventory()
        {
        }

        public void ShowInventory(Action callback)
        {
            
        }

        protected override void OnDispose()
        {
        }
    }
}
