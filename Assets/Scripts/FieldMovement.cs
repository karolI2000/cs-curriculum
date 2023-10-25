using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMovement : MonoBehaviour
{
    public float walkSpeed;
    public float xVector;
    public float xDirection;
    public float yVector;
    public float yDirection;

    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        xVector = xDirection * walkSpeed * Time.deltaTime;
        yVector = yDirection * walkSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, yVector, 0);
    }
}