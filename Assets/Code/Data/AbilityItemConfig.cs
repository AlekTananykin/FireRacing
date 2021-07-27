
using UnityEngine;

namespace Assets.Code.Data
{
    [CreateAssetMenu(fileName = "AbilityItem", menuName = "Ability item", order = 0)]
    class AbilityItemConfig : ScriptableObject
    {
        [SerializeField]
        private ItemConfig _itemConfig;

        [SerializeField]
        public GameObject _view;

        [SerializeField]
        public AbilityType _type;

        [SerializeField]
        public float _value;

        public ItemConfig ItemConfig => _itemConfig;
        public GameObject View => _view;
        public AbilityType Type => _type;
        public int Id => _itemConfig.Id;

    }
}
