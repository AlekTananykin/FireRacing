using UnityEngine;

public class Enemy : IEnemy
{
    private const int KCoins = 5;
    private const float KPower = 1.5f;
    private const int MaxHealthPlayer = 20;

    private string _name;
    private int _playerMoney;
    private int _playerHealth;
    private int _playerPower;

    public Enemy(string name)
    {
        _name = name;
    }

    public void Update(PlayerData playerData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _playerMoney = playerData.Money;
                break;
            case DataType.Health:
                _playerHealth = playerData.Health;
                break;
            case DataType.Power:
                _playerPower = playerData.Power;
                break;
        }

        Debug.Log($"Notified {_name} change to {playerData}");
    }

    public int Power
    {
        get
        {
            float moneyWeight = 1.0f;
            if (_playerMoney > KCoins)
                moneyWeight = 1.0f / (1.0f + _playerMoney);

            float power = _playerPower * (moneyWeight + _playerHealth / MaxHealthPlayer);
            return (int)power;
        }
    }

    int _cryme;
    public int Cryme 
    { 
        get => _cryme;
        set
        {
            _cryme = value;
            if (_cryme < 0)
                _cryme = 0;
        } 
    }
    
}
