using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
BuildManager buildManager;

    void Start() 
    {
        buildManager = BuildManager.instance;
    }

    public void arrowTurret ()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void explosiveTurret ()
    {
        buildManager.SetTurretToBuild(buildManager.explosiveTurretPrefab);
    }
}
