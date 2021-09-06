using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool canShoot;

    void Start()
    {
        
    }

    void Update()
    {
        if (canShoot)
            CountDownAndShoot();
    }

    void CountDownAndShoot() 
    {
    }
}
