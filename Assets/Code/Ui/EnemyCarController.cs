using Assets.Code.Tools;
using Assets.Code.Ui;
using Assets.Profile;
using Assets.Tools;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyCarController: ActiveObjectController
{
    private Vector3 _position;

    private readonly ResourcePath _viewPath =
           new ResourcePath { PathResource = "Prefabs/EnemyCar" };

    private ProfilePlayer _profile;

    public EnemyCarController(ProfilePlayer profile,
            [NotNull] IReadOnlySubscriptionProperty<float> leftMove,
            [NotNull] IReadOnlySubscriptionProperty<float> rightMove)
        :base(leftMove, rightMove)
    {
        View = LoadView();
        View.OnEnter += IntruderIsDetected;

        _position = new Vector3(10f, -2.3f, -0.2f);
        View.transform.position = _position;
        _profile = profile;
    }

    private ActiveObjectView LoadView()
    {
        var objView = UnityEngine.Object.Instantiate(
            ResourceLoader.LoadPrefab(_viewPath));
        AddGameObject(objView);

        return objView.AddComponent<ActiveObjectView>();
    }

    private void IntruderIsDetected(GameObject intruder)
    {
        _profile.CurrentState.Value = Assets.Code.GameState.StartFight;
    }

    protected override void OnDispose()
    {
        base.OnDispose();

        View.OnEnter -= IntruderIsDetected;
    }
}
