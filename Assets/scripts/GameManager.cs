using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameObject holding scripts
    private GameObject _scripts;

    public static GameObject _canvas;
    private MyPlayerRessources _playerRessources;
    private UpgradeHandler _upgradeHandler;
    private MyPlayerBuildings _myPlayerBuildings;
    private Stats _stats;
    
    void Awake()
    {
        _canvas = GameObject.Find("Canvas");
        if (!_canvas)
        {
            Debug.LogError("GameObject 'Canvas' not found in the scene.");
            return;
        }

        _scripts = GameObject.Find("Scripts");
        if (!_scripts)
        {
            Debug.LogError("GameObject 'scripts' not found in the scene.");
            return;
        
        }
        
        //Init player ressources
        _playerRessources = _scripts.AddComponent<MyPlayerRessources>();
        _playerRessources.Init(1000, 1000);

        //Init player buildings
        _myPlayerBuildings = _scripts.AddComponent<MyPlayerBuildings>();
        
        //Init upgrade handler
        //_upgradeHandler = _scripts.AddComponent<UpgradeHandler>();
        _upgradeHandler = FindObjectOfType<UpgradeHandler>();
        
        //Init stats panel
        _stats = _scripts.AddComponent<Stats>();
    }
}
