using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    public UnityEngine.Vector3 target;
    private float timer;
    private float originalTimer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Enemy");
        originalTimer = 3;
        timer = originalTimer;
        target = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(current: transform.position,target, 0.0025f);
        }
    }
}
