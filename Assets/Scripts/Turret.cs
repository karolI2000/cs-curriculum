using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    private Collider2D target;
    private float originalFiringDelay;
    private float firingDelay;
    private Vector3 ySpawn;
    void Start()
    {
        target = null;
        originalFiringDelay = 1f;
        firingDelay = originalFiringDelay;
    }

    // Update is called once per frame
    void Update()
    {
        firingDelay -= Time.deltaTime;
        if (firingDelay < 0)
        {
            firingDelay = originalFiringDelay;
            if (target != null)
            {
                ySpawn = transform.position;
                ySpawn.y += 1;
                Instantiate(fireball, ySpawn, transform.rotation);
            }
        }
    }
     void OnTriggerEnter2D(Collider2D other) 
     {
         if (other.gameObject.CompareTag("Player"))
         {
             target = other;
             Debug.Log("Targetting Player");
         }
     }

     private void OnTriggerExit2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             target = null;
             firingDelay = originalFiringDelay;
             Debug.Log("Targetting Stopped");
         }
     }
}
