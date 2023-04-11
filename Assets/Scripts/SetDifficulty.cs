using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    
    public void SetHardMode(bool mode)
    {
        PlayerController.hardMode = mode;
        
    }
}
