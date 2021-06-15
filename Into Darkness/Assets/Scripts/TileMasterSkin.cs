using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TileMasterSkin", order = 1)]
public class TileMasterSkin : ScriptableObject
{
    [SerializeField] private TileBase[] tiles;

    public TileBase Get(TileType type) {
        return tiles[(int)type];
    }
}

public enum TileType {
    test = 0
}
