using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public abstract class Storage : Building
{
   protected int _capacity;
   protected List<StorageData> _storageDatas;
   public abstract List<StorageData> StorageDatas { get; }

   public override void Init(string name, int level)
   {
      base.Init(name, level);
      _capacity = Capacity;
      ValidateStorage();
   }
   
   protected void ValidateStorage()
   {
      ValidateBuilding();
      if (_storageDatas == null || _storageDatas.Count == 0)
      {
         Debug.LogError($"Storage not properly initialized ({_buildingName}): _storageDatas is empty or null");
      }
   }

   public int Capacity
   {
      get
      {
         var currentCapacity = _storageDatas.FirstOrDefault(elem => elem.level == Level);
         return currentCapacity != null ? currentCapacity.capacity : 0;
      }
   }
   public override int Level
   {
      get { return _level; }
      set { _level = value; }
   }
   public override string BuildingName
   {
      get { return _buildingName; }
   }
   public override string Description
   {
      get { return _description; }
   }
   public override Sprite BuildingSprite
   {
      get { return _buildingSprite; }
      set { _buildingSprite = value; }
   }
   
   public override int NextProductionDuration
   {
      get {
         var nextLevelData = _storageDatas.FirstOrDefault(pd => pd.level == Level + 1);
         return nextLevelData != null ? nextLevelData.productionDuration : 0;
      }
   }
}
