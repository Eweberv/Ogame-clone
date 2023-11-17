using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{
    private MyPlayerBuildings myPlayerBuildings;
    private Stats stats;
    private DisplayBuildingLevel _displayBuildingLevel;
    
    void Start()
    {
        myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        stats = FindObjectOfType<Stats>();
        _displayBuildingLevel = FindObjectOfType<DisplayBuildingLevel>();
    }
    
    public void upgradeBuilding(Building building)
    {
        building.Level += 1;
        if (building is Mine mine)
        {
            // if (mine.BuildingName == "Metal Mine")
            // {
            //     mine.ProductionPerSecond += 1000;
            // }
            // else
            // {
            //     mine.ProductionPerSecond += 500;
            // }
            Debug.Log($"Mine infos: lvl:{mine.Level}, production: {mine.ProductionPerSecond}");
        }
        stats.UpdateBuildingStats();
        _displayBuildingLevel.UpdateBuildingLevel(building);
    }
}
