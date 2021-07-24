using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Ui
{
    internal interface IInventoryController
    {
        void ShowInventory(Action callback);
        void HideInventory();
    }
}
