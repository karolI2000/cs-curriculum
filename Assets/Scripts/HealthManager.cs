using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private bool iframes = true;

    public int health;
    double timer;
    double originalTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        originalTimer = 1.5;
        timer = originalTimer;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            ChangeHealth(3);
        }
    }

    void ChangeHealth(int amount)
    {
        if (iframes)
        {
            iframes = true;
            health -= amount;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (iframes)
        {
            timer = Time.deltaTime;
            if (timer < 0)
            {
                iframes = false;
                timer = originalTimer;
            }
        }
    }
}
