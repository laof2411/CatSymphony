using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripStoreManager : MonoBehaviour
{
    [SerializeField] private int currentMoney;


    [SerializeField] private int currentItemCost;

    // orden cat [0], clothes [1], accesories [2], bongos [3]
    [SerializeField] private Sprite[] catSprites = new Sprite[10];
    [SerializeField] private Sprite[] clothesSprites = new Sprite[5];
    [SerializeField] private Sprite[] accesoriesSprites = new Sprite[5];
    [SerializeField] private Sprite[] bongosSprites = new Sprite[10];

    [SerializeField] private GameObject[] modifiableObjSprites = new GameObject[4];
    
    [SerializeField] private int currentSelection;
    [SerializeField] private GameObject[] lightframesAdOns = new GameObject[4];



    void Start()
    {
        ShutdownLightFrame();
    }

    // Update is called once per frame
    void Update()
    {

    }


    #region changeSelection
    public void ChangeSelectionCat()
    {
        currentSelection = 0;
        ShutdownLightFrame();

        lightframesAdOns[0].SetActive(true);
    }

    public void ChangeSelectionClothes()
    {
        currentSelection = 1;
        ShutdownLightFrame();

        lightframesAdOns[1].SetActive(true);
    }

    public void ChangeSelectionAccesories()
    {
        currentSelection = 2;
        ShutdownLightFrame();

        lightframesAdOns[2].SetActive(true);
    }

    public void ChangeSelectionBongo()
    {
        currentSelection = 3;
        ShutdownLightFrame();

        lightframesAdOns[3].SetActive(true);
    }

    public void ShutdownLightFrame()
    {
        lightframesAdOns[0].SetActive(true);
        lightframesAdOns[1].SetActive(true);
        lightframesAdOns[2].SetActive(true);
        lightframesAdOns[3].SetActive(true);
    }
    #endregion

}
