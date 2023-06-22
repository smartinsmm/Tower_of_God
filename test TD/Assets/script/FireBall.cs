using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Transform target;

    public int damage = 50;

    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Destroy(gameObject);
        Damage(target);
    }

    void Damage(Transform ennemi)
    {
        Ennemi e = ennemi.GetComponent<Ennemi>();
        if (e != null)
        {
            e.TakeDammage(damage);
        }
        else
        {
            Debug.LogError("Pas de script Enemy sur l'ennemi.");
        }
    }
}

