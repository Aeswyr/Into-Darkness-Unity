using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{

    [SerializeField] private TileLibrary tileLibrary;
    [SerializeField] private ItemLibrary itemLibrary;


    public static LibraryManager Instance => GameObject.FindGameObjectWithTag("LibraryManager").GetComponent<LibraryManager>();
    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(this);
        tileLibrary.Load();
        itemLibrary.Load();
    }

    public TileLibrary GetTiles() {
        return tileLibrary;
    }

    public ItemLibrary GetItems() {
        return itemLibrary;
    }

}
