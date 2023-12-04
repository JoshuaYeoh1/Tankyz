using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float vfxScaleMult=5, blastRadius=10, blastForce=700;
    public LayerMask blastLayerMask;

    public void explode(Vector3 pos)
    {
        Singleton.instance.camShake();

        if(explosionPrefab)
        {
            GameObject explo = Instantiate(explosionPrefab, pos, Quaternion.identity);
            if(vfxScaleMult!=1) explo.transform.localScale = explo.transform.localScale*vfxScaleMult;
        }
        
        Collider[] collidersToDmg =  Physics.OverlapSphere(pos, blastRadius, blastLayerMask);

        foreach(Collider other in collidersToDmg)
        {
            // Rigidbody otherRb = other.GetComponent<Rigidbody>();

            // if(otherRb) otherRb.AddExplosionForce(blastForce, pos, blastRadius);
        }

        Collider[] collidersToPush =  Physics.OverlapSphere(pos, blastRadius*2, blastLayerMask);

        foreach(Collider other in collidersToPush)
        {
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            if(!otherRb) otherRb = other.transform.root.GetComponent<Rigidbody>();

            if(otherRb) otherRb.AddExplosionForce(blastForce, pos, blastRadius*2);
        }

        Destroy(gameObject);
    }
}
