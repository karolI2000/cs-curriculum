using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using TMPro;
using UnityEditor;

public class HUD : MonoBehaviour
{
    public static HUD hud;
    public int coins;
    public int health;
    public int maxHealth;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    public void Awake()
    {
        if (hud != null && hud!= this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        coins = 0;
        maxHealth = 5;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ("Coins: ") + coins;
        healthText.text = ("Health: ") + health;
    }
}