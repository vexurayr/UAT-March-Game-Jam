using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource EnemyHit1;

    void OnTrigger ()
    {
        EnemyHit1.Play();
    }

}
