using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    
    public void upgradeBuilding(Building building, TextMeshProUGUI _buildingProductionDuration)
    {
        building.Level += 1;
        switch (building)
        {
            case Mine mine:
                mine.UpdateProductionPerSecond();
                mine.UpdateEnergyCost();
                Debug.Log($"Mine infos: lvl:{mine.Level}, production: {mine.ProductionPerSecond}");
                break;
            case Storage storage:
                storage.UpdateStorageCapacity();
                break;
        }
        stats.UpdateBuildingStats();
        _buildingProductionDuration.text = $"Production duration: {building.NextProductionDuration.ToString()}s";
        _displayBuildingLevel.UpdateBuildingLevel(building);
    }
}
