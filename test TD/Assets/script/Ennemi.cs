using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemi : MonoBehaviour
{
    public float speed = 10;
    private Transform target;
    private int WaypointIndex = 0;

    public float startHealth = 100f;
    private float health;
    public int value = 50;

    public Image healthbar;

    private void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }
    public void TakeDammage(int amount)
    {
        health -= amount;
        healthbar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.money += value;

        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime) ;

        if (Vector3.Distance(transform.position , target.position) <= 0.2)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (WaypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        
        WaypointIndex++;
        target = Waypoints.points[WaypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
