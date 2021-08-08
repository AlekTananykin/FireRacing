using DG.Tweening;
using UnityEngine;

public class TweenCube : MonoBehaviour
{
    [SerializeField]
    private float _duration;

    [SerializeField]
    private Vector3 _endValue;

    [SerializeField]
    private Color _color;

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    void Start()
    {
        transform.DOMove(_endValue, _duration).From();
        _material.DOColor(_color, _duration);
    }
}
