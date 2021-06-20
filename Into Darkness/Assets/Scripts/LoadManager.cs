using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{

    [SerializeField] private TileLibrary tileLibrary;
    [SerializeField] private ItemLibrary itemLibrary;
    [SerializeField] private String nextScene;

    // Start is called before the first frame update
    void Start()
    {
        tileLibrary.Load();
        itemLibrary.Load();
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
