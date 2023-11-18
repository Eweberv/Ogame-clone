using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeuteriumMine : Mine
{
    public override void Init(string name, int level)
    {
        base.Init(name, level);
        UpdateUpgradeCost();
        UpdateEnergyCost();
    }

    void Awake()
    {
        _mineDatas = new List<MineData>
        {
            new MineData { level = 0, productionDuration = 0},
            new MineData { level = 1, productionDuration = 10},
            new MineData { level = 2, productionDuration = 20},
            new MineData { level = 3, productionDuration = 30},
            new MineData { level = 4, productionDuration = 40},
            new MineData { level = 5, productionDuration = 50},
            new MineData { level = 6, productionDuration = 60},
            new MineData { level = 7, productionDuration = 70},
            new MineData { level = 8, productionDuration = 80},
            new MineData { level = 9, productionDuration = 90},
            new MineData { level = 10, productionDuration = 100},
            new MineData { level = 11, productionDuration = 110},
            new MineData { level = 12, productionDuration = 120},
            new MineData { level = 13, productionDuration = 130},
            new MineData { level = 14, productionDuration = 140},
            new MineData { level = 15, productionDuration = 150},
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
    
    public override RessourcesData UpgradeCost => _upgradeCost;

    public override void UpdateUpgradeCost()
    {
        _upgradeCost.metal = Convert.ToInt32(225 * Math.Pow(1.5, _level - 1));
        _upgradeCost.cristal = Convert.ToInt32(75 * Math.Pow(1.5, _level - 1));
        _upgradeCost.deuterium = 0;
    }

    public override int EnergyCost => _energyCost;

    public override void UpdateEnergyCost()
    {
        _energyCost = Convert.ToInt32(20 * _level * Math.Pow(1.1, _level));
    }
    
    public override int ProductionPerSecond => _productionPerSecond;

    public override void UpdateProductionPerSecond()
    {
        var planetMaxTemperature = 30;
        _productionPerSecond = Convert.ToInt32(10 * _level * Math.Pow(1.1, _level) * (-0.002 * planetMaxTemperature + 1.28));
    }
}
