using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 offset;
    private Renderer rend;
    private Color originalColor;
    private GameObject turret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Space Full");
            return;
        }

        GameObject whichTurretToBuild = BuildingManager.instance.GetTurretToBuild();
       turret = (GameObject) Instantiate(whichTurretToBuild, transform.position + offset, transform.rotation);

    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}
