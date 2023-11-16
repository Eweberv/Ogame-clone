using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{ 
    private int productionPerSecond;
    private int energyCost;
   
    public virtual void Init(string name, int level, int productionPerSecond, int energyCost)
    {
        base.Init(name, level);
        this.productionPerSecond = productionPerSecond;
        this.energyCost = energyCost;
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
}
