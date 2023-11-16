using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Storage : Building
{
   private int _capacity;
   private List<StorageData> _storageCapacities;

   override public void Init(string name, int level)
   {
      base.Init(name, level);
      _capacity = Capacity;
   }

   public int Capacity
   {
      get
      {
         var currentCapacity = _storageCapacities.FirstOrDefault(elem => elem.level == Level);
         return currentCapacity != null ? currentCapacity.capacity : 0;
      }
   }
   
   void Awake()
   {
      _storageCapacities = new List<StorageData>
      {
         new StorageData { level = 1, capacity = 20000 },
         new StorageData { level = 2, capacity = 40000 },
         new StorageData { level = 3, capacity = 75000 },
         new StorageData { level = 4, capacity = 140000 },
         new StorageData { level = 5, capacity = 255000 },
         new StorageData { level = 6, capacity = 470000 },
         new StorageData { level = 7, capacity = 865000 },
         new StorageData { level = 8, capacity = 1590000 },
         new StorageData { level = 9, capacity = 2920000 },
         new StorageData { level = 10, capacity = 5355000 },
         new StorageData { level = 11, capacity = 9820000 },
         new StorageData { level = 12, capacity = 18005000 },
         new StorageData { level = 13, capacity = 33005000 },
         new StorageData { level = 14, capacity = 60510000 },
         new StorageData { level = 15, capacity = 110925000 },
      };
   }
}
