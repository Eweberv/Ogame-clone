using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CristalMine : Mine
{
    public override void Init(string name, int level, int productionPerSecond, int energyCost)
    {
        base.Init(name, level, productionPerSecond, energyCost);
    }
    
    void Awake()
    {
        _productionDurations = new List<ProductionData>
        {
            new ProductionData { level = 1, duration = 5 },
            new ProductionData { level = 2, duration = 30 },
            new ProductionData { level = 3, duration = 50 },
            new ProductionData { level = 4, duration = 70 },
            new ProductionData { level = 5, duration = 90 },
            new ProductionData { level = 6, duration = 110 },
            new ProductionData { level = 7, duration = 130 },
            new ProductionData { level = 8, duration = 150 },
            new ProductionData { level = 9, duration = 170 },
            new ProductionData { level = 10, duration = 190 },
        };
        _description = "Crystals are the main resource used to build electronic circuits and form certain alloy compounds.";
    }
}
