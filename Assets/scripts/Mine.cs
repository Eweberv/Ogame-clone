using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mine : MonoBehaviour
{ 
    private int level;
    private int productionPerSecond;
    private int energyCost;
    private string mineName;
    protected List<ProductionData> _productionDurations;
    protected string _description;

    public virtual void Init(string name, int level, int productionPerSecond, int energyCost)
    {
        this.mineName = name;
        this.level = level;
        this.productionPerSecond = productionPerSecond;
        this.energyCost = energyCost;
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int ProductionPerSecond
    {
        get { return productionPerSecond; }
        set { productionPerSecond = value; }
    }
    public int EnergyCost
    {
        get { return energyCost; }
        set { energyCost = value; }
    }
    public string MineName
    {
        get { return mineName; }
        set { mineName = value; }
    }

    public string Description
    {
        get { return _description; }
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
}
