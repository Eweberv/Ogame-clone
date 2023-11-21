using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingQueue : MonoBehaviour
{
    [SerializeField] private GameObject _buildingQueueContainer;
    [SerializeField] private TextMeshProUGUI _buildingQueueBuildingName;
    [SerializeField] private TextMeshProUGUI _buildingQueueBuildingLevel;
    [SerializeField] private TextMeshProUGUI _buildingQueueBuildingDuration;
    [SerializeField] private Image _buildingQueueBuildingImage;

    private List<BuildingQueueData> _buildingQueueDataList;

    public List<BuildingQueueData> BuildingQueueDataList
    {
        get { return _buildingQueueDataList; }
    }
    
    [SerializeField] private GameObject _buildingQueueContainerAdditionalContainer;
    [SerializeField] private GameObject _buildingQueueContainerAdditional1;
    [SerializeField] private GameObject _buildingQueueContainerAdditional2;
    [SerializeField] private GameObject _buildingQueueContainerAdditional3;
    [SerializeField] private GameObject _buildingQueueContainerAdditional4;
    
    
    //used after building is finished upgrading, should be in a variable
    [SerializeField] private TextMeshProUGUI _additionalInfos;
    [SerializeField] private TextMeshProUGUI _buildingProductionDuration;
    
    private DisplayBuildingLevel _displayBuildingLevel;
    private BuildingPanelLogic _buildingPanelLogic;
    private Stats _stats;
    private MyPlayerRessources _myPlayerRessources;
    private UpgradeHandler _upgradeHandler;
    private Coroutine _buildingQueueCoroutine;
    //

    private void Awake()
    {
        AddClickListener(_buildingQueueBuildingImage.gameObject, 0);
        AddClickListener(_buildingQueueContainerAdditional1, 1);
        AddClickListener(_buildingQueueContainerAdditional2, 2);
        AddClickListener(_buildingQueueContainerAdditional3, 3);
        AddClickListener(_buildingQueueContainerAdditional4, 4);
        
        //used after building is finished upgrading, should be in a variable
        _displayBuildingLevel = FindObjectOfType<DisplayBuildingLevel>();
        _buildingPanelLogic = FindObjectOfType<BuildingPanelLogic>();
        _stats = FindObjectOfType<Stats>();
        _myPlayerRessources = FindObjectOfType<MyPlayerRessources>();
        _upgradeHandler = FindObjectOfType<UpgradeHandler>();
        //
            
        _buildingQueueDataList = new List<BuildingQueueData>();
        _buildingQueueContainer.SetActive(false);
        _buildingQueueContainerAdditional1.SetActive(false);
        _buildingQueueContainerAdditional2.SetActive(false);
        _buildingQueueContainerAdditional3.SetActive(false);
        _buildingQueueContainerAdditional4.SetActive(false);
    }

    /**
     * Click listener for buildings queue Images
     */
    private void AddClickListener(GameObject imageContainer, int index)
    {
        Button btn = imageContainer.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(() => RemoveBuildingAtIndex(index));
        }
    }
    
    /**
     * Refund construction cost to player (used when user cancels the main building construction for example)
     */
    private void RefundResources(Building building)
    {
        _myPlayerRessources.Metal += building.UpgradeCost.metal;
        _myPlayerRessources.Cristal += building.UpgradeCost.cristal;
        _myPlayerRessources.Deuterium += building.UpgradeCost.deuterium;
    }
    
    /**
     * Add building to queue when user clicks on the upgrade/queue button
     */
    public void addBuildingToQueue(Building building)
    {
        _buildingQueueDataList.Add(new BuildingQueueData
        {
            _building = building,
            _buildingQueueBuildingName = building.BuildingName,
            _buildingQueueBuildingLevel = building.Level,
            _buildingQueueBuildingDuration = building.NextProductionDuration,
            _buildingQueueBuildingSprite = building.BuildingSprite
        });
        _buildingPanelLogic.UpgradeBuildingButton.GetComponentInChildren<TextMeshProUGUI>().text = "QUEUE";
        _buildingQueueContainer.SetActive(true);

        if (_buildingQueueDataList.Count == 1)
        {
            _buildingQueueContainer.SetActive(true);
            _buildingQueueContainerAdditionalContainer.SetActive(false);
            _buildingQueueBuildingName.text = building.BuildingName;
            _buildingQueueBuildingLevel.text = $"Improve to level {building.Level + 1}";
            _buildingQueueBuildingDuration.text = $"Duration: {building.NextProductionDuration.ToString()}s";
            _buildingQueueBuildingImage.sprite = building.BuildingSprite;
            _buildingQueueCoroutine = StartCoroutine(UpdateBuildingDuration(building.NextProductionDuration));
        }
        if (_buildingQueueDataList.Count >= 2)
        {
            _buildingQueueContainerAdditionalContainer.SetActive(true);
            _buildingQueueContainerAdditional1.SetActive(true);
            _buildingQueueContainerAdditional1.GetComponent<Image>().sprite =
                _buildingQueueDataList[1]._buildingQueueBuildingSprite;
            if (_buildingQueueDataList.Count >= 3)
            {
                _buildingQueueContainerAdditional2.SetActive(true);
                _buildingQueueContainerAdditional2.GetComponent<Image>().sprite =
                    _buildingQueueDataList[2]._buildingQueueBuildingSprite;
                if (_buildingQueueDataList.Count >= 4)
                {
                    _buildingQueueContainerAdditional3.SetActive(true);
                    _buildingQueueContainerAdditional3.GetComponent<Image>().sprite =
                        _buildingQueueDataList[3]._buildingQueueBuildingSprite;
                    if (_buildingQueueDataList.Count >= 5)
                    {
                        _buildingQueueContainerAdditional4.SetActive(true);
                        _buildingQueueContainerAdditional4.GetComponent<Image>().sprite =
                            _buildingQueueDataList[4]._buildingQueueBuildingSprite;
                    }
                }
            }
        }
    }

    /**
     * Remove building from queue when current construction is finished
     */
    public void removeBuildingFromQueue(Building building)
    {
        if (_buildingQueueCoroutine != null)
        {
            StopCoroutine(_buildingQueueCoroutine);
        }

        _buildingPanelLogic.SetUpgradeButtonText(_buildingQueueDataList);
        if (_buildingQueueDataList.Count > 0)
        {
            _buildingQueueDataList.RemoveAt(0);
        }

        if (_buildingQueueDataList.Count > 0)
        {
            Building nextBuilding = _buildingQueueDataList[0]._building;
            if (_upgradeHandler.HasEnoughResources(building))
            {
                _upgradeHandler.DeductResources(building);
                _buildingQueueBuildingName.text = nextBuilding.BuildingName;
                _buildingQueueBuildingLevel.text = $"Improve to level {nextBuilding.Level + 1}";
                _buildingQueueBuildingDuration.text = $"Duration: {nextBuilding.NextProductionDuration.ToString()}s";
                _buildingQueueBuildingImage.sprite = nextBuilding.BuildingSprite;
                _buildingQueueCoroutine =
                    StartCoroutine(UpdateBuildingDuration(_buildingQueueDataList[0]._buildingQueueBuildingDuration));
            }
            else
            {
                Debug.Log($"Not enough ressources to upgrade building {building.BuildingName} to level {building.Level + 1}");
                _buildingQueueDataList.Clear();
            }
        }
        else
        {
            _buildingQueueContainer.SetActive(false);
        }
        UpdateAdditionalBuildingQueueDisplays();
    }
    
    /**
     * Remove selected building from queue when user clicks on the image
     */
    private void RemoveBuildingAtIndex(int index)
    {
        bool wasFirstBuilding = (index == 0);
        if (index < _buildingQueueDataList.Count)
        {
            if (index == 0 && _buildingQueueCoroutine != null)
            {
                StopCoroutine(_buildingQueueCoroutine);
                RefundResources(_buildingQueueDataList[0]._building);
            }
            _buildingQueueDataList.RemoveAt(index);
            _buildingPanelLogic.SetUpgradeButtonText(_buildingQueueDataList);

            if (index == 0 && _buildingQueueDataList.Count > 0)
            {
                Building nextBuilding = _buildingQueueDataList[0]._building;
                if (_upgradeHandler.HasEnoughResources(nextBuilding))
                {
                    _upgradeHandler.DeductResources(nextBuilding);
                    _buildingQueueCoroutine = StartCoroutine(UpdateBuildingDuration(nextBuilding.NextProductionDuration));
                }
                else
                {
                    Debug.Log($"Not enough resources to upgrade building {nextBuilding.BuildingName} to level {nextBuilding.Level + 1}");
                    _buildingQueueDataList.Clear();
                    _buildingQueueContainer.SetActive(false);
                }
            }
            UpdateBuildingQueueDisplay(updateMainBuildingInfo: wasFirstBuilding);
            UpdateAdditionalBuildingQueueDisplays();
        }
    }
    
    /**
     * Update UI for the main construction
     */
    private void UpdateBuildingQueueDisplay(bool updateMainBuildingInfo)
    {
        if (_buildingQueueDataList.Count == 0)
        {
            _buildingQueueContainer.SetActive(false);
        }
        else if (updateMainBuildingInfo)
        {
            Building nextBuilding = _buildingQueueDataList[0]._building;
            _buildingQueueBuildingName.text = nextBuilding.BuildingName;
            _buildingQueueBuildingLevel.text = $"Improve to level {nextBuilding.Level + 1}";
            _buildingQueueBuildingDuration.text = $"Duration: {nextBuilding.NextProductionDuration.ToString()}s";
            _buildingQueueBuildingImage.sprite = nextBuilding.BuildingSprite;
        }
    }

    /**
     * Update UI for the additional constructions
     */
    private void UpdateAdditionalBuildingQueueDisplays()
    {
        _buildingQueueContainerAdditional1.SetActive(false);
        _buildingQueueContainerAdditional2.SetActive(false);
        _buildingQueueContainerAdditional3.SetActive(false);
        _buildingQueueContainerAdditional4.SetActive(false);

        for (int i = 1; i < _buildingQueueDataList.Count; i++)
        {
            switch (i)
            {
                case 1:
                    _buildingQueueContainerAdditional1.SetActive(true);
                    _buildingQueueContainerAdditional1.GetComponent<Image>().sprite = _buildingQueueDataList[i]._buildingQueueBuildingSprite;
                    break;
                case 2:
                    _buildingQueueContainerAdditional2.SetActive(true);
                    _buildingQueueContainerAdditional2.GetComponent<Image>().sprite = _buildingQueueDataList[i]._buildingQueueBuildingSprite;
                    break;
                case 3:
                    _buildingQueueContainerAdditional3.SetActive(true);
                    _buildingQueueContainerAdditional3.GetComponent<Image>().sprite = _buildingQueueDataList[i]._buildingQueueBuildingSprite;
                    break;
                case 4:
                    _buildingQueueContainerAdditional4.SetActive(true);
                    _buildingQueueContainerAdditional4.GetComponent<Image>().sprite = _buildingQueueDataList[i]._buildingQueueBuildingSprite;
                    break;
            }
        }
    }

    /**
     * Update construction duration every second on UI and take ressources from player when construction is finished
     */
    private IEnumerator UpdateBuildingDuration(float duration)
    {
        Building building = _buildingQueueDataList[0]._building;

        while (duration > 0)
        {
            _buildingQueueBuildingDuration.text = $"Duration: {duration}s";
            yield return new WaitForSeconds(1);
            duration--;
        }
        UpgradeBuilding(building);
        removeBuildingFromQueue(building);
    }

    /**
     * Upgrade building stats
     */
    private void UpgradeBuilding(Building building)
    {
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
        _buildingPanelLogic.DisplayUpgradeCost(building);
        _stats.UpdateBuildingStats();
        _buildingProductionDuration.text = $"Production duration: {building.NextProductionDuration.ToString()}s";
        _displayBuildingLevel.UpdateBuildingLevel(building);
    }
}