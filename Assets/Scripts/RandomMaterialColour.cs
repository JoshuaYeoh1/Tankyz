using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialColour : MonoBehaviour
{
    Renderer mesh;

    void Awake()
    {
        mesh=GetComponent<Renderer>();

        foreach(Material mat in mesh.materials)
        {
            mat.SetColor("_Color", randomColor());
            mat.SetColor("_EmissionColor", randomColor());
        }
    }

    Color randomColor()
    {
        return new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
    }
}
