using UnityEngine;
using TMPro;

public class MyPlayerRessources : MonoBehaviour
{
    private int metal;
    private int cristal;
    private int deuterium;
    
    [SerializeField] private TextMeshProUGUI metalUI;
    [SerializeField] private TextMeshProUGUI cristalUI;
    [SerializeField] private TextMeshProUGUI deuteriumUI;

    private MyPlayerBuildings myPlayerBuildings;

    public void Init(int metal, int cristal, int deuterium)
    {
        this.metal = metal;
        this.cristal = cristal;
        this.deuterium = deuterium;
    }
    
    void Start()
    {
        metalUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("metalContainer").Find("metalCount").GetComponent<TextMeshProUGUI>();
        cristalUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("cristalContainer").Find("cristalCount").GetComponent<TextMeshProUGUI>();
        deuteriumUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("deuteriumContainer").Find("deuteriumCount").GetComponent<TextMeshProUGUI>();
          
        myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        
        UpdateRessourceText(metalUI, metal);
        UpdateRessourceText(cristalUI, cristal);
        UpdateRessourceText(deuteriumUI, deuterium);
        
        InvokeRepeating("IncrementMetalCount", 1f, 1f);
        InvokeRepeating("IncrementCristalCount", 1f, 1f);
        InvokeRepeating("IncrementDeuteriumCount", 1f, 1f);
    }
    
    public int Metal
    {
        get { return metal; }
        set
        {
            metal = value;
            UpdateRessourceText(metalUI, value);
        }
    }

    public int Cristal
    {
        get { return cristal; }
        set
        {
            cristal = value;
            UpdateRessourceText(cristalUI, value);
        }
    }
    
    public int Deuterium
    {
        get { return deuterium; }
        set
        {
            deuterium = value;
            UpdateRessourceText(deuteriumUI, value);
        }
    }

     void IncrementMetalCount()
    {
        Metal += myPlayerBuildings.MyMetalMine.ProductionPerSecond;
    }
    
     void IncrementCristalCount()
    {
        Cristal += myPlayerBuildings.MyCristalMine.ProductionPerSecond;
    }
     
     void IncrementDeuteriumCount()
     {
         Deuterium += myPlayerBuildings.MyDeuteriumMine.ProductionPerSecond;
     }
    
    void UpdateRessourceText(TextMeshProUGUI ressourceToUpdate, int value)
    {
        ressourceToUpdate.text = value.ToString();
    }
}
