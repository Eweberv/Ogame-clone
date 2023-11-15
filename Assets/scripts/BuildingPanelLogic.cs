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
    private MyPlayerBuildings _myPlayerBuildings;
    private string _lastSelectedBuilding;

    //for building infos//
    [SerializeField] private TextMeshProUGUI _buildingName;
    [SerializeField] private Image _buildingImage;
    [SerializeField] private TextMeshProUGUI _buildingProductionDuration;
    [SerializeField] private TextMeshProUGUI _buildingDescription;
    //
    
    void Start()
    {
        _myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        Debug.Log($"Ici myplayerbuildings {_myPlayerBuildings}");
    }
    public void OnBuildingSelected(string buildingName)
    {
        switch(buildingName)
        {
            case "Metal Mine":
                DisplayBuildingInfo(_myPlayerBuildings.MyMetalMine);
                break;
            case "Cristal Mine":
                DisplayBuildingInfo(_myPlayerBuildings.MyCristalMine);
                break;
            // TODO: Ajoutez des cas supplémentaires pour d'autres bâtiments
        }
    }

    //TODO: remplacer Mine par Building qui peut gérer n'importe quel batiment
    private void DisplayBuildingInfo(Mine mine)
    {
        OpenOrClosePanel(mine);
        
        UpdatePanelWithBuildingInfo(mine);
    }

    private void OpenOrClosePanel(Mine mine)
    {
        //if same building clicked, close current tab and display ressources preview panel again
        if (_lastSelectedBuilding == mine.MineName)
        {
            ressourcesUpgradePanel.SetActive(false);
            ressourcesPreviewPanel.SetActive(true);
            _lastSelectedBuilding = null;
            return;
        }
        
        //set current panel to clicked building
        _lastSelectedBuilding = mine.MineName;
        if (ressourcesPreviewPanel.activeSelf)
        {
            ressourcesPreviewPanel.SetActive(false);
        }
        ressourcesUpgradePanel.SetActive(true);
    }
    
    private void UpdatePanelWithBuildingInfo(Mine mine)
    {
        _buildingName.text = mine.MineName;
        // _buildingImage = ;
        _buildingProductionDuration.text = $"Production duration: {mine.ProductionDuration.ToString()}s";
        _buildingDescription.text = mine.Description;
    }
}