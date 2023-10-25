using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Rigidbody2D fireball;
    public Collider2D target;
    private float originalFiringDelay;
    private float firingDelay;
    void Start()
    {
        originalFiringDelay = 1f;
        firingDelay = originalFiringDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            
        }
    }
}
