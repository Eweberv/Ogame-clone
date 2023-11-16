using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MetalMine : Mine
{
    public override void Init(string name, int level, int productionPerSecond, int energyCost)
    {
        base.Init(name, level, productionPerSecond, energyCost);
    }

    void Awake()
    {
        _productionDurations = new List<ProductionDuration>
        {
            new ProductionDuration { level = 1, duration = 10 },
            new ProductionDuration { level = 2, duration = 20 },
            new ProductionDuration { level = 3, duration = 30 },
            new ProductionDuration { level = 4, duration = 40 },
            new ProductionDuration { level = 5, duration = 50 },
            new ProductionDuration { level = 6, duration = 60 },
            new ProductionDuration { level = 7, duration = 70 },
            new ProductionDuration { level = 8, duration = 80 },
            new ProductionDuration { level = 9, duration = 90 },
            new ProductionDuration { level = 10, duration = 100 },
        };
        BuildingSprite = GameObject.Find("metalMineUpgradeBtn").GetComponent<Image>().sprite;
        _description = "Used in the extraction of metal ore, metal mines are of primary importance to all emerging and established empires.";
    }
}
