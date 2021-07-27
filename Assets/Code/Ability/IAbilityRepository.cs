using System.Collections.Generic;
namespace Assets.Code.Ability
{
    interface IAbilityRepository
    {
        IReadOnlyDictionary<int, IAbility> AbilityMapByItemId { get; }
    }
}
