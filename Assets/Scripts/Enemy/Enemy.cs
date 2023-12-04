using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Explosion explosion;
    Destructible destructible;
    public float dmg=10;

    void Awake()
    {
        explosion=GetComponent<Explosion>();
        destructible=GetComponent<Destructible>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Player")
        {
            explosion.explode(transform.position, dmg);
        }
    }

    public void die()
    {
        destructible.spawnGibs();
        explosion.explode(transform.position, 0);
    }

    void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Scene").GetComponent<EnemySpawner>().enemyList.Remove(gameObject);
    }
}
