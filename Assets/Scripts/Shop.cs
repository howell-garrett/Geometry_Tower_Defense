using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildingManager buildmanager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;


    void Start()
    {
        buildmanager = BuildingManager.instance;
    }

    public void StandardTurretSelect()
    {
        buildmanager.selectTurretToBuild(standardTurret);
      
    }

    public void MissleTurretSelect()
    {
        buildmanager.selectTurretToBuild(missleLauncher);
    }
    
}
