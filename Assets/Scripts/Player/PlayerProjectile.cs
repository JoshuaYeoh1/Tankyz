using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject explosionPrefab, hitboxPrefab;

    void OnCollisionEnter(Collision other)
    {
        explode();
    }

    void explode()
    {
        Singleton.instance.camShake();
        GameObject explo = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explo.transform.localScale = explo.transform.localScale*5;
        Instantiate(hitboxPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
