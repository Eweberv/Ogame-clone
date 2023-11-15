using UnityEngine;
using TMPro;

public class MyPlayerRessources : MonoBehaviour
{
    private int metal;
    private int cristal;
    
    [SerializeField] private TextMeshProUGUI metalUI;
    [SerializeField] private TextMeshProUGUI cristalUI;

    private MyPlayerBuildings myPlayerBuildings;

    public void Init(int metal, int cristal)
    {
        this.metal = metal;
        this.cristal = cristal;
    }
    
    void Start()
    {
        metalUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("metalContainer").Find("metalCount").GetComponent<TextMeshProUGUI>();
        cristalUI = GameManager._canvas.transform.Find("PlayerRessourcesPanel").Find("cristalContainer").Find("cristalCount").GetComponent<TextMeshProUGUI>();
          
        Debug.Log(metalUI);
        myPlayerBuildings = FindObjectOfType<MyPlayerBuildings>();
        
        UpdateRessourceText(metalUI, metal);
        UpdateRessourceText(cristalUI, cristal);
        
        InvokeRepeating("IncrementMetalCount", 1f, 1f);
        InvokeRepeating("IncrementcristalUI", 1f, 1f);
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

     void IncrementMetalCount()
    {
        Metal += myPlayerBuildings.MyMetalMine.ProductionPerSecond;
    }
    
     void IncrementcristalUI()
    {
        Cristal += myPlayerBuildings.MyCristalMine.ProductionPerSecond;
    }
    
    void UpdateRessourceText(TextMeshProUGUI ressourceToUpdate, int value)
    {
        ressourceToUpdate.text = value.ToString();
    }
}
