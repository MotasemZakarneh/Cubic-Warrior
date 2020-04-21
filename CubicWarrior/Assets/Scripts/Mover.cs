using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform rotatedAxis = null;
    [SerializeField] float speed = 7;

    Vector3 vel;
    Vector2 input;
    Rigidbody rb3d => GetComponent<Rigidbody>();
    Vector3 right => rotatedAxis ? rotatedAxis.right : Vector3.right;
    Vector3 forward => rotatedAxis ? rotatedAxis.forward : Vector3.forward;

    public void TakeInput(float x,float y)
    {
        input.Set(x,y);
    }
    void FixedUpdate()
    {
        Vector3 dir = new Vector3();

        if (Mathf.Abs(input.x) > Mathf.Epsilon)
        {
            dir = right * Mathf.Sign(input.x);
        }
        if (Mathf.Abs(input.y) > Mathf.Epsilon)
        {
            dir = dir + forward * Mathf.Sign(input.y);
        }

        dir.Normalize();

        vel.x = dir.x * speed;
        vel.z = dir.z * speed;

        rb3d.velocity = vel;
        input.Set(0, 0);
    }
}
