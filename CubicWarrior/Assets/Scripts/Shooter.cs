using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet = null;
    [SerializeField] float cd = 0.3f;
    [SerializeField] Transform[] shootPoints = new Transform[0];
    [Header("Read Only")]
    [SerializeField] float counter = 0;
    bool canShoot => counter > 1;

    public void Shoot()
    {
        if(!canShoot)
        {
            return;
        }
        foreach (Transform shootPoint in shootPoints)
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        }
        counter = 0;
    }

    void Update()
    {
        if (counter > 1)
        {
            return;
        }
        counter = counter + Time.deltaTime / cd;
    }
}