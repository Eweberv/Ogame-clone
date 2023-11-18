using UnityEngine;
using TMPro;

public class MyPlayerRessources : MonoBehaviour
{
    private int metal;
    private int cristal;
    private int deuterium;
    private int energy;
    
    [SerializeField] private TextMeshProUGUI metalUI;
    [SerializeField] private TextMeshProUGUI cristalUI;
    [SerializeField] private TextMeshProUGUI deuteriumUI;
    [SerializeField] private TextMeshProUGUI energyUI;

    private MyPlayerBuildings myPlayerBuildings;

    public void Init(int metal, int cristal, int deuterium,int energy)
    {
        this.metal = metal;
        this.cristal = cristal;
        this.deuterium = deuterium;
        this.energy = energy;
    }
    
    void Start()
    {
        metalUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("metalContainer").Find("metalCount").GetComponent<TextMeshProUGUI>();
        cristalUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("cristalContainer").Find("cristalCount").GetComponent<TextMeshProUGUI>();
        deuteriumUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("deuteriumContainer").Find("deuteriumCount").GetComponent<TextMeshProUGUI>();
        energyUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("energyContainer").Find("energyCount").GetComponent<TextMeshProUGUI>();
          
        myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        
        UpdateRessourceText(metalUI, metal);
        UpdateRessourceText(cristalUI, cristal);
        UpdateRessourceText(deuteriumUI, deuterium);
        
        InvokeRepeating("IncrementMetalCount", 1f, 1f);
        InvokeRepeating("IncrementCristalCount", 1f, 1f);
        InvokeRepeating("IncrementDeuteriumCount", 1f, 1f);
        InvokeRepeating("setCurrentEnergy", 1f, 1f);
    }
    
    public int Metal
    {
        get => metal;
        set
        {
            metal = value;
            UpdateRessourceText(metalUI, value);
        }
    }

    public int Cristal
    {
        get => cristal;
        set
        {
            cristal = value;
            UpdateRessourceText(cristalUI, value);
        }
    }
    
    public int Deuterium
    {
        get => deuterium;
        set
        {
            deuterium = value;
            UpdateRessourceText(deuteriumUI, value);
        }
    }
    
    public int Energy
    {
        get => energy;
        set
        {
            energy = value;
            UpdateRessourceText(energyUI, value);
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
     
    void setCurrentEnergy()
    {
        //TODO : replace 0 with solar plant generated energy
        Energy = 0 - (myPlayerBuildings.MyMetalMine.EnergyCost +
                      myPlayerBuildings.MyCristalMine.EnergyCost +
                      myPlayerBuildings.MyDeuteriumMine.EnergyCost);
    }
    
    void UpdateRessourceText(TextMeshProUGUI ressourceToUpdate, int value)
    {
        ressourceToUpdate.text = value.ToString();
    }
}