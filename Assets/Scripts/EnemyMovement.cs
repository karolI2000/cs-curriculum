using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    public float EnemySpeed;
    public bool IsOn = false;
    public Collider target = null;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //target = other;
            Debug.Log("Targeting Player");
        }
    }
}
