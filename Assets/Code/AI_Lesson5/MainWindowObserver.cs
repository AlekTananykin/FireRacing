using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainWindowObserver : MonoBehaviour
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

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;

    private Money _money;
    private Health _health;
    private Power _power;

    private Enemy _enemy;

    void Start()
    {
        _enemy = new Enemy("Enemy Flappy");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _health = new Health(nameof(Health));
        _health.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);

        _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _minusCoinsButton.onClick.AddListener(() => ChangeMoney(false));

        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _fightButton.onClick.AddListener(Fight);

        _addCrymeButton.onClick.AddListener(() => ChangeCryme(true));

        _minusCrymeButton.onClick.AddListener(() => ChangeCryme(false));

        _peaceButton.onClick.AddListener(Peace);
        _peaceButton.gameObject.SetActive(true);
    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            ++_allCountPowerPlayer;
        else
            --_allCountPowerPlayer;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Power);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            ++_allCountHealthPlayer;
        else
            --_allCountHealthPlayer;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Health);
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            ++ _allCountMoneyPlayer;
        else
            -- _allCountMoneyPlayer;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeDataWindow(
        int countChangeData, DataType type)
    {
        switch (type)
        {
            case DataType.Money:
                _moneyCountText.text = $"Player Money {countChangeData.ToString()}";
                _money.Money = countChangeData;
                break;

            case DataType.Health:
                _healthCountText.text = $"Player Health {countChangeData.ToString()}";
                _health.Health = countChangeData;
                break;

            case DataType.Power:
                _powerCountText.text = $"Player Power {countChangeData.ToString()}";
                _power.Power = countChangeData;
                break;
        }

        _enemyPowerCountText.text = $"Enemy Power {_enemy.Power}";
    }

    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.Power
        ? "<color=#07FF00>Win!!!</color>"
        : "<color=#FF0000>Lose!!!</color>");
    }

    void ChangeCryme(bool isIncrease)
    {
        if (isIncrease)
            ++_enemy.Cryme;
        else
            --_enemy.Cryme;

        SuggestFightDecision();
        _enemyCrymeText.text = $"Enemy cryme: {_enemy.Cryme}";
    }

    void SuggestFightDecision()
    {
        if (_enemy.Cryme <= 2)
            _peaceButton.gameObject.SetActive(true);
        else
            _peaceButton.gameObject.SetActive(false);
    }

    private void Peace()
    {
        Debug.Log("<color=#07FF00>Peace!!!</color>");
    }

    private void OnDestroy()
    {
        _addCoinsButton.onClick.RemoveAllListeners();
        _minusCoinsButton.onClick.RemoveAllListeners();

        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _health.Detach(_enemy);
        _power.Detach(_enemy);
    }

    void Update()
    {
        
    }
}
