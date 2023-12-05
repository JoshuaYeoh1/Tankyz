using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMeshColor : MonoBehaviour
{
    public GameObject skinsGroup;
    public float rOffset=.5f, gOffset=-.5f, bOffset=-.5f;
    Renderer[] renderers;
    List<Color> defaultColors = new List<Color>();
    List<Color> defaultEmissionColors = new List<Color>();

    void Awake()
    {
        recordColor();
    }

    public void recordColor()
    {
        renderers=skinsGroup.GetComponentsInChildren<Renderer>();

        for(int j=0; j<renderers.Length; j++)
        {
            for(int i=0; i<renderers[j].materials.Length; i++)
            {
                defaultColors.Add(renderers[j].materials[i].color);
                defaultEmissionColors.Add(renderers[j].materials[i].GetColor("_EmissionColor"));
            }
        }
    }

    public void offsetColor()
    {
        for(int j=0; j<renderers.Length; j++)
        {
            for(int i=0; i<renderers[j].materials.Length; i++)
            {
                Color newColor = new Color(defaultColors[i].r+rOffset,
                                            defaultColors[i].g+gOffset,
                                            defaultColors[i].b+bOffset);

                renderers[j].materials[i].color = newColor;
                
                Color newEmissionColor = new Color(defaultEmissionColors[i].r+rOffset,
                                                    defaultEmissionColors[i].g+gOffset,
                                                    defaultEmissionColors[i].b+bOffset);

                renderers[j].materials[i].SetColor("_EmissionColor", newEmissionColor);
            }
        }
    }

    public void returnColor()
    {
        for(int j=0; j<renderers.Length; j++)
        {
            for(int i=0; i<renderers[j].materials.Length; i++)
            {
                Color oldColor = new Color(defaultColors[i].r, defaultColors[i].g, defaultColors[i].b);

                renderers[j].materials[i].color = oldColor;
                
                Color oldEmissionColor = new Color(defaultEmissionColors[i].r, defaultEmissionColors[i].g, defaultEmissionColors[i].b);

                renderers[j].materials[i].SetColor("_EmissionColor", oldEmissionColor);
            }
        }
    }

    public void flashColor(float time)
    {
        if(flashRt!=null) StopCoroutine(flashRt);
        flashRt = StartCoroutine(flashingColor(time));
    }

    Coroutine flashRt;
    IEnumerator flashingColor(float t)
    {
        offsetColor();
        yield return new WaitForSeconds(t);
        returnColor();
    }
}
