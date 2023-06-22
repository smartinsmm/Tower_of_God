using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a d�j� un BuildManager dans la sc�ne !");
            return;
        }
        instance = this;
    }



    private TurretBlueprint turretToBuild;

    private Node selectedNode;

    public NodeUI nodeUI;
    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SelectNode(Node node)
    {

        if (node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

}
