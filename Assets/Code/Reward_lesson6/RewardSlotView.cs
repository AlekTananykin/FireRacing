using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardSlotView : MonoBehaviour
{
    [SerializeField]
    private Image _selectBackground;

    [SerializeField]
    private Image _iconCurrency;

    [SerializeField]
    private TMP_Text _textDays;

    [SerializeField]
    private TMP_Text _countReward;

    public void SetData(Reward reward, int daysCount, bool isSelect)
    {
        _iconCurrency.sprite = reward.IconCurrency;
        _textDays.text = $"Dat {daysCount}";
        _countReward.text = reward.CountCurrency.ToString();
        _selectBackground.gameObject.SetActive(isSelect);
    }
}
