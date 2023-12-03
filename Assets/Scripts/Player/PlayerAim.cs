using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public GameObject tankHead, tankBarrel;
    public float turnTime=.2f;
    public bool canAim=true;

    void Awake()
    {
        StartCoroutine(aiming());
    }

    IEnumerator aiming()
    {
        while(true)
        {
            yield return new WaitForSeconds(turnTime);

            if(canAim)
            {
                LeanTween.rotateY(tankHead, Camera.main.transform.eulerAngles.y, turnTime).setEaseOutSine();

                LeanTween.rotateX(tankBarrel, Camera.main.transform.eulerAngles.x-10, turnTime).setEaseOutSine();
            }
            else
            {
                LeanTween.rotateY(tankHead, 90, turnTime).setEaseOutSine();

                LeanTween.rotateX(tankBarrel, 0, turnTime).setEaseOutSine();
            }
        }
    }
}
