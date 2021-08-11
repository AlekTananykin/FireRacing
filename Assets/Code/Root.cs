using Assets.Code;
using Assets.Profile;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    [SerializeField]
    private UnityAdsTools _unityAdsTools;
    [SerializeField]
    DailyRewardView _dailyRewardView;
    [SerializeField]
    CurrencyView _currencyView;
    [SerializeField]
    StartFightView _startFightView;
    [SerializeField]
    ButtleFieldView _buttleFieldView;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;

        _mainController = new MainController(_placeForUi, profilePlayer,
            _dailyRewardView, _currencyView, _startFightView, _buttleFieldView);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
