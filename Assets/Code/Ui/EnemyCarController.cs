using Assets.Code.Tools;
using Assets.Code.Ui;
using Assets.Profile;
using Assets.Tools;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyCarController: ActiveObjectController
{
    private Vector3 _position;

    private readonly ResourcePath _viewPath =
           new ResourcePath { PathResource = "Prefabs/EnemyCar" };

    private ProfilePlayer _profile;

    public EnemyCarController(ProfilePlayer profile,
            [NotNull] IReadOnlySubscriptionProperty<float> leftMove,
            [NotNull] IReadOnlySubscriptionProperty<float> rightMove,
            [NotNull] AssetReference enemyAssetReference)
        :base(leftMove, rightMove)
    {
        View = LoadView(enemyAssetReference);
        View.OnEnter += IntruderIsDetected;

        _position = new Vector3(10f, -2.3f, -0.2f);
        View.transform.position = _position;
        _profile = profile;
    }

    private ActiveObjectView LoadView(AssetReference enemyAssetReference)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(enemyAssetReference);

        if (handle.Status !=
            UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            Debug.Log("EnemyCarController: Addressable prefab has not ready. ");
        }
        var objView = handle.Result;

        return objView.AddComponent<ActiveObjectView>();
    }

    private void IntruderIsDetected(GameObject intruder)
    {
        _profile.CurrentState.Value = Assets.Code.GameState.Fight;
    }

    protected override void OnDispose()
    {
        base.OnDispose();

        View.OnEnter -= IntruderIsDetected;
    }
}
