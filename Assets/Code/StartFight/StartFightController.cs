using Assets.Profile;
using UnityEngine;
using Object = UnityEngine.Object;


public class StartFightController : BaseController
{
    private StartFightView _startFightView;
    private ProfilePlayer _playerProfile;

    public StartFightController(Transform placeForUI, ProfilePlayer profile, 
        StartFightView startFightView)
    {
        _playerProfile = profile;

        _startFightView = Object.Instantiate(startFightView, placeForUI);
        AddGameObject(_startFightView.gameObject);
    }

    public void RefreshView()
    {
        _startFightView.StartButton.onClick.AddListener(StartFight);
    }

    public void StartFight()
    {
        _playerProfile.CurrentState.Value = Assets.Code.GameState.Fight;
    }

    protected override void OnDispose()
    {
        _startFightView.StartButton.onClick.RemoveAllListeners();
    }
}
