using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyMovement : MonoBehaviour{
    public float EnemySpeed;
    public bool IsOn = false;
    public Collider2D target = null;
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
            if (IsOn=true)
            {
                transform.position=Vector2.MoveTowards(transform.position,target.gameObject.transform.position,EnemySpeed*Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.transform.GetChild(0).gameObject.CompareTag("Player"))
        {
            target = other;
            IsOn = true;
            Debug.Log("Following Player");
        }
    }
    
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.transform.GetChild(0).gameObject.CompareTag("Player"))
        {
            target = null;
            IsOn = false;
            Debug.Log("Following Player Stopped");
        }
    }
}
