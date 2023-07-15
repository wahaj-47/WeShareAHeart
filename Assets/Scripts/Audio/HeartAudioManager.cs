using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAudioManager : BaseSoundEffectsManager
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Play("Splat");
    }
}
