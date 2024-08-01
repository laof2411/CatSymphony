using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{

    // 0 - blue 1 - green 2 - yellow 3 - red
    [SerializeField] Animator[] bongosAnimators;
    [SerializeField] Animator catAnimator;

    public void TapBongo(int trailNumber)
    {

        bongosAnimators[trailNumber - 1].Play("Tap");
        
        switch (trailNumber)
        {

            case 1:
                {

                    catAnimator.Play("Bong Blue");
                    break;
                }
            case 2:
                {

                    catAnimator.Play("Bong Green");
                    break;
                }
            case 3:
                {

                    catAnimator.Play("Bong Yellow");
                    break;
                }
            case 4:
                {

                    catAnimator.Play("Bong Red");
                    break;
                }

        }

    }

}
