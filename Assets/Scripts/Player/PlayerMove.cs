using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [HideInInspector] public Vector3 dir;

    public float moveSpeed=30, acceleration=5f, deceleration=5f, velPower=1;
    public float turnSpeed=100;
    [HideInInspector] public bool dpadPressed, dpadUp, dpadDown, dpadLeft, dpadRight, canMove=true;

    public TrailParticles trackVFX;
    public AudioSource moveAudio;

    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        checkDpad();

        if(!dpadPressed) dir = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Mathf.Abs(dir.z)>Mathf.Abs(dir.y)) moveAudio.volume = Mathf.Abs(dir.z);
        else moveAudio.volume = Mathf.Abs(dir.y);
    }

    public void dpadUpToggle(bool toggle)
    {
        dpadUp=dpadPressed=toggle;
    }
    public void dpadDownToggle(bool toggle)
    {
        dpadDown=dpadPressed=toggle;
    }
    public void dpadLeftToggle(bool toggle)
    {
        dpadLeft=dpadPressed=toggle;
    }
    public void dpadRightToggle(bool toggle)
    {
        dpadRight=dpadPressed=toggle;
    }

    public void checkDpad()
    {
        if(dpadUp) dir.z = 1;
        else if(dpadDown) dir.z = -1;
        else dir.z = 0;

        if(dpadRight) dir.y = 1;
        else if(dpadLeft) dir.y = -1;
        else dir.y = 0;
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            turn();
            driveZ();
            driveX();
        }
    }

    void driveZ()
    {
        float targetSpeed = dir.z*moveSpeed;

        float speedDif = targetSpeed - Vector3.Dot(transform.forward, rb.velocity);

        float accelRate = Mathf.Abs(targetSpeed)>0 ? acceleration:deceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif)*accelRate, velPower)*Mathf.Sign(speedDif);

        rb.AddForce(transform.forward*movement);
    }

    void driveX()
    {
        float targetSpeed = dir.x*moveSpeed;

        float speedDif = targetSpeed - Vector3.Dot(transform.right, rb.velocity);

        float accelRate = Mathf.Abs(targetSpeed)>0 ? acceleration:deceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif)*accelRate, velPower)*Mathf.Sign(speedDif);

        rb.AddForce(transform.right*movement);
    }

    void turn()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y+dir.y*turnSpeed*Time.deltaTime, transform.eulerAngles.z);
    }

    public void stopMove(float time=.5f)
    {
        if(stopRt!=null) StopCoroutine(stopRt);
        stopRt=StartCoroutine(stoppingMove(time));
    }
    Coroutine stopRt;
    IEnumerator stoppingMove(float s)
    {
        canMove=false;
        yield return new WaitForSeconds(s);
        canMove=true;
    }
}
