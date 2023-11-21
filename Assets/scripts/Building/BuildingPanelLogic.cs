using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingPanelLogic : MonoBehaviour
{
    [SerializeField] private GameObject ressourcesPreviewPanel;
    [SerializeField] private GameObject ressourcesUpgradePanel;
    
    private MyPlayerBuildings _myPlayerBuildings;
    private string _lastSelectedBuilding;
    private UpgradeHandler _upgradeHandler;
    private Building _selectedBuilding;
    private BuildingQueue _buildingQueue;
    
    //for building infos//
    [SerializeField] private TextMeshProUGUI _buildingName;
    [SerializeField] private Image _buildingImage;
    [SerializeField] private TextMeshProUGUI _buildingProductionDuration;
    [SerializeField] private TextMeshProUGUI _additionalInfos;
    [SerializeField] private TextMeshProUGUI _upgradeCost;
    [SerializeField] private TextMeshProUGUI _buildingDescription;
    [SerializeField] private Button _upgradeBuildingButton;
    [SerializeField] private GameObject _ressourcesUpgradePanelDetailedInfosAdditional;
    [SerializeField] private GameObject _ressourcesUpgradePanelDetailedInfosUpgradeCost;
    //
    
    public Button UpgradeBuildingButton
    {
        get { return _upgradeBuildingButton; }
    }
    void Start()
    {
        _myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        _upgradeHandler = FindObjectOfType<UpgradeHandler>();
        _buildingQueue = FindObjectOfType<BuildingQueue>();
        
        _selectedBuilding = null;
        _upgradeBuildingButton.onClick.AddListener(delegate { _upgradeHandler.upgradeBuilding(_selectedBuilding, _buildingProductionDuration, _additionalInfos, _upgradeCost);});
    }
    public void OnBuildingSelected(string buildingName)
    {
        Building selectedBuilding = _myPlayerBuildings.GetBuilding(buildingName);
        if (selectedBuilding)
        {
            DisplayBuildingInfo(selectedBuilding);
        }
    }

    //TODO: remplacer Mine par Building qui peut gérer n'importe quel batiment
    private void DisplayBuildingInfo(Building building)
    {
        var isOpen = OpenOrClosePanel(building);

        if (isOpen)
        {
            UpdatePanelWithBuildingInfo(building);
        }
    }

    private bool OpenOrClosePanel(Building building)
    {
        //if same building clicked, close current tab and display ressources preview panel again
        if (_lastSelectedBuilding == building.BuildingName)
        {
            ressourcesUpgradePanel.SetActive(false);
            ressourcesPreviewPanel.SetActive(true);
            _lastSelectedBuilding = null;
            return false;
        }
        
        //set current panel to clicked building
        _lastSelectedBuilding = building.BuildingName;
        if (ressourcesPreviewPanel.activeSelf)
        {
            ressourcesPreviewPanel.SetActive(false);
        }
        ressourcesUpgradePanel.SetActive(true);
        return true;
    }
    
    private void UpdatePanelWithBuildingInfo(Building building)
    {
        _selectedBuilding = building;
        _buildingName.text = building.BuildingName;
        _buildingImage.sprite = building.BuildingSprite;
        _buildingProductionDuration.text = $"Production duration: {building.NextProductionDuration.ToString()}s";
        DisplayMineEnergyCost(building);
        DisplayUpgradeCost(building);
        _buildingDescription.text = building.Description;
    }

    private void DisplayMineEnergyCost(Building building)
    {
        if (building is Mine mine)
        {
            _ressourcesUpgradePanelDetailedInfosAdditional.GetComponent<TextMeshProUGUI>().text = $"Energy needed: {mine.GetNextEnergyCost()}";
            _ressourcesUpgradePanelDetailedInfosAdditional.SetActive(true);
        }
        else
        {
            _ressourcesUpgradePanelDetailedInfosAdditional.SetActive(false);
        }
    }

    public void DisplayUpgradeCost(Building building)
    {
        var bufferStr = "Upgrade cost: ";
        if (building.UpgradeCost.metal > 0)
        {
            bufferStr += $"{building.UpgradeCost.metal} metal, ";
        }
        if (building.UpgradeCost.cristal > 0)
        {
            bufferStr += $"{building.UpgradeCost.cristal} cristal, ";
        }
        if (building.UpgradeCost.deuterium > 0)
        {
            bufferStr += $"{building.UpgradeCost.deuterium} deuterium";
        }

        if (bufferStr.EndsWith(", "))
        {
            bufferStr = bufferStr.Remove(bufferStr.Length - 2);
        }
        _ressourcesUpgradePanelDetailedInfosUpgradeCost.GetComponent<TextMeshProUGUI>().text = bufferStr;
    }

    public void SetUpgradeButtonText(List<BuildingQueueData> _buildingQueueDataList)
    {
        if (_buildingQueueDataList.Count == 0)
        {
            UpgradeBuildingButton.GetComponentInChildren<TextMeshProUGUI>().text = "UPGRADE";
        } else {
            UpgradeBuildingButton.GetComponentInChildren<TextMeshProUGUI>().text = "QUEUE";
        }
    }
}