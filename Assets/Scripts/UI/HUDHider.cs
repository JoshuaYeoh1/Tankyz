using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDHider : MonoBehaviour
{
    public InOutAnim hudItem;
    public float checkedValue, valueMin, valueMax=99999, animTime=.5f;

    bool canShow=true, canHide;

    void Update()
    {
        if(hudItem)
        {
            if(checkedValue>valueMin && checkedValue<valueMax && canShow)
            {
                toggleShow();

                hudItem.animIn(animTime);

                Invoke("toggleHide", animTime);
            }
            else if((checkedValue<=valueMin || checkedValue>=valueMax) && canHide)
            {
                toggleHide();

                hudItem.animOut(animTime);

                Invoke("toggleShow", animTime);
            }
        }
    }

    void toggleHide()
    {
        canHide=!canHide;
    }
    void toggleShow()
    {
        canShow=!canShow;
    }
}
