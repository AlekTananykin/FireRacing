using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtleFieldView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _moneyCountText;

    [SerializeField]
    private TMP_Text _healthCountText;

    [SerializeField]
    private TMP_Text _powerCountText;

    [SerializeField]
    private TMP_Text _enemyPowerCountText;

    [SerializeField]
    private Button _addCoinsButton;

    [SerializeField]
    private Button _minusCoinsButton;

    [SerializeField]
    private Button _addHealthButton;

    [SerializeField]
    private Button _minusHealthButton;

    [SerializeField]
    private Button _addPowerButton;

    [SerializeField]
    private Button _minusPowerButton;

    [SerializeField]
    private Button _fightButton;

    [SerializeField]
    private Button _addCrymeButton;

    [SerializeField]
    private Button _minusCrymeButton;

    [SerializeField]
    TMP_Text _enemyCrymeText;

    [SerializeField]
    private Button _peaceButton;

    [SerializeField]
    private Button _leaveButtleField;

    public TMP_Text MoneyCountText => _moneyCountText;
    public TMP_Text HealthCountText => _healthCountText;
    public TMP_Text PowerCountText => _powerCountText;
    public TMP_Text EnemyPowerCountText => _enemyPowerCountText;
    public Button AddCoinsButton => _addCoinsButton;
    public Button MinusCoinsButton => _minusCoinsButton;
    public Button AddHealthButton => _addHealthButton;
    public Button MinusHealthButton => _minusHealthButton;
    public Button AddPowerButton => _addPowerButton;
    public Button MinusPowerButton => _minusPowerButton;
    public Button FightButton => _fightButton;
    public Button AddCrymeButton => _addCrymeButton;
    public Button MinusCrymeButton => _minusCrymeButton;
    public TMP_Text EnemyCrymeText => _enemyCrymeText;
    public Button PeaceButton => _peaceButton;
    public Button LeaveButtleField => _leaveButtleField;
}
