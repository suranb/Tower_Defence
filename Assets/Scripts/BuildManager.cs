using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;

    // Property Syntax 
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enought Money to build");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;

        // node.GetBuildPosition()
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, transform.rotation);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), transform.rotation);
        Destroy(effect, 1f);

        Debug.Log("TurretBuild! Money left: " + PlayerStats.Money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
