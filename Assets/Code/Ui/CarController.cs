using Assets.Code.Ability;
using Assets.Code.Tools;
using JetBrains.Annotations;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Code.Ui
{
    public class CarController : BaseController, IAbilityActivator
    {
        private CarView _carView;
        AsyncOperationHandle<GameObject> _handle;

        public CarController([NotNull] AssetReference carAssetReference)
        {
            _handle =
                Addressables.InstantiateAsync(carAssetReference);
            _handle.Completed += GetView;
        }

        private void GetView(AsyncOperationHandle<GameObject> obj)
        {
            if (_carView == null)
                _carView = obj.Result.GetComponent<CarView>();
        }

        public GameObject GetViewObject()
        {
            return _carView?.gameObject;
        }

        protected override void OnDispose()
        {
            _handle.Completed -= GetView;
            Addressables.ReleaseInstance(_handle);
        }
    }

}
