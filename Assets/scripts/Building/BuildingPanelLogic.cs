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
    //
    
    private MyPlayerBuildings _myPlayerBuildings;
    private string _lastSelectedBuilding;
    private UpgradeHandler _upgradeHandler;
    private Building _selectedBuilding;
    
    //for building infos//
    [SerializeField] private TextMeshProUGUI _buildingName;
    [SerializeField] private Image _buildingImage;
    [SerializeField] private TextMeshProUGUI _buildingProductionDuration;
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
        _selectedBuilding = null;
        _upgradeBuildingButton.onClick.AddListener(delegate { _upgradeHandler.upgradeBuilding(_selectedBuilding, _buildingProductionDuration);});
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
        OpenOrClosePanel(building);
        
        UpdatePanelWithBuildingInfo(building);
    }

    private void OpenOrClosePanel(Building building)
    {
        //if same building clicked, close current tab and display ressources preview panel again
        if (_lastSelectedBuilding == building.BuildingName)
        {
            ressourcesUpgradePanel.SetActive(false);
            ressourcesPreviewPanel.SetActive(true);
            _lastSelectedBuilding = null;
            return;
        }
        
        //set current panel to clicked building
        _lastSelectedBuilding = building.BuildingName;
        if (ressourcesPreviewPanel.activeSelf)
        {
            ressourcesPreviewPanel.SetActive(false);
        }
        ressourcesUpgradePanel.SetActive(true);
    }
    
    private void UpdatePanelWithBuildingInfo(Building building)
    {
        _selectedBuilding = building;
        _buildingName.text = building.BuildingName;
        _buildingImage.sprite = building.BuildingSprite;
        _buildingProductionDuration.text = $"Production duration: {building.NextProductionDuration.ToString()}s";
        _buildingDescription.text = building.Description;
    }
}