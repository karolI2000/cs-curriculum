using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetting : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (other.CompareTag("Enemy"))
        {
            target = other;
            Debug.Log("Targetting Enemy");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = null;
            firingDelay = originalFiringDelay;
            Debug.Log("Targetting Enemy Stopped");
        }
    }
}