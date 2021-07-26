
using Assets.Code.Item;
using Assets.Code.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Ui
{

    class InventoryView: MonoBehaviour, IInventoryView
    {
        private readonly ResourcePath _slotPath = new ResourcePath
        {
            PathResource = "Prefabs/InventorySlot"
        };

        [SerializeField]
        private GameObject _itemViewPanel;

        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        private List<IItem> _itemInfoCollection;

        private GameObject _slotPrefab;

        public void Display(List<IItem> itemInfoCollection) 
        {
            _itemInfoCollection = itemInfoCollection;

            if (null == _slotPrefab)
                _slotPrefab = ResourceLoader.LoadPrefab(_slotPath);

            for (int i = 0; i < itemInfoCollection.Count; ++i)
            {
                var itemView = GameObject.Instantiate<GameObject>(_slotPrefab);
                var slotButton = itemView.GetComponent<Button>();
                slotButton.onClick.AddListener(Listener);

                itemView.transform.parent = _itemViewPanel.transform;
                var text = itemView.GetComponentInChildren<Text>();
                text.text = itemInfoCollection[i].Info.Title;
            }
        }

        protected virtual void OnSelected(IItem e)
        {
            Selected?.Invoke(this, e);
        }

        protected virtual void OnDeselected(IItem e)
        {
            Deselected?.Invoke(this, e);
        }

        private void Listener()
        {
            Debug.Log("Listen!");
        }
    }
}
