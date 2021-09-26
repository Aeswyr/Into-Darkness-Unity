using UnityEngine;
using System;

public enum CraftType {
    Default,
}


[Serializable] public struct Recipe
{
    public ItemType output;
    public int count;

    public ItemAttribute[] cost;
    public CraftType[] station;
}


