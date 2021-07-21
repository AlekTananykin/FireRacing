using UnityEngine;

namespace Assets.Code.Data
{
    
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", 
        menuName = "UpgradeItemConfigDataSource", order = 2)]
    class UpgradeItemConfigDataSource: ScriptableObject
    {
        [SerializeField]
        UpgradeItemConfig[] _itemConfigs;
        public UpgradeItemConfig[] ItemConfigs => _itemConfigs;
    }
}
