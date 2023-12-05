using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public void playSfxWalk()
    {
        Singleton.instance.playSFX(Singleton.instance.sfxEnemyWalk, transform.position);
    }
}
