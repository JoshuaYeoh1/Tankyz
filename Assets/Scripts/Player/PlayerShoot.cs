using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Transform firepoint, barrel;
    public GameObject projectilePrefab, muzzleflashPrefab;
    bool canShoot=true;
    public float ammo=5, coolTime=1, shootForce=200;
    float coolLevel;
    public Image coolBar;
    public TextMeshProUGUI textAmmo;

    void OnEnable()
    {
        StartCoroutine(cooling());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) shoot();    

        textAmmo.text = ammo.ToString();    
    }

    public void shoot()
    {
        if(canShoot && ammo>0 && coolLevel<=0)
        {
            coolLevel=coolTime;
            ammo--;

            Singleton.instance.playSFX(Singleton.instance.sfxPlayerShoot, firepoint.position);

            Singleton.instance.camShake();

            GameObject bullet = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firepoint.forward*shootForce, ForceMode.Impulse);

            GameObject muzzle = Instantiate(muzzleflashPrefab, firepoint.position, Quaternion.identity);
            muzzle.transform.localScale = muzzle.transform.localScale*8;
        }
    }

    IEnumerator cooling()
    {
        while(true)
        {
            yield return new WaitForSeconds(.01f);

            if(coolLevel>0)
            {
                coolLevel-=.01f;

                if(coolBar) coolBar.fillAmount = coolLevel/coolTime;
            }
        }
    }
}
