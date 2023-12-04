using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    public void destroy(float time=0)
    {
        StartCoroutine(destroying(time));
    }

    IEnumerator destroying(float t)
    {
        yield return new WaitForSeconds(t);

        Instantiate(destroyedVersion, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
