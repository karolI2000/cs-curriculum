using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private HUD hud;
    private bool iframes;
    
    public float timer;
    public float originalTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        originalTimer = 1.5f;
        timer = originalTimer;
        iframes = false;
    }
    void Update()
    {
        if (iframes)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                iframes = false;
                timer = originalTimer;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            LoseHealth(2);
            Debug.Log("Player Spiked");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            LoseHealth(3);
            Debug.Log("Player Attacked");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HealthPotion"))
        {
            AddHealth(2);
            other.gameObject.SetActive(false);
            Debug.Log("Health Potion");
        }
        if (other.gameObject.CompareTag("Turret_Projectile"))
        {
            LoseHealth(1);
            other.gameObject.SetActive(false);
            Debug.Log("Player Shot");
        }
    }
    void LoseHealth(int amount)
    {
        if (!iframes)
        {
            iframes = true;
            hud.health -= amount;
        }
        if (hud.health<=0)
        {
            Destroy(gameObject);
        }
    }
    void AddHealth(int amount)
    {
        hud.health += amount;
    }
}
