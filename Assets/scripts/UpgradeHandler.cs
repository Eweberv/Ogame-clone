using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{
    private Button upgradeMetalMineBtn;
    private Button upgradeCristalMineBtn;
    private MyPlayerBuildings myPlayerBuildings;
    private Stats stats;
    
    void Start()
    {
        upgradeMetalMineBtn = GameManager._canvas.transform.Find("metalMineUpgradeBtnTest").GetComponent<Button>();
        upgradeCristalMineBtn = GameManager._canvas.transform.Find("cristalMineUpgradeBtnTest").GetComponent<Button>();
        
        myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        stats = FindObjectOfType<Stats>();
        upgradeMetalMineBtn.onClick.AddListener(delegate{upgradeMine(myPlayerBuildings.MyMetalMine);});
        upgradeCristalMineBtn.onClick.AddListener(delegate{upgradeMine(myPlayerBuildings.MyCristalMine);});
    }
    
    void upgradeMine(Mine mine)
    {
        mine.Level += 1;
        if (mine.name == "Metal Mine")
        {
            mine.ProductionPerSecond += 1000;
        }
        else
        {
            mine.ProductionPerSecond += 500;
        }
        stats.UpdateMineStats();
        Debug.Log($"Mine infos: lvl:{mine.Level}, production: {mine.ProductionPerSecond}");
    }
}
