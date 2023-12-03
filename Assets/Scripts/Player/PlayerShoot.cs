using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firepoint, barrel;
    public GameObject projectilePrefab;
    bool canShoot=true;
    public float ammo=10, coolTime=.5f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    public void shoot()
    {
        if(canShoot && ammo>0)
        {
            //ammo--;
            StartCoroutine(cooling());
            Singleton.instance.camShake();
            //instantiate at firepoint
        }
    }

    IEnumerator cooling()
    {
        canShoot=false;
        yield return new WaitForSeconds(coolTime);
        canShoot=true;
    }
}
