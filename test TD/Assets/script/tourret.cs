using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourret : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject fireball;
    public bool trigger = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Instantiate(fireball, shootingPoint.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = true;
            Instantiate(fireball, shootingPoint.transform.position, Quaternion.identity);
        }
    }
}
