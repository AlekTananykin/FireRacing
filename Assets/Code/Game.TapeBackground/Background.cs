using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float _leftBorder;

    [SerializeField]
    private float _rightBorder;

    [SerializeField]
    private float _relativeSpeedRate;

    public void Move(float value)
    {
        transform.position += Vector3.right * _relativeSpeedRate;
        Vector3 position = transform.position;

        if (position.x <= _leftBorder)
            transform.position = new Vector3(
                _rightBorder - (_leftBorder - position.x), position.y, position.z);
        else
             if (transform.position.x >= _rightBorder)
            transform.position = new Vector3(
                _leftBorder + (_rightBorder - position.x), position.y, position.z);

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
