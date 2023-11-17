using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CristalMine : Mine
{
    public override void Init(string name, int level)
    {
        base.Init(name, level);
    }
    
    void Awake()
    {
        _mineDatas = new List<MineData>
        {
            new MineData { level = 0, productionDuration = 0, energyCost = 0, productionPerSecond = 0},
            new MineData { level = 1, productionDuration = 10, energyCost = 11, productionPerSecond = 176},
            new MineData { level = 2, productionDuration = 20, energyCost = 24, productionPerSecond = 387},
            new MineData { level = 3, productionDuration = 30, energyCost = 39, productionPerSecond = 638},
            new MineData { level = 4, productionDuration = 40, energyCost = 58, productionPerSecond = 937},
            new MineData { level = 5, productionDuration = 50, energyCost = 80, productionPerSecond = 1288},
            new MineData { level = 6, productionDuration = 60, energyCost = 106, productionPerSecond = 1700},
            new MineData { level = 7, productionDuration = 70, energyCost = 136, productionPerSecond = 2182},
            new MineData { level = 8, productionDuration = 80, energyCost = 171, productionPerSecond = 2743},
            new MineData { level = 9, productionDuration = 90, energyCost = 212, productionPerSecond = 3395},
            new MineData { level = 10, productionDuration = 100, energyCost = 259, productionPerSecond = 4149},
            new MineData { level = 11, productionDuration = 110, energyCost = 313, productionPerSecond = 5021},
            new MineData { level = 12, productionDuration = 120, energyCost = 376, productionPerSecond = 6025},
            new MineData { level = 13, productionDuration = 130, energyCost = 448, productionPerSecond = 7180},
            new MineData { level = 14, productionDuration = 140, energyCost = 531, productionPerSecond = 8506},
            new MineData { level = 15, productionDuration = 150, energyCost = 626, productionPerSecond = 10025},
        };
        _buildingSprite = GameObject.Find("cristalMineUpgradeBtn").GetComponent<Image>().sprite;
        _description = "Crystals are the main resource used to build electronic circuits and form certain alloy compounds.";
    }
    
    public override int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public override string BuildingName
    {
        get { return _buildingName; }
    }
    public override string Description
    {
        get { return _description; }
    }
    public override Sprite BuildingSprite
    {
        get { return _buildingSprite; }
        set { _buildingSprite = value; }
    }
    public override List<MineData> MineDatas
    {
        get { return _mineDatas; }
    }
}
