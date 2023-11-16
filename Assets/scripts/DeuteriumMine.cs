using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeuteriumMine : Mine
{
    public override void Init(string name, int level, int productionPerSecond, int energyCost)
    {
        base.Init(name, level, productionPerSecond, energyCost);
    }

    void Awake()
    {
        _productionDurations = new List<ProductionData>
        {
            new ProductionData { level = 1, duration = 10 },
            new ProductionData { level = 2, duration = 20 },
            new ProductionData { level = 3, duration = 30 },
            new ProductionData { level = 4, duration = 40 },
            new ProductionData { level = 5, duration = 50 },
            new ProductionData { level = 6, duration = 60 },
            new ProductionData { level = 7, duration = 70 },
            new ProductionData { level = 8, duration = 80 },
            new ProductionData { level = 9, duration = 90 },
            new ProductionData { level = 10, duration = 100 },
        };
        BuildingSprite = GameObject.Find("deuteriumMineUpgradeBtn").GetComponent<Image>().sprite;
        _description = "Deuterium is used as fuel for spaceships and is harvested in the deep sea. Deuterium is a rare substance and is thus relatively expensive.";
    }
}
