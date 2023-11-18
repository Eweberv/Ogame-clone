using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MetalStorage : Storage
{
    public override void Init(string name, int level)
    {
        base.Init(name, level);
    }
    void Awake()
    {
        _storageDatas = new List<StorageData>
        {
            new StorageData { level = 1, productionDuration = 10, capacity = 20000 },
            new StorageData { level = 2, productionDuration = 20, capacity = 40000 },
            new StorageData { level = 3, productionDuration = 30, capacity = 75000 },
            new StorageData { level = 4, productionDuration = 40, capacity = 140000 },
            new StorageData { level = 5, productionDuration = 50, capacity = 255000 },
            new StorageData { level = 6, productionDuration = 60, capacity = 470000 },
            new StorageData { level = 7, productionDuration = 70, capacity = 865000 },
            new StorageData { level = 8, productionDuration = 80, capacity = 1590000 },
            new StorageData { level = 9, productionDuration = 90, capacity = 2920000 },
            new StorageData { level = 10, productionDuration = 100, capacity = 5355000 },
            new StorageData { level = 11, productionDuration = 110, capacity = 9820000 },
            new StorageData { level = 12, productionDuration = 120, capacity = 18005000 },
            new StorageData { level = 13, productionDuration = 130, capacity = 33005000 },
            new StorageData { level = 14, productionDuration = 140, capacity = 60510000 },
            new StorageData { level = 15, productionDuration = 150, capacity = 110925000 },
        };
        _buildingSprite = GameObject.Find("metalStorageUpgradeBtn").GetComponent<Image>().sprite;
        _description = "Provides storage for excess metal.";
    }
    public override List<StorageData> StorageDatas
    {
        get { return _storageDatas; }
    }

    public override RessourcesData UpgradeCost => _upgradeCost;
    public override void UpdateUpgradeCost()
    {
        _upgradeCost.metal = Convert.ToInt32(1000 * Math.Pow(2, _level - 1));
        _upgradeCost.cristal = 0;
        _upgradeCost.deuterium = 0;
    }
}
