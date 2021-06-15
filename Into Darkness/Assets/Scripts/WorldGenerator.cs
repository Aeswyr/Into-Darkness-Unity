using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{

    [SerializeField] private TileMasterSkin tiles;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateWorld() {
        Tilemap back = gameObject.transform.Find("Grid/BackgroundMap").GetComponent<Tilemap>();
        Tilemap tile = gameObject.transform.Find("Grid/TileMap").GetComponent<Tilemap>();
        Tilemap deco = gameObject.transform.Find("Grid/DecoMap").GetComponent<Tilemap>();
    
        for (int x = -10; x < 10; x++) {
            for (int y = -2; y > -10; y--) {
                if (x < 0)
                    tile.SetTile(new Vector3Int(x, y, 0), tiles.Get(TileType.test));
                else 
                    tile.SetTile(new Vector3Int(x, y, 0), tiles.Get(TileType.test));
            }
        }
    
    }
}
