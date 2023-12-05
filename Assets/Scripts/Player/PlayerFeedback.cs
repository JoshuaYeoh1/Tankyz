using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedback : MonoBehaviour
{
    public InOutAnim redScreen;
    public InOutAnim diedText;

    public void hurtAnim()
    {
        if(hurtRt!=null) StopCoroutine(hurtRt);
        hurtRt=StartCoroutine(hurtAniming());
    }

    Coroutine hurtRt, dieRt;
    IEnumerator hurtAniming()
    {
        redScreen.gameObject.SetActive(true);
        redScreen.animIn(.1f);
        yield return new WaitForSeconds(.1f);
        redScreen.animOut(.5f);
        yield return new WaitForSeconds(.5f);
    }

    public void dieAnim()
    {
        if(dieRt!=null) StopCoroutine(dieRt);
        dieRt=StartCoroutine(dieAniming());
    }

    IEnumerator dieAniming()
    {
        redScreen.animIn(.1f);
        diedText.gameObject.SetActive(true);
        diedText.animIn(.5f);
        yield return new WaitForSeconds(2.5f);
        Singleton.instance.ReloadScene();
    }
}
