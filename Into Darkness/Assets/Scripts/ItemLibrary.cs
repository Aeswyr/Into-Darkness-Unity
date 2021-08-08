using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemLibrary", order = 1)]
public class ItemLibrary : ScriptableObject
{

    [Serializable] public struct ItemDataPair {
        public ItemType type;
        public ItemDataSet dataSet;
    }

    /**
    representation of an default virtual item with any sort of variable values removed
    */
    [Serializable] public struct ItemDataSet {
        public Sprite sprite;
        public string baseName;
        public string description;
        public string flavorText;
        public ItemAttribute[] attributes;
    }

    [SerializeField] private ItemDataPair[] items;
    private Dictionary<ItemType, ItemDataSet> itemLibrary = new Dictionary<ItemType, ItemDataSet>();

    public void Load() {
        foreach (ItemDataPair item in items)
            itemLibrary.Add(item.type, item.dataSet);
    }

    public ItemDataSet Get(ItemType type) {
        return itemLibrary[type];
    }

    public string GetName(ItemType type) {
        return itemLibrary[type].baseName;
    }

    public string GetDesc(ItemType type) {
        return itemLibrary[type].description;
    }

    public string GetFlavor(ItemType type) {
        return itemLibrary[type].flavorText;
    }

    public Sprite GetSprite(ItemType type) {
        return itemLibrary[type].sprite;
    }

    public ItemAttribute[] GetAttributes(ItemType type) {
        return itemLibrary[type].attributes;
    }
}
