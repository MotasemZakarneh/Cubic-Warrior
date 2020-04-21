using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Mover mover => GetComponent<Mover>();
    Shooter shooter => GetComponent<Shooter>();

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        mover.TakeInput(x, z);
        if (Input.GetKey(KeyCode.Space))
        {
            shooter.Shoot();
        }
    }

    void FixedUpdate()
    {

    }
}