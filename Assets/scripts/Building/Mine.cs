using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public abstract class Mine : Building
{ 
    protected int _productionPerSecond;
    
    protected int _energyCost;
    
    protected List<MineData> _mineDatas;
    
    public abstract int ProductionPerSecond { get; }
    public abstract void UpdateProductionPerSecond();
    public abstract int EnergyCost { get; }
    public abstract void UpdateEnergyCost();
    public abstract int GetNextEnergyCost();
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

    public override int NextProductionDuration
    {
        get {
            var nextLevelData = _mineDatas.FirstOrDefault(pd => pd.level == Level + 1);
            return nextLevelData != null ? nextLevelData.productionDuration : 0;
        }
    }


}
