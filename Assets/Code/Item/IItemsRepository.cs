

using System.Collections.Generic;

namespace Assets.Code.Item
{
    internal interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}
