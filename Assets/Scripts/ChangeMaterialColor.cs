using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    List<Color> defaultColors = new List<Color>();
    List<Color> defaultEmissionColors = new List<Color>();

    public float rOffset=.5f, gOffset=-.5f, bOffset=-.5f;
    
    void Awake()
    {
        recordColor();
    }

    public void recordColor()
    {
        for(int i=0; i<materials.Count; i++)
        {
            defaultColors.Add(materials[i].color);
            defaultEmissionColors.Add(materials[i].GetColor("_EmissionColor"));
        }
    }

    public void offsetColor()
    {
        for(int i=0; i<materials.Count; i++)
        {
            Color newColor = new Color(defaultColors[i].r+rOffset,
                                        defaultColors[i].g+gOffset,
                                        defaultColors[i].b+bOffset);

            materials[i].color = newColor;
            
            Color newEmissionColor = new Color(defaultEmissionColors[i].r+rOffset,
                                                defaultEmissionColors[i].g+gOffset,
                                                defaultEmissionColors[i].b+bOffset);

            materials[i].SetColor("_EmissionColor", newEmissionColor);
        }
    }

    public void returnColor()
    {
        for(int i=0; i<materials.Count; i++)
        {
            Color oldColor = new Color(defaultColors[i].r, defaultColors[i].g, defaultColors[i].b);

            materials[i].color = oldColor;
            
            Color oldEmissionColor = new Color(defaultEmissionColors[i].r, defaultEmissionColors[i].g, defaultEmissionColors[i].b);

            materials[i].SetColor("_EmissionColor", oldEmissionColor);
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
