
using Assets.Code.Item;
using System.Collections.Generic;

namespace Assets.Code.Ui
{
    internal interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnequipItem(IItem item);
    }
}
