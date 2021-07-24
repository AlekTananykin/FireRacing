using UnityEngine;

namespace Assets.Code.Data
{
    [CreateAssetMenu(fileName ="UpgradeItem", menuName="UpgradeItem", order =1)]
    internal class UpgradeItemConfig: ScriptableObject
    {
        [SerializeField]
        private ItemConfig _itemConfig;

        [SerializeField]
        private UpgradeType _type;
        [SerializeField]
        private float _value;

        public int Id => _itemConfig.Id;
        public UpgradeType Type => _type;
        public float Value => _value;

        public ItemConfig ItemConfig => _itemConfig;
    }
}
