using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookChanger : MonoBehaviour
{
    [SerializeField] public GameObject catAvatar;
    [SerializeField] public GameObject bongoAvatar1;
    [SerializeField] public GameObject bongoAvatar2;

    [SerializeField] public Material[] catStore3D = new Material[5];

    //[SerializeField] private Sprite[] catCurrentID = new Sprite[10];

    [SerializeField] public GameObject[] clothesStore3D = new GameObject[5];


    [SerializeField] public GameObject[] accessoriesStore3D = new GameObject[5];


    [SerializeField] public GameObject[] bongos3DA = new GameObject[5];
    [SerializeField] public GameObject[] bongos3DB = new GameObject[5];

    [SerializeField] public int[] looks = new int[4];



    private void Start()
    {
        looks = GameManager.Instance.currentCatLooks;

        Debug.Log("B. currentCatLooks: " + looks[0] + ", " + looks[1] + ", " + looks[2] + ", " + looks[3]);

        Update3DShownCat();
        Update3DShownClothes();
        Update3DShownAccesory();
        Update3DShownBongo();
    }

    private void Update3DShownCat()
    {
        catAvatar.GetComponent<SkinnedMeshRenderer>().material = catStore3D[looks[0]];
    }

    private void Update3DShownClothes()
    {
        clothesStore3D[0].SetActive(false);
        clothesStore3D[1].SetActive(false);
        clothesStore3D[2].SetActive(false);
        clothesStore3D[3].SetActive(false);
        clothesStore3D[4].SetActive(false);

        clothesStore3D[looks[1]].SetActive(true);
    }

    private void Update3DShownAccesory()
    {
        accessoriesStore3D[0].SetActive(false);
        accessoriesStore3D[1].SetActive(false);
        accessoriesStore3D[2].SetActive(false);
        accessoriesStore3D[3].SetActive(false);
        accessoriesStore3D[4].SetActive(false);

        accessoriesStore3D[looks[2]].SetActive(true);
    }

    private void Update3DShownBongo()
    {
        bongos3DA[0].SetActive(false);
        bongos3DA[1].SetActive(false);
        bongos3DA[2].SetActive(false);
        bongos3DA[3].SetActive(false);
        bongos3DA[4].SetActive(false);

        bongos3DA[looks[3]].SetActive(true);

        bongos3DB[0].SetActive(false);
        bongos3DB[1].SetActive(false);
        bongos3DB[2].SetActive(false);
        bongos3DB[3].SetActive(false);
        bongos3DB[4].SetActive(false);

        bongos3DB[looks[3]].SetActive(true);
    }

}
