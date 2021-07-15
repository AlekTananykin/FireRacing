using Assets.Tools;
using JoostenProductions;
using UnityEngine;

namespace Assets.Code.Game.InputLogic
{
    internal class InputAcceleration : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        protected void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            Vector3 direction = Vector3.zero;
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;

            if (direction.sqrMagnitude > 1)
                direction.Normalize();

            OnRightMove(direction.sqrMagnitude / 20 * _speed);
        }
    }
}
