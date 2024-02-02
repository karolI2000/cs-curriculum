using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool Overworld;
    public float walkSpeed;
    public float xVector;
    public float xDirection;
    public float yVector;
    public float yDirection;
    public bool OnGround;
    public float RaycastLength = 1f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 4;
        OnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        xVector = xDirection * walkSpeed * Time.deltaTime;
        yVector = yDirection * walkSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, yVector, 0);
        OnGround = Physics2D.Raycast(transform.position, Vector2.down, RaycastLength);
        if (Overworld != true)
        {
            xDirection = Input.GetAxis("Horizontal");
            yDirection = Input.GetAxis("Vertical");
            xVector = xDirection * walkSpeed * Time.deltaTime;
            yVector = yDirection * walkSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(xVector, yVector, 0);
        }
    }

    
}