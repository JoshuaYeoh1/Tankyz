using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firepoint, barrel;
    public GameObject projectilePrefab, muzzleflashPrefab;
    bool canShoot=true;
    public float ammo=10, coolTime=.5f, shootForce=200;

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

            GameObject bullet = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firepoint.forward*shootForce, ForceMode.Impulse);

            GameObject muzzle = Instantiate(muzzleflashPrefab, firepoint.position, Quaternion.identity);
            muzzle.transform.localScale = muzzle.transform.localScale*8;
        }
    }

    IEnumerator cooling()
    {
        canShoot=false;
        yield return new WaitForSeconds(coolTime);
        canShoot=true;
    }
}
