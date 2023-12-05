using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnim : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void playSfxWhoosh()
    {
        Singleton.instance.playSFX(Singleton.instance.sfxTransition, transform.position, false);
    }
}
