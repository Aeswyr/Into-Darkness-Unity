using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public struct Item
{
    public ItemType type;
    public string name;
}

public enum ItemType {
    test,
}

public enum ItemAttribute {
    stone
}
