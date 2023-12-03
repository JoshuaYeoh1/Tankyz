using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float moveDir, turnDir;
    public float moveSpeed=10, turnSpeed=10;

    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        keyboard();
        movement();
    }

    void keyboard()
    {
        if(Input.GetKey(KeyCode.W)) moveFront();
        else if(Input.GetKey(KeyCode.S)) moveBack();
        else if(Input.GetKeyUp(KeyCode.W) && moveDir>0) moveStop();
        else if(Input.GetKeyUp(KeyCode.S) && moveDir<0) moveStop();

        if(Input.GetKey(KeyCode.A)) turnLeft();
        else if(Input.GetKey(KeyCode.D)) turnRight();
        else if(Input.GetKeyUp(KeyCode.A) && turnDir<0) turnStop();
        else if(Input.GetKeyUp(KeyCode.D) && turnDir>0) turnStop();
    }

    public void moveFront()
    {
        moveDir=1;
    }
    public void moveBack()
    {
        moveDir=-1;
    }
    public void moveStop()
    {
        moveDir=0;
    }

    public void turnRight()
    {
        turnDir=1;
    }
    public void turnLeft()
    {
        turnDir=-1;
    }
    public void turnStop()
    {
        turnDir=0;
    }

    void movement()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveDir*moveSpeed);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y+turnDir*turnSpeed*Time.deltaTime, transform.localEulerAngles.z);
    }
}
