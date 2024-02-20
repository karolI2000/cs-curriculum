using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private HUD hud;
    public int coin;
    private bool iframes;
    public float timer;
    public float originalTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        originalTimer = 0.5f;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Coin"))
        {
            AddCoin(1);
            other.gameObject.SetActive(false);
        }
    }

    void AddCoin(int amount)
    {
        hud.coin += amount;
    }
}

