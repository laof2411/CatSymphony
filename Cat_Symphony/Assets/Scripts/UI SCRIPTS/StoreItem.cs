using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new store item", menuName = "ArianMA ScriptableObjects, new store item", order = 0)]
public class StoreItem : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] public Sprite itemSprite;
    [SerializeField] public int itemID;
    [SerializeField] public int itemCost;
    [SerializeField] public bool unlocked = false;
}
