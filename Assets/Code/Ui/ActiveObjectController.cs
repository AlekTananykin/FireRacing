using Assets.Tools;

namespace Assets.Code.Ui
{
    public class ActiveObjectController : BaseController
    {

        private ActiveObjectView _view;
        public ActiveObjectView View
        {
            get => _view;
            set 
            {
                _view = value;
                if (null != _view)
                    _distanceValue.SubscribeOnChange(_view.Move);
            }
        }

        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;

        public ActiveObjectController(
            IReadOnlySubscriptionProperty<float> leftMove,
            IReadOnlySubscriptionProperty<float> rightMove)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;

            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);

            _distanceValue = new SubscriptionProperty<float>();
        }

        private readonly SubscriptionProperty<float> _distanceValue;

        private void Move(float value)
        {
            _distanceValue.Value = value;
        }

        protected override void OnDispose()
        {
            _leftMove.UnsubscribeOnChange(Move);
            _rightMove.UnsubscribeOnChange(Move);

            if (null != _view)
                _distanceValue.UnsubscribeOnChange(_view.Move);
        }
    }
}
