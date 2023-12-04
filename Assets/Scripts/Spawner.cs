using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public int minNum=0, maxNum=3;
    public float chance=33, maxRange=15;

    void Awake()
    {
        if(chance<=Random.Range(0,100f))
        {
            int num = Random.Range(minNum, maxNum+1);

            if(num>0)
            {
                for(int i=0; i<num; i++)
                {
                    Instantiate (prefabs[Random.Range(0, prefabs.Length)],
                                new Vector3(transform.position.x+Random.Range(-maxRange,maxRange),
                                            transform.position.y,
                                            transform.position.z+Random.Range(-maxRange,maxRange)),
                                Quaternion.identity);
                }
            }
        }
    }
}
