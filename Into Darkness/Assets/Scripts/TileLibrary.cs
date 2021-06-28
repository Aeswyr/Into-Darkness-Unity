using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileLibrary", menuName = "ScriptableObjects/TileLibrary", order = 1)]
public class TileLibrary : ScriptableObject
{
    [Serializable] public struct TypeTilePair {
        public TileType type;
        public TileBase tile;
    }
    [SerializeField] private TypeTilePair[] tiles;
    private Dictionary<TileType, TileBase> tileLibrary = new Dictionary<TileType, TileBase>();

    public void Load() {
        tileLibrary.Clear();
        foreach (TypeTilePair pair in tiles)
            tileLibrary.Add(pair.type, pair.tile);
    }
    public TileBase Get(TileType type) {
        return tileLibrary[type];
    }



}

public enum TileType {
    test
}
