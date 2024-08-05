using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DripStoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textShowCurrentMoney;

    [SerializeField] private int currentItemCost;

    // orden cat [0], clothes [1], accesories [2], bongos [3]
    [SerializeField] public GameObject catAvatar;
    [SerializeField] public GameObject bongoAvatar;

    [SerializeField] public StoreItem[] catStoreItem = new StoreItem[5];
    [SerializeField] public Material[] catStore3D = new Material[5];


    //[SerializeField] private Sprite[] catCurrentID = new Sprite[10];
    [SerializeField] public StoreItem[] clothesStoreItem = new StoreItem[5];
    [SerializeField] public GameObject[] clothesStore3D = new GameObject[5];

    [SerializeField] public StoreItem[] accessoriesStoreItem = new StoreItem[5];
    [SerializeField] public GameObject[] accessoriesStore3D = new GameObject[5];

    [SerializeField] public StoreItem[] bongosStoreItem = new StoreItem[5];
    [SerializeField] public Material[] bongosStore3D = new Material[5];


    [SerializeField] private int currentListSelection;

    [SerializeField] public GameObject[] itemSelectedUI = new GameObject[4];

    [SerializeField] private int selectionListCat = 0;
    [SerializeField] private int selectionListClothes = 0;
    [SerializeField] private int selectionListAccesories = 0;
    [SerializeField] private int selectionListBongo = 0;

    [SerializeField] private GameObject[] modifiableObjSprites = new GameObject[4];
    [SerializeField] private GameObject[] lightframesAdOns = new GameObject[4];
    [SerializeField] private GameObject[] locks = new GameObject[4];


    [SerializeField] private TextMeshProUGUI itemNamePlaceholder;
    [SerializeField] private TextMeshProUGUI itemPricePlaceholder;

    [SerializeField] private int currentLookCombination;

    [SerializeField] private bool movementRight = true;

    [SerializeField] private GameObject buyButton;
    [SerializeField] private TextMeshProUGUI buyButtonFont;

    void Start()
    {
        buyButtonFont = buyButton.GetComponentInChildren<TextMeshProUGUI>();

        UpdateCurrentMoney();
        ShutdownLightFrame();

        currentListSelection = 0;
        CleanUp();

        selectionListCat = GameManager.Instance.currentCatLooks[0];
        selectionListClothes = GameManager.Instance.currentCatLooks[1];
        selectionListAccesories = GameManager.Instance.currentCatLooks[2];
        selectionListBongo = GameManager.Instance.currentCatLooks[3];

        Update3DShownCat();
        Update3DShownClothes();
        Update3DShownAccesory();
        Update3DShownBongo();

        ChangeSelectionCat();
    }

    private void UpdateCurrentMoney()
    {
        textShowCurrentMoney.text = "" + GameManager.Instance.nekoins;
    }


    private void CleanUp()
    {
        for (int i = 0; i < lightframesAdOns.Length; i++)
        {
            lightframesAdOns[i].SetActive(false);
            locks[i].SetActive(false);
        }
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

                    UpdateItemPrice(catStoreItem[selectionListCat].itemCost, catStoreItem[selectionListCat].unlocked);
                    LockedOrUnlocked(catStoreItem[selectionListCat].unlocked);
                    UpdateItemName(catStoreItem[selectionListCat].itemName);
                    UpdateSelectionList(catStoreItem[selectionListCat].itemSprite);
                    Update3DShownCat();
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


                    UpdateItemPrice(clothesStoreItem[selectionListClothes].itemCost, clothesStoreItem[selectionListClothes].unlocked);
                    LockedOrUnlocked(clothesStoreItem[selectionListClothes].unlocked);
                    UpdateItemName(clothesStoreItem[selectionListClothes].itemName);
                    UpdateSelectionList(clothesStoreItem[selectionListClothes].itemSprite);
                    Update3DShownClothes();
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


                    UpdateItemPrice(accessoriesStoreItem[selectionListAccesories].itemCost, accessoriesStoreItem[selectionListAccesories].unlocked);
                    LockedOrUnlocked(accessoriesStoreItem[selectionListAccesories].unlocked);
                    UpdateItemName(accessoriesStoreItem[selectionListAccesories].itemName);
                    UpdateSelectionList(accessoriesStoreItem[selectionListAccesories].itemSprite);
                    Update3DShownAccesory();
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

                    UpdateItemPrice(bongosStoreItem[selectionListBongo].itemCost, bongosStoreItem[selectionListBongo].unlocked);
                    LockedOrUnlocked(bongosStoreItem[selectionListBongo].unlocked);
                    UpdateItemName(bongosStoreItem[selectionListBongo].itemName);
                    UpdateSelectionList(bongosStoreItem[selectionListBongo].itemSprite);
                    Update3DShownBongo();
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


    private void Update3DShownCat()
    {
        catAvatar.GetComponent<SkinnedMeshRenderer>().material = catStore3D[selectionListCat];
    }

    private void Update3DShownClothes()
    {
        clothesStore3D[0].SetActive(false);
        clothesStore3D[1].SetActive(false);
        clothesStore3D[2].SetActive(false);
        clothesStore3D[3].SetActive(false);
        clothesStore3D[4].SetActive(false);

        clothesStore3D[selectionListClothes].SetActive(true);
    }

    private void Update3DShownAccesory()
    {
        accessoriesStore3D[0].SetActive(false);
        accessoriesStore3D[1].SetActive(false);
        accessoriesStore3D[2].SetActive(false);
        accessoriesStore3D[3].SetActive(false);
        accessoriesStore3D[4].SetActive(false);

        accessoriesStore3D[selectionListAccesories].SetActive(true);
    }

    private void Update3DShownBongo()
    {
        bongoAvatar.GetComponent<MeshRenderer>().material = bongosStore3D[selectionListBongo];
        bongoAvatar.GetComponent<MeshRenderer>().materials[0] = bongosStore3D[selectionListBongo];
        bongoAvatar.GetComponent<MeshRenderer>().materials[1] = bongosStore3D[selectionListBongo];
    }

    private void UpdateSelectionList(Sprite newSprite)
    {
        modifiableObjSprites[currentListSelection].GetComponent<Image>().sprite = newSprite;
    }

    private void LockedOrUnlocked(bool unlocked)
    {
        if (unlocked)
        {
            locks[currentListSelection].SetActive(false);
            buyButton.GetComponent<Image>().color = Color.grey;

            buyButtonFont.text = "Equip";
            buyButtonFont.color = Color.white;
        }
        else if (!unlocked)
        {
            locks[currentListSelection].SetActive(true);
            buyButton.GetComponent<Image>().color = Color.white;

            buyButtonFont.text = "Buy";
            buyButtonFont.color = Color.magenta;
        }
        Debug.Log(unlocked);
    }

    private void UpdateItemName(string newName)
    {
        itemNamePlaceholder.text = newName;
    }

    private void UpdateItemPrice(int newPrice, bool unlocked)
    {
        if (unlocked)
        {
            itemPricePlaceholder.text = "$ --";
        }
        else if (!unlocked)
        {
            itemPricePlaceholder.text = "$ " + newPrice;
        }
    }

    private void UpdateItemPriceToNull()
    {

    }

    public void TryToBuy()
    {
        switch (currentListSelection)
        {
            case 0:
                {
                    if (catStoreItem[selectionListCat].unlocked == false)
                    {
                        if (GameManager.Instance.nekoins >= catStoreItem[selectionListCat].itemCost)
                        {
                            GameManager.Instance.nekoins -= catStoreItem[selectionListCat].itemCost;

                            catStoreItem[selectionListCat].unlocked = true;
                            LockedOrUnlocked(catStoreItem[selectionListCat].unlocked);
                            UpdateItemPrice(catStoreItem[selectionListCat].itemCost, catStoreItem[selectionListCat].unlocked);
                        }
                        else
                        {
                            Debug.Log("You dont have enough money");
                        }
                    }
                    else
                    {
                        Debug.Log("Item already adquired");
                    }

                    break;
                }
            case 1:
                {
                    if (clothesStoreItem[selectionListClothes].unlocked == false)
                    {
                        if (GameManager.Instance.nekoins >= clothesStoreItem[selectionListClothes].itemCost)
                        {
                            GameManager.Instance.nekoins -= clothesStoreItem[selectionListClothes].itemCost;

                            clothesStoreItem[selectionListClothes].unlocked = true;
                            LockedOrUnlocked(clothesStoreItem[selectionListClothes].unlocked);
                            UpdateItemPrice(clothesStoreItem[selectionListClothes].itemCost, clothesStoreItem[selectionListClothes].unlocked);
                        }
                        else
                        {
                            Debug.Log("You dont have enough money");
                        }
                    }
                    else
                    {
                        Debug.Log("Item already adquired");
                    }


                    break;
                }
            case 2:
                {
                    if (accessoriesStoreItem[selectionListAccesories].unlocked == false)
                    {
                        if (GameManager.Instance.nekoins >= accessoriesStoreItem[selectionListAccesories].itemCost)
                        {
                            GameManager.Instance.nekoins -= accessoriesStoreItem[selectionListAccesories].itemCost;

                            accessoriesStoreItem[selectionListAccesories].unlocked = true;
                            LockedOrUnlocked(accessoriesStoreItem[selectionListAccesories].unlocked);
                            UpdateItemPrice(accessoriesStoreItem[selectionListAccesories].itemCost, accessoriesStoreItem[selectionListAccesories].unlocked);
                        }
                        else
                        {
                            Debug.Log("You dont have enough money");
                        }
                    }
                    else
                    {
                        Debug.Log("Item already adquired");
                    }

                    break;
                }
            case 3:
                {
                    if (bongosStoreItem[selectionListBongo].unlocked == false)
                    {
                        if (GameManager.Instance.nekoins >= bongosStoreItem[selectionListBongo].itemCost)
                        {
                            GameManager.Instance.nekoins -= bongosStoreItem[selectionListBongo].itemCost;
                            bongosStoreItem[selectionListBongo].unlocked = true;
                            LockedOrUnlocked(bongosStoreItem[selectionListBongo].unlocked);
                            UpdateItemPrice(bongosStoreItem[selectionListBongo].itemCost, bongosStoreItem[selectionListBongo].unlocked);
                        }
                        else
                        {
                            Debug.Log("You dont have enough money");
                        }
                    }
                    else
                    {
                        Debug.Log("Item already adquired");
                    }

                    break;
                }
            default:
                {
                    Debug.LogError("GAME ERROR: 'currentListSelection' does not contain a valid selection!");
                    break;
                }
        }
        UpdateCurrentMoney();
    }

    #region changeListSelection
    public void ChangeSelectionCat()
    {
        currentListSelection = 0;
        ShutdownLightFrame();

        UpdateItemName(catStoreItem[selectionListCat].itemName);

        lightframesAdOns[0].SetActive(true);
        LockedOrUnlocked(catStoreItem[selectionListCat].unlocked);
    }

    public void ChangeSelectionClothes()
    {
        currentListSelection = 1;
        ShutdownLightFrame();


        UpdateItemName(clothesStoreItem[selectionListClothes].itemName);

        lightframesAdOns[1].SetActive(true);
        LockedOrUnlocked(clothesStoreItem[selectionListClothes].unlocked);
    }

    public void ChangeSelectionAccesories()
    {
        currentListSelection = 2;
        ShutdownLightFrame();


        UpdateItemName(accessoriesStoreItem[selectionListAccesories].itemName);

        lightframesAdOns[2].SetActive(true);
        LockedOrUnlocked(accessoriesStoreItem[selectionListAccesories].unlocked);
    }

    public void ChangeSelectionBongo()
    {
        currentListSelection = 3;
        ShutdownLightFrame();

        UpdateItemName(bongosStoreItem[selectionListBongo].itemName);

        lightframesAdOns[3].SetActive(true);
        LockedOrUnlocked(bongosStoreItem[selectionListBongo].unlocked);
    }



    public void ShutdownLightFrame()
    {
        lightframesAdOns[0].SetActive(false);
        lightframesAdOns[1].SetActive(false);
        lightframesAdOns[2].SetActive(false);
        lightframesAdOns[3].SetActive(false);
    }
    #endregion


    public int[] RecompileInfo()
    {
        int catID;
        int clothesID;
        int accesoriesID;
        int bongosID;

        if (catStoreItem[selectionListCat].unlocked == true)
        {
            catID = selectionListCat;
        }
        else
        {
            catID = 0;
        }

        if (clothesStoreItem[selectionListClothes].unlocked == true)
        {
            clothesID = selectionListClothes;
        }
        else
        {
            clothesID = 0;
        }

        if (accessoriesStoreItem[selectionListAccesories].unlocked == true)
        {
            accesoriesID = selectionListAccesories;
        }
        else
        {
            accesoriesID = 0;
        }

        if (bongosStoreItem[selectionListBongo].unlocked == true)
        {
            bongosID = selectionListBongo;
        }
        else
        {
            bongosID = 0;
        }

        int[] catsLooks = new int[4];

        catsLooks[0] = catID;
        catsLooks[1] = clothesID;
        catsLooks[2] = accesoriesID;
        catsLooks[3] = bongosID;

        return catsLooks;
    }

}
