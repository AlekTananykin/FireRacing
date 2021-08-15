using Assets.Profile;
using UnityEngine;

public class ButtleFieldController : BaseController
{
    private ButtleFieldView _buttleFieldView;
    private ProfilePlayer _playerProfile;


    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;

    private Money _money;
    private Health _health;
    private Power _power;

    private Enemy _enemy;

    public ButtleFieldController(ProfilePlayer playerProfile,
        Transform uiPosition, ButtleFieldView buttleFieldView)
    {
        _playerProfile = playerProfile;
        _buttleFieldView = Object.Instantiate(buttleFieldView, uiPosition);
        AddGameObject(_buttleFieldView.gameObject);

    }

    public void RefreshView()
    {
        _enemy = new Enemy("Enemy Flappy");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _health = new Health(nameof(Health));
        _health.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);

        SubscrybeButtons();
    }

    private void SubscrybeButtons()
    { 
        _buttleFieldView.AddCoinsButton.onClick.AddListener(() => 
            ChangeMoney(true));
        _buttleFieldView.MinusCoinsButton.onClick.AddListener(() => 
            ChangeMoney(false));

        _buttleFieldView.AddHealthButton.onClick.AddListener(() => 
            ChangeHealth(true));
        _buttleFieldView.MinusHealthButton.onClick.AddListener(() => 
            ChangeHealth(false));

        _buttleFieldView.AddPowerButton.onClick.AddListener(() => 
            ChangePower(true));
        _buttleFieldView.MinusPowerButton.onClick.AddListener(() => 
            ChangePower(false));

        _buttleFieldView.FightButton.onClick.AddListener(Fight);

        _buttleFieldView.AddCrymeButton.onClick.AddListener(() => 
            ChangeCryme(true));

        _buttleFieldView.MinusCrymeButton.onClick.AddListener(() => 
            ChangeCryme(false));

        _buttleFieldView.PeaceButton.onClick.AddListener(Peace);
        _buttleFieldView.PeaceButton.gameObject.SetActive(true);

        _buttleFieldView.LeaveButtleField.onClick.AddListener(LeaveButtleField);
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
            ++_allCountMoneyPlayer;
        else
            --_allCountMoneyPlayer;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeDataWindow(
        int countChangeData, DataType type)
    {
        switch (type)
        {
            case DataType.Money:
                _buttleFieldView.MoneyCountText.text = $"Player Money {countChangeData.ToString()}";
                _money.Money = countChangeData;
                break;

            case DataType.Health:
                _buttleFieldView.HealthCountText.text = $"Player Health {countChangeData.ToString()}";
                _health.Health = countChangeData;
                break;

            case DataType.Power:
                _buttleFieldView.PowerCountText.text = $"Player Power {countChangeData.ToString()}";
                _power.Power = countChangeData;
                break;
        }

        _buttleFieldView.EnemyPowerCountText.text = $"Enemy Power {_enemy.Power}";
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
        _buttleFieldView.EnemyCrymeText.text = $"Enemy cryme: {_enemy.Cryme}";
    }

    void SuggestFightDecision()
    {
        if (_enemy.Cryme <= 2)
            _buttleFieldView.PeaceButton.gameObject.SetActive(true);
        else
            _buttleFieldView.PeaceButton.gameObject.SetActive(false);
    }

    private void Peace()
    {
        Debug.Log("<color=#07FF00>Peace!!!</color>");
    }

    private void LeaveButtleField()
    {
        _playerProfile.IsEnemyCarPresent = false;
        _playerProfile.CurrentState.Value = Assets.Code.GameState.Game;
    }

    protected override void OnDispose()
    {
        _buttleFieldView.AddCoinsButton.onClick.RemoveAllListeners();
        _buttleFieldView.MinusCoinsButton.onClick.RemoveAllListeners();

        _buttleFieldView.AddHealthButton.onClick.RemoveAllListeners();
        _buttleFieldView.MinusHealthButton.onClick.RemoveAllListeners();

        _buttleFieldView.AddPowerButton.onClick.RemoveAllListeners();
        _buttleFieldView.MinusPowerButton.onClick.RemoveAllListeners();

        _buttleFieldView.FightButton.onClick.RemoveAllListeners();
        _buttleFieldView.LeaveButtleField.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _health.Detach(_enemy);
        _power.Detach(_enemy);
    }
}
