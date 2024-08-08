using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSong : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        FindAnyObjectByType<SettingsManager>().GaineMenuMusic(this.gameObject);
    }
}
