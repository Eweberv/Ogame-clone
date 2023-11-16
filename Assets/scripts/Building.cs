using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Building : MonoBehaviour
{
    private int level;
    private string _buildingName;
    protected Sprite _buildingSprite;
    protected string _description;
    protected List<ProductionData> _productionDurations;

    public virtual void Init(string name, int level)
    {
        this._buildingName = name;
        this.level = level;
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    
    public Sprite BuildingSprite
    {
        get { return _buildingSprite; }
        set { _buildingSprite = value; }
    }
    //get next upgrade duration
    public int ProductionDuration
    {
        get
        {
            var nextLevelData = _productionDurations.FirstOrDefault(pd => pd.level == Level + 1);
            return nextLevelData != null ? nextLevelData.duration : 0;
        }
    }
    
    public string Description
    {
        get { return _description; }
    }
    public string BuildingName
    {
        get { return _buildingName; }
        set { _buildingName = value; }
    }
}
