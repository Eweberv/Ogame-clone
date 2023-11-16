using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class MyPlayerBuildings : MonoBehaviour
{
    private MetalMine _metalMine;
    private CristalMine _cristalMine;
    private DeuteriumMine _deuteriumMine;
    
    private Stats _stats;
    private Dictionary<string, Building> _buildingsDict = new Dictionary<string, Building>();
    
    void Awake()
    {
        GameObject Building = new GameObject("Building");
        _metalMine = Building.AddComponent<MetalMine>();
        _metalMine.Init("Metal Mine", 0, 0, 0);
        _buildingsDict.Add(_metalMine.BuildingName, _metalMine);
        
        _cristalMine = Building.AddComponent<CristalMine>();
        _cristalMine.Init("Cristal Mine", 0, 0, 0);
        _buildingsDict.Add(_cristalMine.BuildingName, _cristalMine);

        _deuteriumMine = Building.AddComponent<DeuteriumMine>();
        _deuteriumMine.Init("Deuterium Mine", 0, 0, 0);
        _buildingsDict.Add(_deuteriumMine.BuildingName, _deuteriumMine);
        
        
    }
    
    void Start()
    {
        
    }
    
    public MetalMine MyMetalMine
    {
        get { return _metalMine; }
    }
    public CristalMine MyCristalMine
    {
        get { return _cristalMine; }
    }
    
    public DeuteriumMine MyDeuteriumMine
    {
        get { return _deuteriumMine; }
    }

    public Building GetBuilding(string buildingName)
    {
        if (_buildingsDict.TryGetValue(buildingName, out Building building))
        {
            return building;
        }
        return null;
    }
}
