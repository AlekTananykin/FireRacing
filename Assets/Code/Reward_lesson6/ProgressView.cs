using UnityEngine;
using UnityEngine.UI;

public class ProgressView : MonoBehaviour
{
    [SerializeField]
    private Image _indicator;

    [SerializeField]
    private Image _bar;

    private float _indicatorValue;
    float _barWidth;

    private void Start()
    {
        _barWidth = _bar.rectTransform.rect.width; 
    }

    public float Indicator
    {
        get => _indicatorValue;
        set
        {
            _indicatorValue = value;
            if (_indicatorValue < 0)
                _indicatorValue = 0;

            if (_indicatorValue > 1.0)
                _indicatorValue = 1.0f;

            _indicator.rectTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Horizontal, _indicatorValue * _barWidth);
        }
    }
}
