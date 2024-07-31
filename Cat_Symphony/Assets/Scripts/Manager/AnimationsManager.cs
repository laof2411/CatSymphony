using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{

    // 0 - blue 1 - green 2 - yellow 3 - red
    [SerializeField] Animator[] bongosAnimators;

    public void TapBongo(int trailNumber)
    {

        bongosAnimators[trailNumber - 1].Play("Tap");

    }

}
