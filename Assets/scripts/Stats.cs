using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    private GameObject _statPanel;
    private MyPlayerBuildings _myPlayerBuildings;
    private TextMeshProUGUI _metalMineStatsText;
    private TextMeshProUGUI _cristalMineStatsText;
    
    public void UpdateMineStats()
    {
        _metalMineStatsText.text = $"Metal mine ({_myPlayerBuildings.MyMetalMine.Level}) {_myPlayerBuildings.MyMetalMine.ProductionPerSecond}/s";
        _cristalMineStatsText.text = $"Cristal mine ({_myPlayerBuildings.MyCristalMine.Level}) {_myPlayerBuildings.MyCristalMine.ProductionPerSecond}/s";
    }

    void Awake()
    {
        _statPanel = GameManager._canvas.transform.Find("StatsPanel").gameObject;
        _myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        
        _metalMineStatsText = _statPanel.transform.Find("MetalMineStats")?.GetComponent<TextMeshProUGUI>();
        _cristalMineStatsText = _statPanel.transform.Find("CristalMineStats")?.GetComponent<TextMeshProUGUI>();
    }
    
    void Start()
    {
        UpdateMineStats();
    }
}
