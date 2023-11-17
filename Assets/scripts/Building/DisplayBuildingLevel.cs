using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayBuildingLevel : MonoBehaviour
{
    private MyPlayerBuildings _myPlayerBuildings;
    
    [SerializeField] private TextMeshProUGUI metalMineLevel;
    [SerializeField] private TextMeshProUGUI cristalMineLevel;
    [SerializeField] private TextMeshProUGUI deuteriumMineLevel;
    [SerializeField] private TextMeshProUGUI solarPlantLevel;
    [SerializeField] private TextMeshProUGUI metalStorageLevel;
    [SerializeField] private TextMeshProUGUI cristalStorageLevel;
    [SerializeField] private TextMeshProUGUI deuteriumStorageLevel;
    private Dictionary<string, TextMeshProUGUI> _buildingLevelDisplaysDict;
    void Awake()
    {
        _myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        _buildingLevelDisplaysDict = new Dictionary<string, TextMeshProUGUI>()
        {
            { BuildingNames.MetalMine, metalMineLevel },
            { BuildingNames.CristalMine, cristalMineLevel },
            { BuildingNames.DeuteriumMine, deuteriumMineLevel },
            { BuildingNames.SolarPlant, solarPlantLevel },
            { BuildingNames.MetalStorage, metalStorageLevel },
            { BuildingNames.CristalStorage, cristalStorageLevel },
            { BuildingNames.DeuteriumStorage, deuteriumStorageLevel },
        };
    }

    public void UpdateBuildingLevel(Building building)
    {
        if (_buildingLevelDisplaysDict.TryGetValue(building.BuildingName, out TextMeshProUGUI levelText))
        {
            levelText.text = $"{building.Level}";
        }
    }
}
