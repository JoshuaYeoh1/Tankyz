using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    PlayerMove move;

    void Awake()
    {
        anim=GetComponent<Animator>();
        move=transform.root.GetComponent<PlayerMove>();
    }

    void Update()
    {
        anim.SetFloat("moveDir", move.dir.z);
        anim.SetFloat("turnDir", move.dir.y);
    }
}   
