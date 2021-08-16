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
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Car" };
        private readonly CarView _carView;
        
        public CarController([NotNull]AssetReference carAssetReference)
        {
            _carView = LoadView(carAssetReference);
        }

        private CarView LoadView(AssetReference carAssetReference)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(carAssetReference);

            if (handle.Status != 
                UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                Debug.Log("CarController: Addressable prefab has not ready. ");
            }
            var objView = handle.Result;
            
            return objView.GetComponent<CarView>();
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }

        protected override void OnDispose()
        {
        }
    }
}
