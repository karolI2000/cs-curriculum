using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public bool Overworld;
    public float xSpeed;
    public float ySpeed;
    public float xVector;
    public float xDirection;
    public Rigidbody2D rb;
    public float yVector;
    public float yDirection;
    public bool OnGround;
    public float RaycastLength = 0.25f;
    public float jump;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        xSpeed = 5;
        if (!Overworld)
        {
            ySpeed = 0;
            rb.gravityScale = 1;
        }
        else
        {
            ySpeed = 5;
            rb.gravityScale = 0;
        }

        jump = 300;
        OnGround = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        xVector = xDirection * xSpeed * Time.deltaTime;
        yDirection = Input.GetAxis("Vertical");
        yVector = yDirection * ySpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, yVector, 0);

        if (!Overworld)
        {
            if (OnGround && Input.GetKeyDown("space"))
            {
                rb.AddForce(new Vector2(0, jump));
                
            }

            OnGround = Physics2D.Raycast(transform.position, Vector2.down, RaycastLength);
            Debug.DrawRay(transform.position, -transform.up, Color.red);
        }
    }

}