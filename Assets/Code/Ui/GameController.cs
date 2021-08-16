
using Assets.Code.Data;
using Assets.Code.Ui;
using Assets.Profile;
using Assets.Tools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer, 
        AssetReference carAssetReference,
        AssetReference enemyAssetReference)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();
        
        var tapeBackgroundController = 
            new TapeBackgroundController(leftMoveDiff, rightMoveDiff);


        AddController(tapeBackgroundController);

        var inputGameController = new InputGameController(
           leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        
        AddController(inputGameController);
            
        var carController = new CarController(carAssetReference);
        AddController(carController);

        var upgrades = (UpgradeItemConfigDataSource)Resources.Load(
            "InfoItems/UpgradeItems");
        List<UpgradeItemConfig> upgradeItemConfigs = upgrades.ItemConfigs.ToList();

        var shedController = new ShedController(leftMoveDiff, rightMoveDiff,
            upgradeItemConfigs, profilePlayer.CurrentCar);
        AddController(shedController);

        if (profilePlayer.IsEnemyCarPresent)
        {
            var enemyCar = 
                new EnemyCarController(profilePlayer, leftMoveDiff, rightMoveDiff,
                enemyAssetReference);
            AddController(enemyCar);
        }
    }

    protected override void OnDispose()
    {
    }
}

