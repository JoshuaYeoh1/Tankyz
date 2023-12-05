using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float dmg=100;

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Explosion>().explode(transform.position, dmg);
    }
}
