using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DripStoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textShowCurrentMoney;
    [SerializeField] private int currentMoney;


    [SerializeField] private int currentItemCost;

    // orden cat [0], clothes [1], accesories [2], bongos [3]
    [SerializeField] public StoreItem[] catStoreItem = new StoreItem[5];

    //[SerializeField] private Sprite[] catCurrentID = new Sprite[10];
    [SerializeField] public StoreItem[] clothesStoreItem = new StoreItem[5];

    [SerializeField] public StoreItem[] accessoriesStoreItem = new StoreItem[5];

    [SerializeField] public StoreItem[] bongosStoreItem = new StoreItem[5];
    

    [SerializeField] private int currentListSelection;

    [SerializeField] private int selectionListCat = 0;
    [SerializeField] private int selectionListClothes = 0;
    [SerializeField] private int selectionListAccesories = 0;
    [SerializeField] private int selectionListBongo = 0;

    [SerializeField] private GameObject[] modifiableObjSprites = new GameObject[4];
    [SerializeField] private GameObject[] lightframesAdOns = new GameObject[4];


    [SerializeField] private TextMeshProUGUI itemNamePlaceholder;

    [SerializeField] private int currentLookCombination;

    [SerializeField] private bool movementRight = true;

    void Start()
    {
        textShowCurrentMoney.text = "" + currentMoney;
        ShutdownLightFrame();
    }

    #region forwardOrbackWardOnList

    public void MoveListForward()
    {
        movementRight = true;

        MoveInList();
    }

    public void MoveListBackward()
    {
        movementRight = false;

        MoveInList();
    }

    public void MoveInList()
    {
        switch (currentListSelection)
        {
            case 0:
                {
                    if (movementRight)
                    {
                        if (selectionListCat == catStoreItem.Length - 1)
                        {
                            selectionListCat = 0;
                        }
                        else if (selectionListCat < 0)
                        {
                            selectionListCat = 0;
                        }
                        else
                        {
                            selectionListCat++;
                        }
                    }
                    else if (!movementRight)
                    {
                        if (selectionListCat == 0)
                        {
                            selectionListCat = catStoreItem.Length - 1;
                        }
                        else if (selectionListCat > catStoreItem.Length - 1)
                        {
                            selectionListCat = catStoreItem.Length - 1;
                        }
                        else
                        {
                            selectionListCat--;
                        }
                    }

                    UpdateItemName(catStoreItem[selectionListCat].itemName);
                    UpdateSelectionList(catStoreItem[selectionListCat].itemSprite);
                    break;
                }
            case 1:
                {
                    if (movementRight)
                    {
                        if (selectionListClothes == clothesStoreItem.Length - 1)
                        {
                            selectionListClothes = 0;
                        }
                        else if (selectionListClothes < 0)
                        {
                            selectionListClothes = 0;
                        }
                        else
                        {
                            selectionListClothes++;
                        }
                    }
                    else if (!movementRight)
                    {
                        if (selectionListClothes == 0)
                        {
                            selectionListClothes = clothesStoreItem.Length - 1;
                        }
                        else if (selectionListClothes > clothesStoreItem.Length - 1)
                        {
                            selectionListClothes = clothesStoreItem.Length - 1;
                        }
                        else
                        {
                            selectionListClothes--;
                        }
                    }

                    UpdateItemName(clothesStoreItem[selectionListClothes].itemName);
                    UpdateSelectionList(clothesStoreItem[selectionListClothes].itemSprite);
                    break;
                }
            case 2:
                {
                    if (movementRight)
                    {
                        if (selectionListAccesories == accessoriesStoreItem.Length - 1)
                        {
                            selectionListAccesories = 0;
                        }
                        else if (selectionListAccesories < 0)
                        {
                            selectionListAccesories = 0;
                        }
                        else
                        {
                            selectionListAccesories++;
                        }
                    }
                    else if (!movementRight)
                    {
                        if (selectionListAccesories == 0)
                        {
                            selectionListAccesories = accessoriesStoreItem.Length - 1;
                        }
                        else if (selectionListAccesories > accessoriesStoreItem.Length - 1)
                        {
                            selectionListAccesories = accessoriesStoreItem.Length - 1;
                        }
                        else
                        {
                            selectionListAccesories--;
                        }
                    }

                    UpdateItemName(accessoriesStoreItem[selectionListAccesories].itemName);
                    UpdateSelectionList(accessoriesStoreItem[selectionListAccesories].itemSprite);
                    break;
                }
            case 3:
                {
                    if (movementRight)
                    {
                        if (selectionListBongo == bongosStoreItem.Length - 1)
                        {
                            selectionListBongo = 0;
                        }
                        else if (selectionListBongo < 0)
                        {
                            selectionListBongo = 0;
                        }
                        else
                        {
                            selectionListBongo++;
                        }
                    }
                    else if (!movementRight)
                    {
                        if (selectionListBongo == 0)
                        {
                            selectionListBongo = bongosStoreItem.Length - 1;
                        }
                        else if (selectionListBongo > bongosStoreItem.Length - 1)
                        {
                            selectionListBongo = bongosStoreItem.Length - 1;
                        }
                        else
                        {
                            selectionListBongo--;
                        }
                    }

                    UpdateItemName(bongosStoreItem[selectionListBongo].itemName);
                    UpdateSelectionList(bongosStoreItem[selectionListBongo].itemSprite);
                    break;
                }
            default:
                {
                    Debug.LogError("GAME ERROR: 'currentListSelection' does not contain a valid selection!");
                    break;
                }
        }
    }
    #endregion


    private void UpdateSelectionList(Sprite newSprite)
    {
        modifiableObjSprites[currentListSelection].GetComponent<Image>().sprite = newSprite;
    }

    private void UpdateItemName(string newName)
    {
        itemNamePlaceholder.text = newName;
    }


    #region changeListSelection
    public void ChangeSelectionCat()
    {
        currentListSelection = 0;
        ShutdownLightFrame();

        UpdateItemName(catStoreItem[selectionListCat].name);

        lightframesAdOns[0].SetActive(true);
    }

    public void ChangeSelectionClothes()
    {
        currentListSelection = 1;
        ShutdownLightFrame();


        UpdateItemName(clothesStoreItem[selectionListClothes].name);

        lightframesAdOns[1].SetActive(true);
    }

    public void ChangeSelectionAccesories()
    {
        currentListSelection = 2;
        ShutdownLightFrame();


        UpdateItemName(accessoriesStoreItem[selectionListAccesories].name);

        lightframesAdOns[2].SetActive(true);
    }

    public void ChangeSelectionBongo()
    {
        currentListSelection = 3;
        ShutdownLightFrame();

        UpdateItemName(bongosStoreItem[selectionListBongo].name);

        lightframesAdOns[3].SetActive(true);
    }


    public void ShutdownLightFrame()
    {
        lightframesAdOns[0].SetActive(false);
        lightframesAdOns[1].SetActive(false);
        lightframesAdOns[2].SetActive(false);
        lightframesAdOns[3].SetActive(false);
    }
    #endregion

}
