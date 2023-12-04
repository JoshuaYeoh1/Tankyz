using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    HPManager hp;
    Explosion explosion;
    Destructible destructible;
    SceneScript scene;

    bool iframe;
    public float iframeTime=.5f;

    void Awake()
    {
        hp=GetComponent<HPManager>();
        explosion=GetComponent<Explosion>();
        destructible=GetComponent<Destructible>();
        scene=GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneScript>();
    }
    
    public void hit(float dmg)
    {
        if(!iframe)
        {
            hp.hit(dmg);

            if(hp.hp>0)
            {
                StartCoroutine(iframing());
                StartCoroutine(scene.hurtAnim());
            }
            else die();
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

        StartCoroutine(scene.dieAnim());

        //Singleton.instance.playSFX(Singleton.instance.sfxUiLose, transform, false);

        destructible.spawnGibs();
        explosion.explode(transform.position, 0);
    }
}
