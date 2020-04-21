using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 14;
    [SerializeField] float damage = 1;
    Rigidbody rb3d => GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        rb3d.velocity = speed * transform.forward;
    }
    void OnTriggerEnter(Collider col)
    {
        Health h = col.GetComponent<Health>();
        if (h)
        {
            h.TakeDamage(damage);
        }
        if(col.GetComponent<Bullet>())
        {
            return;
        }
        Destroy(gameObject);
    }
}
