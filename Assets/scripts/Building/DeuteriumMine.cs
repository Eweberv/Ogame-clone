using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeuteriumMine : Mine
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
            new MineData { level = 1, productionDuration = 10, energyCost = 22, productionPerSecond = 116},
            new MineData { level = 2, productionDuration = 20, energyCost = 48, productionPerSecond = 256},
            new MineData { level = 3, productionDuration = 30, energyCost = 79, productionPerSecond = 422},
            new MineData { level = 4, productionDuration = 40, energyCost = 117, productionPerSecond = 620},
            new MineData { level = 5, productionDuration = 50, energyCost = 161, productionPerSecond = 852},
            new MineData { level = 6, productionDuration = 60, energyCost = 212, productionPerSecond = 1125},
            new MineData { level = 7, productionDuration = 70, energyCost = 272, productionPerSecond = 1444},
            new MineData { level = 8, productionDuration = 80, energyCost = 342, productionPerSecond = 1816},
            new MineData { level = 9, productionDuration = 90, energyCost = 424, productionPerSecond = 2247},
            new MineData { level = 10, productionDuration = 100, energyCost = 518, productionPerSecond = 2747},
            new MineData { level = 11, productionDuration = 110, energyCost = 627, productionPerSecond = 3324},
            new MineData { level = 12, productionDuration = 120, energyCost = 753, productionPerSecond = 3989},
            new MineData { level = 13, productionDuration = 130, energyCost = 897, productionPerSecond = 4753},
            new MineData { level = 14, productionDuration = 140, energyCost = 1063, productionPerSecond = 5631},
            new MineData { level = 15, productionDuration = 150, energyCost = 1253, productionPerSecond = 6636},
        };
        _buildingSprite = GameObject.Find("deuteriumMineUpgradeBtn").GetComponent<Image>().sprite;
        _description = "Deuterium is used as fuel for spaceships and is harvested in the deep sea. Deuterium is a rare substance and is thus relatively expensive.";
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
