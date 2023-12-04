using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float vfxScaleMult=5, blastRadius=10, blastForce=1000;
    public LayerMask blastLayerMask;

    public void explode(Vector3 pos, float dmg=0)
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
            if(dmg>0)
            {
                if(other.gameObject.tag=="Player")
                {
                    Player player = other.GetComponent<Player>();

                    if(player) player.hit(dmg);
                }
                else if(other.gameObject.tag=="Enemy")
                {
                    Enemy enemy = other.GetComponent<Enemy>();

                    if(enemy) enemy.die();
                }
            }
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
