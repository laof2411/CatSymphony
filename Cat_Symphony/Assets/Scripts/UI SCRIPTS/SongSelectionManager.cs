using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField] private GameObject box;
    [SerializeField] private float boxHeight1;
    [SerializeField] private float boxHeight2;
    [SerializeField] private float boxHeightHalf;

    [SerializeField] private GameObject topSide;
    [SerializeField] private Vector3 topSideCoordinates;

    [SerializeField] public Vector3[] newPosition = new Vector3[3];

    [SerializeField] private GameObject[] locationsSelection1 = new GameObject[3];
    [SerializeField] private GameObject[] locationsSelection2 = new GameObject[3];
    [SerializeField] private GameObject[] locationsSelection3 = new GameObject[3];

    private void Start()
    {
        originalPosition[0] = songSelection1[0].transform.position;
        originalPosition[1] = songSelection2[0].transform.position;
        originalPosition[2] = songSelection3[0].transform.position;

        ResetSeletionToDefault();
        MenuTitle.SetActive(true);

        selectedSong = 0;

        boxHeight1 = box.GetComponent<RectTransform>().transform.position.y;
        boxHeight2 = box.GetComponent<RectTransform>().rect.size.y;
        boxHeightHalf = boxHeight1 / 2;


        topSideCoordinates = topSide.transform.localPosition;

    }
    public float newLocation1;
    public float newLocation2;
    public float newLocation3;

    public void Selection1Selected()
    {
        ResetSeletionToDefault();
        songSelection1[0].transform.localScale = newSize;

        //newLocation1 = PercentageOgPosition1(85);
        //newLocation2 = PercentageOgPosition1(38);
        //newLocation3 = PercentageOgPosition1(17);

        Debug.Log(newLocation1);
        Debug.Log(newLocation2);
        //Debug.Log(newLocation3);

        songSelection1[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection1[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection1[0].GetComponent<RectTransform>().anchoredPosition.y);
        songSelection2[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection2[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection1[1].GetComponent<RectTransform>().anchoredPosition.y);
        songSelection3[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection3[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection1[2].GetComponent<RectTransform>().anchoredPosition.y);
        //songSelection1[0].GetComponent<RectTransform>().position = new Vector3(songSelection1[0].transform.position.x, PercentageOgPosition1(134, 0), songSelection1[0].transform.position.z);
        //songSelection1[0].GetComponent<RectTransform>().position = new Vector3(songSelection1[0].transform.position.x, PercentageOgPosition1(134, 0), songSelection1[0].transform.position.z);
        //songSelection2[0].GetComponent<RectTransform>().position = new Vector3(songSelection2[0].transform.position.x, PercentageOgPosition1(91, 1), songSelection2[0].transform.position.z);
        //songSelection3[0].GetComponent<RectTransform>().position = new Vector3(songSelection3[0].transform.position.x, PercentageOgPosition1(81, 2), songSelection3[0].transform.position.z);


        songSelection1[1].GetComponent<Image>().color = Color.white;
        songSelection1[2].SetActive(true);

        selectedSong = 1;

        newPosition[0] = songSelection1[0].transform.position;
        newPosition[1] = songSelection2[0].transform.position;
        newPosition[2] = songSelection3[0].transform.position;
    }

    private float PercentageOgPosition1(int percentage, int whichSelection)
    {
        return  (percentage * originalPosition[whichSelection].y) / 100;
    }


    public void Selection2Selected()
    {
        ResetSeletionToDefault();
        songSelection2[0].transform.localScale = newSize;

        songSelection1[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection1[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection2[0].GetComponent<RectTransform>().anchoredPosition.y);
        songSelection2[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection2[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection2[1].GetComponent<RectTransform>().anchoredPosition.y);
        songSelection3[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection3[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection2[2].GetComponent<RectTransform>().anchoredPosition.y);
        //songSelection1[0].GetComponent<RectTransform>().position = new Vector3(songSelection1[0].transform.position.x, PercentageOgPosition1(133, 0), songSelection1[0].transform.position.z);
        //songSelection2[0].GetComponent<RectTransform>().position = new Vector3(songSelection3[0].transform.position.x, PercentageOgPosition1(146, 1), songSelection3[0].transform.position.z);
        //songSelection3[0].GetComponent<RectTransform>().position = new Vector3(songSelection3[0].transform.position.x, PercentageOgPosition1(75, 2), songSelection3[0].transform.position.z);

        songSelection2[1].GetComponent<Image>().color = Color.white;
        songSelection2[2].SetActive(true);

        selectedSong = 2;

        newPosition[0] = songSelection1[0].transform.position;
        newPosition[1] = songSelection2[0].transform.position;
        newPosition[2] = songSelection3[0].transform.position;
    }

    public void Selection3Selected()
    {
        ResetSeletionToDefault();
        songSelection3[0].transform.localScale = newSize;

        songSelection1[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection1[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection3[0].GetComponent<RectTransform>().anchoredPosition.y);
        songSelection2[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection2[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection3[1].GetComponent<RectTransform>().anchoredPosition.y);
        songSelection3[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(songSelection3[0].GetComponent<RectTransform>().anchoredPosition.x, locationsSelection3[2].GetComponent<RectTransform>().anchoredPosition.y);
        //songSelection1[0].GetComponent<RectTransform>().position = new Vector3(songSelection1[0].transform.position.x, PercentageOgPosition1(133, 0), songSelection1[0].transform.position.z);
        //songSelection2[0].GetComponent<RectTransform>().position = new Vector3(songSelection2[0].transform.position.x, PercentageOgPosition1(149, 1), songSelection2[0].transform.position.z);
        //songSelection3[0].GetComponent<RectTransform>().position = new Vector3(songSelection3[0].transform.position.x, PercentageOgPosition1(195, 2), songSelection3[0].transform.position.z);

        songSelection3[1].GetComponent<Image>().color = Color.white;
        songSelection3[2].SetActive(true);

        selectedSong = 3;

        newPosition[0] = songSelection1[0].transform.position;
        newPosition[1] = songSelection2[0].transform.position;
        newPosition[2] = songSelection3[0].transform.position;
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
