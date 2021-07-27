using Assets.Code.Ability;
using Assets.Code.Data;
using Assets.Code.Tools;
using System;
using System.Collections.Generic;


namespace Assets.Code.Ui
{
    class AbilityRepository : IRepository<int, IAbility>
    {
        private readonly Dictionary<int, IAbility> _abilityMapById =
            new Dictionary<int, IAbility>();

        public AbilityRepository(List<AbilityItemConfig> itemConfig)
        {
            PopulateItems(ref _abilityMapById, itemConfig);
        }

        private void PopulateItems(ref Dictionary<int, IAbility> abilityMapByType, 
            List<AbilityItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (abilityMapByType.ContainsKey(config.Id)) 
                    continue;
                abilityMapByType.Add(config.Id, CreateAbilityByType(config));
            }
        }

        private IAbility CreateAbilityByType(AbilityItemConfig config)
        {
            switch (config.Type)
            {
                case AbilityType.Gun:
                    return new GunAbility(config);
                default:
                    return StubAbility.Default;
            }
        }

        public IReadOnlyDictionary<int, IAbility> Collection => 
            throw new NotImplementedException();


    }
}
