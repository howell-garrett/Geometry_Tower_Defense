using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one BM in scene");
        }
        instance = this;
    }

    //private GameObject whichTurretToBuild;
    public GameObject anotherTurretPrefab;
    public GameObject standardTurretPrefab;
    private TurretBlueprint turretToBuild;

    public bool CanBuildd {  get { return turretToBuild != null; } }

    public void selectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("you broke homie");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("remaining money" + PlayerStats.Money);
    }


}
