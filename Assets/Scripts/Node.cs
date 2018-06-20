
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 offset;
    private Renderer rend;
    private Color originalColor;

    [Header("Optional")]
    public GameObject turret;

    BuildingManager buildmanager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        buildmanager = BuildingManager.instance;

    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (!buildmanager.CanBuildd)
            return;

        if (turret != null)
        {
            Debug.Log("Space Full");
            return;
        }

        buildmanager.BuildTurretOn(this);

        
      
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + offset;


    }

    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildmanager.CanBuildd)
            return;


        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}
