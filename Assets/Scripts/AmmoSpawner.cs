using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject ammoPrefab;
    GameObject spawnedAmmo;
    public float respawnTime=30;
    bool busy;

    void Awake()
    {
        spawnAmmo();
    }

    void spawnAmmo()
    {
        spawnedAmmo = Instantiate(ammoPrefab, spawnPos.position, Quaternion.identity, spawnPos);
        busy=false;
    }
    
    void Update()
    {
        if(!spawnedAmmo && !busy)
        {
            busy=true;
            Invoke("spawnAmmo", respawnTime);
        }
    }
}
