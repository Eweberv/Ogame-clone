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
    private MyPlayerRessources _myPlayerRessources;
    
    void Start()
    {
        _myPlayerRessources = FindObjectOfType<MyPlayerRessources>();
        myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        stats = FindObjectOfType<Stats>();
        _displayBuildingLevel = FindObjectOfType<DisplayBuildingLevel>();
    }
    
    public void upgradeBuilding(Building building, TextMeshProUGUI _buildingProductionDuration, TextMeshProUGUI _additionalInfos, TextMeshProUGUI _upgradeCost)
    {
        if (_myPlayerRessources.Metal >= building.UpgradeCost.metal &&
            _myPlayerRessources.Cristal >= building.UpgradeCost.cristal &&
            _myPlayerRessources.Deuterium >= building.UpgradeCost.deuterium
           )
        {
            _myPlayerRessources.Metal -= building.UpgradeCost.metal;
            _myPlayerRessources.Cristal -= building.UpgradeCost.cristal;
            _myPlayerRessources.Deuterium -= building.UpgradeCost.deuterium;
            building.Level += 1;
            switch (building)
            {
                case Mine mine:
                    mine.UpdateProductionPerSecond();
                    mine.UpdateEnergyCost();
                    mine.UpdateUpgradeCost();
                    _additionalInfos.text = $"Energy needed: {mine.GetNextEnergyCost()}";
                    Debug.Log($"Mine infos: lvl:{mine.Level}, production: {mine.ProductionPerSecond}");
                    break;
                case Storage storage:
                    storage.UpdateStorageCapacity();
                    storage.UpdateUpgradeCost();
                    break;
            }
            _upgradeCost.text = $"Upgrade cost: {building.UpgradeCost.metal} metal, {building.UpgradeCost.cristal} cristal, {building.UpgradeCost.deuterium} deuterium";;
            stats.UpdateBuildingStats();
            _buildingProductionDuration.text = $"Production duration: {building.NextProductionDuration.ToString()}s";
            _displayBuildingLevel.UpdateBuildingLevel(building);
        }
        else
        {
            Debug.Log($"Not enough ressources to upgrade building {building.BuildingName}");
        }
    }
}
