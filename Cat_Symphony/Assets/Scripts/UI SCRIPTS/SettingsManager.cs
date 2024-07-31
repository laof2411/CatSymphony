using System;
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

    [SerializeField] public SettingsData settings;

    public void Awake()
    {

        settings = GameManager.Instance.settings;
        if (settings.bongoSoundsActive)
        {

            bongoSoundsCheckMark.SetActive(true);

        }
        else
        {

            bongoSoundsCheckMark.SetActive(false);

        }

    }

    public void TurnOnOffBongoSounds()
    {
        if (bongoSoundsActive)
        {
            bongoSoundsActive = false;

            bongoSoundsCheckMark.SetActive(false);
            settings.bongoSoundsActive = false;

        }
        else if (!bongoSoundsActive)
        {
            bongoSoundsActive = true;

            bongoSoundsCheckMark.SetActive(true);
            settings.bongoSoundsActive = true;


        }
        GameManager.Instance.settings = settings;

    }

    public void ChangeVolumeMusic()
    {

        volumeMusic = _sliderMusic.value;
        settings.musicVolume = volumeMusic;

        GameManager.Instance.settings = settings;
    }

    public void ChangeVolumeEffects()
    {

        volumeEffect = _sliderEffect.value;
        settings.effectsVolume = volumeEffect;


        GameManager.Instance.settings = settings;
    }


}

[Serializable]
public struct SettingsData
{

    public float musicVolume;
    public float effectsVolume;

    public bool bongoSoundsActive;

}