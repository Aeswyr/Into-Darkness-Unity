using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private String nextScene;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(nextScene);
    }
}
