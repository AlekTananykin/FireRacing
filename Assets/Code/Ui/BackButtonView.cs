using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BackButtonView : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;

    public void Init(UnityAction startGame)
    {
        _backButton.onClick.AddListener(startGame);
    }

    protected void OnDestroy()
    {
        //_backButton.onClick.RemoveAllListeners();
    }
}
