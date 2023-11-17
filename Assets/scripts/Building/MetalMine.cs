using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MetalMine : Mine
{ 
    public override void Init(string name, int level)
    {
        base.Init(name, level);
    }

    void Awake() 
    { 
        _buildingSprite = GameObject.Find("metalMineUpgradeBtn").GetComponent<Image>().sprite;
        _mineDatas = new List<MineData>
        {
            new MineData { level = 0, productionDuration = 0, energyCost = 0, productionPerSecond = 0},
            new MineData { level = 1, productionDuration = 10, energyCost = 11, productionPerSecond = 308},
            new MineData { level = 2, productionDuration = 20, energyCost = 24, productionPerSecond = 679},
            new MineData { level = 3, productionDuration = 30, energyCost = 39, productionPerSecond = 1121},
            new MineData { level = 4, productionDuration = 40, energyCost = 58, productionPerSecond = 1644},
            new MineData { level = 5, productionDuration = 50, energyCost = 80, productionPerSecond = 2261},
            new MineData { level = 5, productionDuration = 50, energyCost = 80, productionPerSecond = 2261},
            new MineData { level = 6, productionDuration = 60, energyCost = 106, productionPerSecond = 2984},
            new MineData { level = 7, productionDuration = 70, energyCost = 136, productionPerSecond = 3830},
            new MineData { level = 8, productionDuration = 80, energyCost = 171, productionPerSecond = 4815},
            new MineData { level = 9, productionDuration = 90, energyCost = 212, productionPerSecond = 5959},
            new MineData { level = 10, productionDuration = 100, energyCost = 259, productionPerSecond = 7283},
            new MineData { level = 11, productionDuration = 110, energyCost = 313, productionPerSecond = 8812},
            new MineData { level = 12, productionDuration = 120, energyCost = 376, productionPerSecond = 10575},
            new MineData { level = 13, productionDuration = 130, energyCost = 448, productionPerSecond = 12602},
            new MineData { level = 14, productionDuration = 140, energyCost = 531, productionPerSecond = 14928},
            new MineData { level = 15, productionDuration = 150, energyCost = 626, productionPerSecond = 17594},
        };
        _description = "Used in the extraction of metal ore, metal mines are of primary importance to all emerging and established empires.";
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
