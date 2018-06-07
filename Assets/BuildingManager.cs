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

    private GameObject whichTurretToBuild;

    public GameObject standardTurretPrefab;
    private void Start()
    {
        whichTurretToBuild = standardTurretPrefab;
    }


    public GameObject GetTurretToBuild()
    {
        return whichTurretToBuild;
    }

}
