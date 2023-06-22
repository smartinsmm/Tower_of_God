using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    private Color startColor;
    private Renderer rend;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour am�liorer la tourelle.");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        // Supression de l'ancienne tourelle
        Destroy(turret);

        // Cr�ation de la nouvelle tourelle am�lior�e.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        Debug.Log("Tourelle am�lior�e.");
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        Debug.Log("La tourelle a �t� construite.");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }
        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
