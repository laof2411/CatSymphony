using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] private GameObject bongoSoundsCheckMark;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderEffect;

    [SerializeField] private GameObject pauseObject;
    [SerializeField] private GameObject settingsObject;
    [SerializeField] private AudioManager audioManager;


    public void GetSettingsValues()
    {


        if (GameManager.Instance.settings.bongoSoundsActive)
        {

            bongoSoundsCheckMark.SetActive(true);

        }
        else
        {

            bongoSoundsCheckMark.SetActive(false);

        }

        _sliderMusic.value = GameManager.Instance.settings.musicVolume;

        _sliderEffect.value = GameManager.Instance.settings.effectsVolume;

    }

    public void TurnOnOffBongoSounds()
    {
        if (GameManager.Instance.settings.bongoSoundsActive)
        {
            GameManager.Instance.settings.bongoSoundsActive = false;

            bongoSoundsCheckMark.SetActive(false);

            SoundManager.Instance.LaunchMusic("8");
        }
        else if (!GameManager.Instance.settings.bongoSoundsActive)
        {
            GameManager.Instance.settings.bongoSoundsActive = true;

            bongoSoundsCheckMark.SetActive(true);

            SoundManager.Instance.LaunchMusic("8");
        }

        if (audioManager != null)
        {

            audioManager.UpdateAudioSettings();


        }

    }

    public void ChangeVolumeMusic()
    {

        GameManager.Instance.settings.musicVolume = _sliderMusic.value;

        SoundManager.Instance.LaunchMusic("8");

        if (audioManager != null)
        {

            audioManager.UpdateAudioSettings();


        }
    }

    public void ChangeVolumeEffects()
    {
        GameManager.Instance.settings.effectsVolume = _sliderEffect.value;


        SoundManager.Instance.LaunchMusic("8");

        if (audioManager != null)
        {

          audioManager.UpdateAudioSettings();


        }

        //SoundManager.Instance.ModifyMusic();
    }

    public void ReturnToPauseMenu()
    {

        pauseObject.SetActive(true);
        settingsObject.SetActive(false);

    }


}

[Serializable]
public struct SettingsData
{

    public float musicVolume;
    public float effectsVolume;

    public bool bongoSoundsActive;

}