using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenSphere : MonoBehaviour
{
    [SerializeField]
    private float _duration;

    [SerializeField]
    private PathType _pathType = PathType.Linear;

    [SerializeField]
    private Transform[] _points;

    private List<Vector3> _pointPosition = new List<Vector3>();
    void Start()
    {
        foreach (var point in _points)
            _pointPosition.Add(point.position);

        transform.DOPath(_pointPosition.ToArray(), 
            _duration, _pathType);
    }

    void Update()
    {
        
    }
}
