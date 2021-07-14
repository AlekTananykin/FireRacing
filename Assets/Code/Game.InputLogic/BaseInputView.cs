using Assets.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInputView : MonoBehaviour
{
    public void Init(SubscriptionProperty<float> leftMove,
        SubscriptionProperty<float> rightMove, float speed)
    {
        _leftMove = leftMove;
        _rightMove = rightMove;
        _speed = speed;
    }

    protected float _speed;
    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;

    protected virtual void OnLeftMove(float value)
    {
        _leftMove.Value = value;
    }

    protected virtual void OnRightMove(float value)
    {
        _rightMove.Value = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
