using Assets.Code.Tools;
using Assets.Profile;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Assets.Code.Ui
{
    class MainMenuController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private MainMenuView _view;

        public MainMenuController(Transform placeForUi,
            ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
        }

        private readonly ResourcePath _viewPath = new ResourcePath() 
            { PathResource = "Prefabs/MainMenu" };

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = UnityEngine.Object.Instantiate(
                ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObject(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game", 
                ("time", Time.realtimeSinceStartup));
            _profilePlayer.AdsShower.ShowRewardedVideo();
            Advertisement.AddListener(_profilePlayer.AdsListener);
        }

        protected override void OnDispose()
        {
            Advertisement.RemoveListener(_profilePlayer.AdsListener);
        }
    }
}
