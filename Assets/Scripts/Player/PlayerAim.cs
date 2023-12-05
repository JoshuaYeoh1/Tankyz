using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public GameObject tankHead, tankBarrel;
    public float turnTime=.2f;
    public bool canAim=true;

    void OnEnable()
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
                if(tankHead.transform.eulerAngles.y!=Camera.main.transform.eulerAngles.y)
                LeanTween.rotateY(tankHead, Camera.main.transform.eulerAngles.y, turnTime).setEaseOutSine();
                
                if(tankBarrel.transform.eulerAngles.x!=Camera.main.transform.eulerAngles.x)
                LeanTween.rotateX(tankBarrel, Camera.main.transform.eulerAngles.x-5, turnTime).setEaseOutSine();
            }
            else
            {
                if(tankHead.transform.eulerAngles!=new Vector3(0, 90, 0))
                LeanTween.rotateLocal(tankHead, new Vector3(0, 90, 0), turnTime).setEaseOutSine();

                if(tankBarrel.transform.eulerAngles!=Vector3.zero)
                LeanTween.rotateLocal(tankBarrel, Vector3.zero, turnTime).setEaseOutSine();
            }
        }
    }
}
