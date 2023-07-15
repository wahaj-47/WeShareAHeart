using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoundAudioManager : BaseSoundEffectsManager
{
    [SerializeField] private string[] footstepSounds;

    private string GetRandomStepSound()
    {
        return footstepSounds[UnityEngine.Random.Range(0, footstepSounds.Length)];
    }

    private void Step()
    {
        Play(GetRandomStepSound());
    }

}
