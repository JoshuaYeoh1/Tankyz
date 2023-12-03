using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float moveDir, moveSpeed;

    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) moveDir=1;
        else if(Input.GetKeyDown(KeyCode.S)) moveDir=-1;

        movement();
    }

    void movement()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveDir*moveSpeed);
    }
}
