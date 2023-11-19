using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingPanelLogic : MonoBehaviour
{
    //Init in Unity UI for now
    public GameObject ressourcesPreviewPanel;
    public GameObject ressourcesUpgradePanel;
    private GameObject _ressourcesUpgradePanelDetailedInfosAdditional;
    private GameObject _ressourcesUpgradePanelDetailedInfosUpgradeCost;
    //
    
    private MyPlayerBuildings _myPlayerBuildings;
    private string _lastSelectedBuilding;
    private UpgradeHandler _upgradeHandler;
    private Building _selectedBuilding;
    
    //for building infos//
    [SerializeField] private TextMeshProUGUI _buildingName;
    [SerializeField] private Image _buildingImage;
    [SerializeField] private TextMeshProUGUI _buildingProductionDuration;
    [SerializeField] private TextMeshProUGUI _additionalInfos;
    [SerializeField] private TextMeshProUGUI _upgradeCost;
    [SerializeField] private TextMeshProUGUI _buildingDescription;
    [SerializeField] private Button _upgradeBuildingButton;
    //
    
    public Button UpgradeBuildingButton
    {
        get { return _upgradeBuildingButton; }
    }
    void Start()
    {
        _myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        _upgradeHandler = FindObjectOfType<UpgradeHandler>();
        _ressourcesUpgradePanelDetailedInfosAdditional = GameObject.Find("RessourcesUpgradePanelDetailedInfosAdditional");
        _ressourcesUpgradePanelDetailedInfosUpgradeCost = GameObject.Find("RessourcesUpgradePanelDetailedInfosUpgradeCost");
        
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

    private void DisplayUpgradeCost(Building building)
    {
        _ressourcesUpgradePanelDetailedInfosUpgradeCost.GetComponent<TextMeshProUGUI>().text = $"Upgrade cost: {building.UpgradeCost.metal} metal, {building.UpgradeCost.cristal} cristal, {building.UpgradeCost.deuterium} deuterium";
    }
    
    // private void AddMineEnergyCost(Building building)
    // {
    //     if (building is Mine mine)
    //     {
    //         var RessourcesUpgradePanelDetailedInfos = GameObject.Find("RessourcesUpgradePanelDetailedInfos");
    //         if (RessourcesUpgradePanelDetailedInfos != null)
    //         {
    //             GameObject RessourcesUpgradePanelDetailedInfosEnergy = new GameObject("RessourcesUpgradePanelDetailedInfosEnergy");
    //             TextMeshProUGUI textMeshPro = RessourcesUpgradePanelDetailedInfosEnergy.AddComponent<TextMeshProUGUI>();
    //             
    //             textMeshPro.text = "Energy Cost: " + mine.EnergyCost.ToString();
    //             textMeshPro.fontSize = 24;
    //             textMeshPro.alignment = TextAlignmentOptions.Center;
    //             textMeshPro.color = Color.white;
    //             
    //             RessourcesUpgradePanelDetailedInfosEnergy.transform.SetParent(RessourcesUpgradePanelDetailedInfos.transform, false);
    //         }
    //     }
    // }
    //
    // private void RemoveMineEnergyCost(Building building)
    // {
    //     if (building is Mine mine)
    //     {
    //         var RessourcesUpgradePanelDetailedInfosEnergy = GameObject.Find("RessourcesUpgradePanelDetailedInfosEnergy");
    //         if (RessourcesUpgradePanelDetailedInfosEnergy)
    //         {
    //             RessourcesUpgradePanelDetailedInfosEnergy.
    //         }
    //     }
    // }
}