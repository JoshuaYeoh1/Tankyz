using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
    public InOutAnim redScreen;
    public InOutAnim diedText;

    public IEnumerator hurtAnim()
    {
        redScreen.animIn(.1f);
        yield return new WaitForSeconds(.1f);
        redScreen.animOut(.5f);
        yield return new WaitForSeconds(.5f);
    }

    public IEnumerator dieAnim()
    {
        redScreen.animIn(.1f);
        diedText.gameObject.SetActive(true);
        diedText.animIn(.5f);
        yield return new WaitForSeconds(1);
        Singleton.instance.ReloadScene();
    }
}
