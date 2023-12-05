using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    HPManager hp;
    Explosion explosion;
    Destructible destructible;
    PlayerFeedback feedback;
    ChangeMaterialColor color;
    PlayerMove move;
    PlayerShoot shoot;

    bool iframe;
    public float iframeTime=.5f;
    public Transform explodePos;

    void Awake()
    {
        hp=GetComponent<HPManager>();
        explosion=GetComponent<Explosion>();
        destructible=GetComponent<Destructible>();
        feedback=GameObject.FindGameObjectWithTag("Scene").GetComponent<PlayerFeedback>();
        color=GetComponent<ChangeMaterialColor>();
        move=GetComponent<PlayerMove>();
        shoot=GetComponent<PlayerShoot>();
    }
    
    public void hit(float dmg)
    {
        if(!iframe)
        {
            hp.hit(dmg);

            if(hp.hp>0)
            {
                StartCoroutine(iframing());
                color.flashColor(.1f);
                move.stopMove(.5f);
                if(hp.hp>dmg) feedback.hurtAnim();
            }
            else die();

            Singleton.instance.playSFX(Singleton.instance.sfxSubwoofer, transform.position, false);
        }
    }

    IEnumerator iframing()
    {
        iframe=true;
        yield return new WaitForSeconds(iframeTime);
        iframe=false;
    }

    void die()
    {
        iframe=true;
        gameObject.layer=0;

        feedback.dieAnim();

        //Singleton.instance.playSFX(Singleton.instance.sfxUiLose, transform, false);

        destructible.spawnGibs();
        explosion.explode(explodePos.position, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Ammo")
        {
            shoot.ammo+=3;
            Destroy(other.gameObject);
            Singleton.instance.playSFX(Singleton.instance.sfxAmmoPickup, transform.position);
        }
    }

    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Q)) hit(10);
    // }
}
