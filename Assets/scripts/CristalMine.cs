using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CristalMine : Mine
{
    public override void Init(string name, int level, int productionPerSecond, int energyCost)
    {
        base.Init(name, level, productionPerSecond, energyCost);
    }
    
    void Awake()
    {
        _productionDurations = new List<ProductionDuration>
        {
            new ProductionDuration { level = 1, duration = 5 },
            new ProductionDuration { level = 2, duration = 30 },
            new ProductionDuration { level = 3, duration = 50 },
            new ProductionDuration { level = 4, duration = 70 },
            new ProductionDuration { level = 5, duration = 90 },
            new ProductionDuration { level = 6, duration = 110 },
            new ProductionDuration { level = 7, duration = 130 },
            new ProductionDuration { level = 8, duration = 150 },
            new ProductionDuration { level = 9, duration = 170 },
            new ProductionDuration { level = 10, duration = 190 },
        };
        BuildingSprite = GameObject.Find("cristalMineUpgradeBtn").GetComponent<Image>().sprite;
        _description = "Crystals are the main resource used to build electronic circuits and form certain alloy compounds.";
    }
}
