using Assets.Code;
using Assets.Profile;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    [SerializeField]
    private UnityAdsTools _unityAdsTools;
    [SerializeField]
    private DailyRewardView _dailyRewardView;
    [SerializeField]
    private CurrencyView _currencyView;
    [SerializeField]
    private StartFightView _startFightView;
    [SerializeField]
    private ButtleFieldView _buttleFieldView;

    [SerializeField]
    private AssetReference _carAssetReference;
    [SerializeField]
    private AssetReference _enemyAssetReference;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;

        _mainController = new MainController(_placeForUi, profilePlayer,
            _dailyRewardView, _currencyView, _startFightView, _buttleFieldView,
            _carAssetReference, _enemyAssetReference);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
