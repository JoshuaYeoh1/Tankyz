using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float destroyTime=.1f, animTime=.5f;

    void Start()
    {
        LeanTween.scale(gameObject, Vector3.zero, animTime).setDelay(destroyTime).setEaseInOutSine();

        Destroy(gameObject, destroyTime+animTime);
    }
}
