using UnityEngine;
using System;

/**
representation of an actual item with any sort of custom values needed
*/
[Serializable] public struct Item
{
    public ItemType type;
    public string name;
}

[Serializable] public struct ItemAttribute {
    public ItemAttributeType type;
    public int value;
}

public enum ItemType {
    Default,
}

public enum ItemAttributeType {
    Default,
}
