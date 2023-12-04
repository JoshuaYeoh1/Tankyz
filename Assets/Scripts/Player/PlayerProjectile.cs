using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        GetComponent<Explosion>().explode(transform.position);
    }
}
