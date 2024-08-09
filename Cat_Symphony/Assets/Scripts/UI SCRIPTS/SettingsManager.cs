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

    [SerializeField] private GameObject menuSong;

    private void Start()
    {
        _sliderMusic.value = GameManager.Instance.settings.musicVolume;
        _sliderEffect.value = GameManager.Instance.settings.effectsVolume;
        TurnOnOffBongoSounds();
    }

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

            SoundManager.Instance.PlaySound("8");
        }
        else if (!GameManager.Instance.settings.bongoSoundsActive)
        {
            GameManager.Instance.settings.bongoSoundsActive = true;

            bongoSoundsCheckMark.SetActive(true);

            SoundManager.Instance.PlaySound("8");
        }

        if (audioManager != null)
        {

            audioManager.UpdateAudioSettings();


        }

    }

    public void GaineMenuMusic(GameObject a)
    {
        menuSong = a;
    }

    public void ChangeVolumeMusic()
    {

        GameManager.Instance.settings.musicVolume = _sliderMusic.value;

        SoundManager.Instance.PlaySound("8");

        if (audioManager != null)
        {
            audioManager.UpdateAudioSettings();
        }

        if (menuSong != null)
        {

            menuSong.GetComponent<AudioSource>().volume = 1 * (GameManager.Instance.settings.musicVolume / 100);
        }
    }

    public void ChangeVolumeEffects()
    {
        GameManager.Instance.settings.effectsVolume = _sliderEffect.value;


        SoundManager.Instance.PlaySound("8");

        if (audioManager != null)
        {

          audioManager.UpdateAudioSettings();


        }

        SoundManager.Instance.ModifyMusic();
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