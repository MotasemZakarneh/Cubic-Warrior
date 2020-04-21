using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform[] path = null;
    [SerializeField] int currPoint = 0;
    [SerializeField] float stoppingRad = 0.25f;

    Rigidbody rb3d => GetComponent<Rigidbody>();
    Mover mover => GetComponent<Mover>();
    Shooter shooter => GetComponent<Shooter>();

    void FixedUpdate()
    {
        if (Vector3.Distance(rb3d.position, path[currPoint].position) <= stoppingRad)
        {
            currPoint = (currPoint + 1) % path.Length;
            return;
        }
    }
    void Update()
    {
        Vector3 dir = (path[currPoint].position - rb3d.position);
        dir.y = 0;
        dir.Normalize();
        mover.TakeInput(dir.x, dir.z);
        shooter.Shoot();
    }
}
