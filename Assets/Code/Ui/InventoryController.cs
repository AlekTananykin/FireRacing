﻿using Assets.Code.Item;
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
        private readonly IInventoryView _inventoryWindowView;


        public InventoryController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository,
            [NotNull] IInventoryView inventoryView)
        {
            _inventoryModel = inventoryModel ?? 
                throw new ArgumentNullException(nameof(inventoryModel));

            _itemsRepository = itemsRepository ??
                throw new ArgumentNullException(nameof(itemsRepository));

            _inventoryWindowView = inventoryView ??
                throw new ArgumentNullException(nameof(inventoryView));
        }

        public void HideInventory()
        {
            throw new NotImplementedException();
        }

        public void ShowInventory(Action callback)
        {
            throw new NotImplementedException();
        }

        protected override void OnDispose()
        {
        }
    }
}
