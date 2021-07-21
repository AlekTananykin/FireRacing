using UnityEngine;

namespace Assets.Code.Data
{
    [CreateAssetMenu(fileName ="Item", menuName ="Item", order = 0)]
    internal class ItemConfig: ScriptableObject
    {
        [SerializeField]
        int _id;
        [SerializeField]
        string _title;

        public int Id => _id;
        public string Title => _title;
    }
}
