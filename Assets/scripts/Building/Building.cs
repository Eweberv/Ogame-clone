using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Building : MonoBehaviour
{ 
    protected int _level;
    protected string _buildingName;
    protected string _description;
    protected Sprite _buildingSprite;
    protected RessourcesData _upgradeCost = new RessourcesData();
    
    public abstract int Level { get; set; }
    public abstract string BuildingName { get; }
    public abstract string Description { get; }
    public abstract Sprite BuildingSprite { get; set; }
    public abstract int NextProductionDuration { get; }
    public abstract RessourcesData UpgradeCost { get; }
    public abstract void UpdateUpgradeCost();
    public virtual void Init(string name, int level)
    {
        _buildingName = name;
        _level = level;
    }
    
    //check if building is properly init
    protected void ValidateBuilding()
    {
        if (string.IsNullOrEmpty(_buildingName))
        {
            Debug.LogError("Building not properly initialized: BuildingName is null or empty");
        }

        if (_level <= -1)
        {
            Debug.LogError($"Building not properly initialized: Level is {_level}");
        }

        if (_buildingSprite == null)
        {
            Debug.LogError("Building not properly initialized: BuildingSprite is null");
        }

        if (_description == null)
        {
            Debug.LogError("Building not properly initialized: Description is null");
        }
    }
}
