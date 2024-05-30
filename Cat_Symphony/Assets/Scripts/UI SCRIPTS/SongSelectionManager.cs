using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectionManager : MonoBehaviour
{
    [SerializeField] private GameObject[] songSelection1 = new GameObject[4];
    [SerializeField] private GameObject[] songSelection2 = new GameObject[4];
    [SerializeField] private GameObject[] songSelection3 = new GameObject[4];
    [SerializeField] private GameObject MenuTitle;

    [SerializeField] private int selectedSong;

    [Header ("Changes when selected")]
    [SerializeField] public Vector3 newSize;
    [SerializeField] public Vector3[] originalPosition = new Vector3[3];

    [Header("Changes when selected")]
    [SerializeField] public int[] starsInSong1 = new int[3];
    [SerializeField] public int[] starsInSong2 = new int[3];
    [SerializeField] public int[] starsInSong3 = new int[3];

    private void Start()
    {
        originalPosition[0] = songSelection1[0].transform.position;
        originalPosition[1] = songSelection2[0].transform.position;
        originalPosition[2] = songSelection3[0].transform.position;

        ResetSeletionToDefault();
        MenuTitle.SetActive(true);

        selectedSong = 0;
    }

    public void Selection1Selected()
    {
        ResetSeletionToDefault();
        songSelection1[0].transform.localScale = newSize;
        songSelection1[0].transform.position = new Vector3(songSelection1[0].transform.position.x, songSelection1[0].transform.position.y + 275, songSelection1[0].transform.position.z);
        songSelection2[0].transform.position = new Vector3(songSelection2[0].transform.position.x, songSelection2[0].transform.position.y - 50, songSelection2[0].transform.position.z);
        songSelection3[0].transform.position = new Vector3(songSelection3[0].transform.position.x, songSelection3[0].transform.position.y - 50, songSelection3[0].transform.position.z);

        songSelection1[1].GetComponent<Image>().color = Color.white;
        songSelection1[2].SetActive(true);

        selectedSong = 1;
    }

    public void Selection2Selected()
    {
        ResetSeletionToDefault();
        songSelection2[0].transform.localScale = newSize;
        songSelection1[0].transform.position = new Vector3(songSelection1[0].transform.position.x, songSelection1[0].transform.position.y + 268, songSelection1[0].transform.position.z);
        songSelection2[0].transform.position = new Vector3(songSelection3[0].transform.position.x, songSelection3[0].transform.position.y + 528, songSelection3[0].transform.position.z);
        songSelection3[0].transform.position = new Vector3(songSelection3[0].transform.position.x, songSelection3[0].transform.position.y - 67, songSelection3[0].transform.position.z);

        songSelection2[1].GetComponent<Image>().color = Color.white;
        songSelection2[2].SetActive(true);

        selectedSong = 2;
    }

    public void Selection3Selected()
    {
        ResetSeletionToDefault();
        songSelection3[0].transform.localScale = newSize;
        songSelection1[0].transform.position = new Vector3(songSelection1[0].transform.position.x, songSelection1[0].transform.position.y + 265, songSelection1[0].transform.position.z);
        songSelection2[0].transform.position = new Vector3(songSelection2[0].transform.position.x, songSelection2[0].transform.position.y + 265, songSelection2[0].transform.position.z);
        songSelection3[0].transform.position = new Vector3(songSelection3[0].transform.position.x, songSelection3[0].transform.position.y + 250, songSelection3[0].transform.position.z);

        songSelection3[1].GetComponent<Image>().color = Color.white;
        songSelection3[2].SetActive(true);

        selectedSong = 3;
    }

    public void PlaySelectedSong()
    {
        switch (selectedSong)
        {
            case 0:
                {
                    Debug.Log("No song is being selected");
                    break;
                }
            case 1:
                {
                    Debug.Log("Song " + selectedSong + " selected");
                    break;
                }
            case 2:
                {
                    Debug.Log("Song " + selectedSong + " selected");
                    break;
                }
            case 3:
                {
                    Debug.Log("Song " + selectedSong + " selected");
                    break;
                }
            default:
                {
                    Debug.Log("ERROR: Selected song is not available");
                    break;
                }
        }
    }

    public void ResetSeletionToDefault()
    {
        MenuTitle.SetActive(false);

        songSelection1[2].SetActive(false);
        songSelection2[2].SetActive(false);
        songSelection3[2].SetActive(false);

        songSelection1[1].GetComponent<Image>().color = Color.gray;
        songSelection2[1].GetComponent<Image>().color = Color.gray;
        songSelection3[1].GetComponent<Image>().color = Color.gray;
        //songSelection1[1].GetComponent<Image>().color = new Color(0.703f, 0.13f, 0.74f, 1.0f);

        songSelection1[0].transform.position = originalPosition[0];
        songSelection2[0].transform.position = originalPosition[1];
        songSelection3[0].transform.position = originalPosition[2];

        Vector3 normalVector3 = new Vector3(1, 1, 1);

        songSelection1[0].transform.localScale = normalVector3;
        songSelection2[0].transform.localScale = normalVector3;
        songSelection3[0].transform.localScale = normalVector3;

        songSelection1[2].SetActive(false);
        songSelection2[2].SetActive(false);
        songSelection3[2].SetActive(false);
    }
}
