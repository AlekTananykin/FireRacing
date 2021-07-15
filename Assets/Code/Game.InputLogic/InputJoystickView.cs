using Assets.Tools;
using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputJoystickView : BaseInputView
{

    public override void Init(SubscriptionProperty<float> leftMove,
        SubscriptionProperty<float> rightMove, float speed)
    {
        base.Init(leftMove, rightMove, speed);
        UpdateManager.SubscribeToUpdate(Move);
    }

    private void Move()
    {
        float moveStep = 10 * Time.deltaTime *
            CrossPlatformInputManager.GetAxis("Horizontal");

        if (moveStep > 0)
            OnRightMove(moveStep);
        else if (moveStep < 0)
            OnLeftMove(moveStep);
    }

    
}
