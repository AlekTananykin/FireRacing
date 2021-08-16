using Assets.Code;
using Assets.Code.Ui;
using Assets.Profile;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MainController : BaseController
{
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer,
        DailyRewardView dailyRewardView, CurrencyView currencyView,
        StartFightView startFightView, ButtleFieldView buttleFieldView,
        AssetReference carAssetReference, AssetReference enemyAssetReference)
    {
        _carAssetReference = carAssetReference;
        _enemyAssetReference = enemyAssetReference;

        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;

        _dailyRewardView = dailyRewardView;
        _currencyView = currencyView;
        _startFightView = startFightView;
        _buttleFieldView = buttleFieldView;

        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private StartFightController _startFightController;
    private ButtleFieldController _buttleFieldController;
    private DailyRewardController _dailyRewardController;

    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private readonly DailyRewardView _dailyRewardView;
    private readonly CurrencyView _currencyView;
    private readonly StartFightView _startFightView;
    private readonly ButtleFieldView _buttleFieldView;

    private AssetReference _carAssetReference;
    private AssetReference _enemyAssetReference;

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnsubscribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                {
                    _mainMenuController = new MainMenuController(
                        _placeForUi, _profilePlayer);

                    _gameController?.Dispose();
                    _startFightController?.Dispose();
                    _buttleFieldController?.Dispose();
                    _dailyRewardController?.Dispose();
                    break;
                }
            case GameState.Game:
                {
                    _gameController = new GameController(_profilePlayer,
                        _carAssetReference,
                        _enemyAssetReference);

                    _mainMenuController?.Dispose();

                    _startFightController?.Dispose();
                    _buttleFieldController?.Dispose();
                    _dailyRewardController?.Dispose();
                    break;
                }
            case GameState.DailyReward:
                {
                    _dailyRewardController = new DailyRewardController(
                        _placeForUi, _profilePlayer, _dailyRewardView, _currencyView);

                    _dailyRewardController.RefreshView();

                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    _startFightController?.Dispose();
                    _buttleFieldController?.Dispose();
                    break;
                }
            case GameState.Fight:
                {
                    _buttleFieldController = new ButtleFieldController(
                        _profilePlayer, _placeForUi, _buttleFieldView);
                    _buttleFieldController.RefreshView();


                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    _startFightController?.Dispose();
                    _dailyRewardController?.Dispose();
                    break;
                }
            case GameState.StartFight:
                {
                    _startFightController = new StartFightController(
                        _placeForUi, _profilePlayer, _startFightView);
                    _startFightController.RefreshView();


                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    _buttleFieldController?.Dispose();
                    _dailyRewardController?.Dispose();
                    break;
                }
            default:
                {
                    AllDispose();
                    break;
                }
        }
    }

    private void AllDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
    }
}
