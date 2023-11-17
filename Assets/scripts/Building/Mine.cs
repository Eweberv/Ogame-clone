using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public abstract class Mine : Building
{ 
    protected int _productionPerSecond;
    protected int _energyCost;
    protected List<MineData> _mineDatas;
    public abstract List<MineData> MineDatas { get; }
    
    public override void Init(string name, int level)
    {
        base.Init(name, level);
    }
    
    protected void validateMine()
    {
        ValidateBuilding();
        if (_mineDatas == null || _mineDatas.Count == 0)
        {
            Debug.LogError($"Mine not properly initialized: ({_buildingName}): _mineDatas is empty or null");
        }
    }
    public int ProductionPerSecond
    {
        get
        {
            var data = _mineDatas.FirstOrDefault(pd => pd.level == Level);
            return data != null ? data.productionPerSecond : 0;
        }
    }
    public int EnergyCost
    {
        get
        {
            var energyCost = _mineDatas.FirstOrDefault(pd => pd.level == Level);
            return energyCost != null ? energyCost.energyCost : 0;
        }
        set { _energyCost = value; }
    }

    public override int NextProductionDuration
    {
        get {
            var nextLevelData = _mineDatas.FirstOrDefault(pd => pd.level == Level + 1);
            return nextLevelData != null ? nextLevelData.productionDuration : 0;
        }
    }
}
