using System.Collections.Generic;

public abstract class PlayerData
{
    private string _titleData;
    private int _moneyCount;
    private int _healthCount;
    private int _powerCount;

    private List<IEnemy> _enemies = new List<IEnemy>();
    protected PlayerData(string titleData)
    {
        _titleData = titleData;
    }

    public void Attach(IEnemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void Detach(IEnemy enemy)
    {
        _enemies.Remove(enemy);
    }

    protected void Notify(DataType dataType)
    {
        foreach (var investor in _enemies)
            investor.Update(this, dataType);
    }

    public string TitleData => _titleData;

    public int Money
    {
        get => _moneyCount;
        set 
        {
            if (value != _moneyCount)
            {
                _moneyCount = value;
                Notify(DataType.Money);
            }
        }
    }

    public int Health
    {
        get => _healthCount;
        set 
        {
            if (value != _healthCount)
            {
                _healthCount = value;
                Notify(DataType.Health);
            }
        }
    }

    public int Power
    {
        get => _powerCount;
        set 
        {
            _powerCount = value;
            Notify(DataType.Power);
        }
    }

}
