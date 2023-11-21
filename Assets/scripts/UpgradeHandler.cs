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
    private BuildingPanelLogic _buildingPanelLogic;
    private BuildingQueue _buildingQueue;
    
    void Start()
    {
        _myPlayerRessources = FindObjectOfType<MyPlayerRessources>();
        myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        stats = FindObjectOfType<Stats>();
        _displayBuildingLevel = FindObjectOfType<DisplayBuildingLevel>();
        _buildingPanelLogic = FindObjectOfType<BuildingPanelLogic>();
        _buildingQueue = FindObjectOfType<BuildingQueue>();
    }
    
    public void upgradeBuilding(Building building, TextMeshProUGUI _buildingProductionDuration, TextMeshProUGUI _additionalInfos, TextMeshProUGUI _upgradeCost)
    {
        if (_buildingQueue.BuildingQueueDataList.Count == 0)
        {
            if (HasEnoughResources(building))
            {
                DeductResources(building);
                _buildingQueue.addBuildingToQueue(building);
            }
            else
            {
                Debug.Log($"Not enough ressources to upgrade building {building.BuildingName}");
            }
        } else {
            _buildingQueue.addBuildingToQueue(building);
        }
    }

    public bool HasEnoughResources(Building building)
    {
        return _myPlayerRessources.Metal >= building.UpgradeCost.metal &&
               _myPlayerRessources.Cristal >= building.UpgradeCost.cristal &&
               _myPlayerRessources.Deuterium >= building.UpgradeCost.deuterium;
    }
    
    public void DeductResources(Building building)
    {
        _myPlayerRessources.Metal -= building.UpgradeCost.metal;
        _myPlayerRessources.Cristal -= building.UpgradeCost.cristal;
        _myPlayerRessources.Deuterium -= building.UpgradeCost.deuterium;
    }
    // private IEnumerator BuildingCreate(Building building, TextMeshProUGUI _buildingProductionDuration, TextMeshProUGUI _additionalInfos, TextMeshProUGUI _upgradeCost)
    // {
    //     _buildingQueue.removeBuildingFromQueue();
    //     Debug.Log("upgrade finished for building: " + building.BuildingName);
    //
    //     // Code à exécuter après le temps d'attente
    //     building.Level += 1;
    //     switch (building)
    //     {
    //         case Mine mine:
    //             mine.UpdateProductionPerSecond();
    //             mine.UpdateEnergyCost();
    //             mine.UpdateUpgradeCost();
    //             _additionalInfos.text = $"Energy needed: {mine.GetNextEnergyCost()}";
    //             Debug.Log($"Mine infos: lvl:{mine.Level}, production: {mine.ProductionPerSecond}");
    //             break;
    //         case Storage storage:
    //             storage.UpdateStorageCapacity();
    //             storage.UpdateUpgradeCost();
    //             break;
    //     }
    //
    //     _buildingPanelLogic.DisplayUpgradeCost(building);
    //     stats.UpdateBuildingStats();
    //     _buildingProductionDuration.text = $"Production duration: {building.NextProductionDuration.ToString()}s";
    //     _displayBuildingLevel.UpdateBuildingLevel(building);
    // }
}
