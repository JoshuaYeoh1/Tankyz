using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public GameObject tankHead, tankBarrel;
    
    public bool canAim=true;
    public float aimSpeed=250;

    void Update()
    {
        if(canAim)
        {
            Quaternion tankHeadAimedY = Quaternion.Euler(tankHead.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, tankHead.transform.eulerAngles.z);
            
            tankHead.transform.rotation = Quaternion.RotateTowards(tankHead.transform.rotation, tankHeadAimedY, Time.deltaTime*aimSpeed);

            Quaternion tankBarrelAimedX = Quaternion.Euler(Camera.main.transform.eulerAngles.x-3.5f, tankBarrel.transform.eulerAngles.y, tankBarrel.transform.eulerAngles.z);

            tankBarrel.transform.rotation = Quaternion.RotateTowards(tankBarrel.transform.rotation, tankBarrelAimedX, Time.deltaTime*aimSpeed);
        }
    }
}
