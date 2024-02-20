using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxEnemyHealth;
    public int EnemyHealth;
    private bool iframes;
    public float timer;
    public float originalTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        MaxEnemyHealth = 10;
        EnemyHealth = MaxEnemyHealth;
        iframes = false;
        originalTimer = 0.5f;
        timer = originalTimer;
    }
    // Update is called once per frame
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
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Projectile"))
        {
            LoseHealth(2);
            other.gameObject.SetActive(false);
            Debug.Log("Enemy Hit");
        }
    }
    void LoseHealth(int amount)
    {
        if (!iframes)
        {
            iframes = true;
            EnemyHealth -= amount;
        }
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
