using Assets.Code.Item;
using System;
using System.Collections.Generic;

namespace Assets.Code.Ui
{
    internal interface IInventoryView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> itemInfoCollection);
    }
}