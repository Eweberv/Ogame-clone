using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class MyPlayerBuildings : MonoBehaviour
{
    private MetalMine _myMetalMine;
    private CristalMine _myCristalMine;
    private Stats _stats;

    void Awake()
    {
        GameObject Building = new GameObject("Building");
        _myMetalMine = Building.AddComponent<MetalMine>();
        _myMetalMine.Init("Metal Mine", 0, 0, 0);

        _myCristalMine = Building.AddComponent<CristalMine>();
        _myCristalMine.Init("Cristal Mine", 0, 0, 0);
        
        Debug.Log($"name: {_myCristalMine.name}");
    }
    
    void Start()
    {
        
    }
    
    public MetalMine MyMetalMine
    {
        get { return _myMetalMine; }
    }
    public CristalMine MyCristalMine
    {
        get { return _myCristalMine; }
    }
}
