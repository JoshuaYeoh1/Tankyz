using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Explosion explosion;
    Destructible destructible;
    public SkinRandomizer skin;
    public GameObject[] gibSkins;

    public float dmg=10;
    public Transform explodePos;

    void Awake()
    {
        explosion=GetComponent<Explosion>();
        destructible=GetComponent<Destructible>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Player")
        {
            explode(dmg);
        }
    }

    public void die()
    {
        explode(0);
    }

    void explode(float dmg=0)
    {
        destructible.gibbedVersion = gibSkins[skin.skin];
        destructible.spawnGibs();
        explosion.explode(explodePos.position, dmg);
    }

    void OnDestroy()
    {
        EnemySpawner spawner = GameObject.FindGameObjectWithTag("Scene").GetComponent<EnemySpawner>();
        if(spawner) spawner.enemyList.Remove(gameObject);
    }
}
