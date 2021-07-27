using System.Collections.Generic;
namespace Assets.Code.Tools
{
    internal interface IRepository <Key, Value>
    {
        IReadOnlyDictionary<Key, Value> Collection { get; }
    }
}
