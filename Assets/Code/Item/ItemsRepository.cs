using Assets.Code.Data;
using System;
using System.Collections.Generic;

namespace Assets.Code.Item
{
    internal class ItemsRepository : BaseController, IItemsRepository
    {
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;

        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        public ItemsRepository(List<ItemConfig> upgradeItemConfig)
        {
            PopulateItems(ref _itemsMapById, upgradeItemConfig);
        }

        private void PopulateItems(
            ref Dictionary<int, IItem> upgradeHandlers, 
            List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (!upgradeHandlers.ContainsKey(config.Id))
                    upgradeHandlers.Add(config.Id, CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            return new Item { Id = config.Id, 
                Info = new ItemInfo() 
                { 
                    Title = config.Title 
                } };
        }

        protected override void OnDispose()
        {
            _itemsMapById.Clear();
            _itemsMapById = null;
        }
    }
}
