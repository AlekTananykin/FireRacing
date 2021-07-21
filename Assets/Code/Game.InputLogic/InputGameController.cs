using Assets.Code.Tools;
using Assets.Profile;
using Assets.Tools;
using UnityEngine;

public class InputGameController : BaseController
{
    public InputGameController(
        SubscriptionProperty<float> leftMove,
        SubscriptionProperty<float> rightMove, Car car)
    {
        _view = LoadView();
        _view.Init(leftMove, rightMove, car.Speed);
    }

    private readonly ResourcePath _viewPath = new ResourcePath
    {
        PathResource = "Prefabs/InputJoystickView"
    };

    private BaseInputView _view;

    private BaseInputView LoadView()
    {
        GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObject(objView);
        return objView.GetComponent<BaseInputView>();
    }

    protected override void OnDispose()
    {
    }
}
