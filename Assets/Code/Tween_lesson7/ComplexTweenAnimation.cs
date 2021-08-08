using DG.Tweening;
using UnityEngine;

public class ComplexTweenAnimation : MonoBehaviour
{

    [SerializeField]
    private float _duration;

    [SerializeField]
    private int _countLoops;

    [SerializeField]
    private float _positionX;

    [SerializeField]
    private float _endScale;

    private void ComplexTween()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveY(_positionX,
           _duration)).SetLoops(_countLoops).SetEase(Ease.InExpo);
        sequence.Insert(0, transform.DOScale(_endScale, _duration));
        sequence.Insert(1, transform.DOJump(Vector3.forward, 5, 5, _duration));

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            ComplexTween();
    }
}
