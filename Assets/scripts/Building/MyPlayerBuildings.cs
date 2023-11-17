using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class MyPlayerBuildings : MonoBehaviour
{
    private MetalMine _metalMine;
    private CristalMine _cristalMine;
    private DeuteriumMine _deuteriumMine;

    private Storage _metalStorage;
    private Storage _cristalStorage;
    private Storage _deuteriumStorage;
    
    private Stats _stats;
    private Dictionary<string, Building> _buildingsDict = new Dictionary<string, Building>();
    
    void Awake()
    {
        GameObject Building = new GameObject("Building");
        _metalMine = Building.AddComponent<MetalMine>();
        _metalMine.Init(BuildingNames.MetalMine, 0);
        _buildingsDict.Add(_metalMine.BuildingName, _metalMine);
        
        _cristalMine = Building.AddComponent<CristalMine>();
        _cristalMine.Init(BuildingNames.CristalMine, 0);
        _buildingsDict.Add(_cristalMine.BuildingName, _cristalMine);

        _deuteriumMine = Building.AddComponent<DeuteriumMine>();
        _deuteriumMine.Init(BuildingNames.DeuteriumMine, 0);
        _buildingsDict.Add(_deuteriumMine.BuildingName, _deuteriumMine);

        _metalStorage = Building.AddComponent<MetalStorage>();
        _metalStorage.Init(BuildingNames.MetalStorage, 0);
        _buildingsDict.Add(_metalStorage.BuildingName, _metalStorage);
        
        _cristalStorage = Building.AddComponent<CristalStorage>();
        _cristalStorage.Init(BuildingNames.CristalStorage, 0);
        _buildingsDict.Add(_cristalStorage.BuildingName, _cristalStorage);
        
        _deuteriumStorage = Building.AddComponent<DeuteriumStorage>();
        _deuteriumStorage.Init(BuildingNames.DeuteriumStorage, 0);
        _buildingsDict.Add(_deuteriumStorage.BuildingName, _deuteriumStorage);
    }
    
    void Start()
    {
        
    }

    public Dictionary<string, Building> BuildingsDict
    {
        get { return _buildingsDict; }
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

    public Storage MetalStorage
    {
        get { return _metalStorage; }
    }
    
    public Storage CristalStorage
    {
        get { return _cristalStorage; }
    }
    
    public Storage DeuteriumStorage
    {
        get { return _deuteriumStorage; }
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
