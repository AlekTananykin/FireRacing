using Assets.Code.Tools;
using Assets.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
        }

        protected override void OnDispose()
        {
        }
    }
}
