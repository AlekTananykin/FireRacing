using UnityEngine;

public class CurrencyController : BaseController
{

    public CurrencyController(Transform uiPlace, CurrencyView currencyView)
    {
        var currencyViewInstance = Object.Instantiate(currencyView, uiPlace);
        AddGameObject(currencyView.gameObject);
    }

    protected override void OnDispose()
    {
    }
}
