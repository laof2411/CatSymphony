using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{

    // 0 - blue 1 - green 2 - yellow 3 - red
    [SerializeField] Animator[] bongosAnimators;
    [SerializeField] ParticleSystem[] particleSystems;
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

    public void StartParticles(int trailNumber)
    {

        switch (trailNumber)
        {

            case 1:
                {

                    particleSystems[trailNumber - 1].Play();

                    break;
                }
            case 2:
                {

                    particleSystems[trailNumber - 1].Play();

                    break;
                }
            case 3:
                {

                    particleSystems[trailNumber - 1].Play();

                    break;
                }
            case 4:
                {

                    particleSystems[trailNumber - 1].Play();

                    break;
                }

        }
        
    }

}
