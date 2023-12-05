using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnim : MonoBehaviour
{
    public float animTime=2, bobHeight=1;
    public Vector3 spinAxis=Vector3.up;

    void Awake()
    {
        spin();
        bob();
    }

    void spin()
    {
        LeanTween.rotateAround(gameObject, spinAxis, 360, animTime).setLoopClamp();
    }
    
    void bob()
    {
        LeanTween.moveY(gameObject, transform.position.y+bobHeight, animTime*.5f).setLoopPingPong().setEaseInOutSine();
    }
}
