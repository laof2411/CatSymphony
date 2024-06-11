using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] private bool bongoSoundsActive = true;
    [SerializeField] private GameObject bongoSoundsCheckMark;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderEffect;

    [SerializeField] private float volumeMusic = 100;
    [SerializeField] private float volumeEffect = 100;

    public void TurnOnOffBongoSounds()
    {
        if (bongoSoundsActive)
        {
            bongoSoundsActive = false;

            bongoSoundsCheckMark.SetActive(false);
            Debug.Log("BongoSounds OFF");
        }
        else if (!bongoSoundsActive)
        {
            bongoSoundsActive = true;

            bongoSoundsCheckMark.SetActive(true);

            Debug.Log("BongoSounds ON");
        }
    }

    public void ChangeVolumeMusic()
    {
        volumeMusic = _sliderMusic.value;

        Debug.Log(volumeMusic);
    }

    public void ChangeVolumeEffects()
    {
        volumeEffect = _sliderEffect.value;

        Debug.Log(volumeEffect);
    }

}
