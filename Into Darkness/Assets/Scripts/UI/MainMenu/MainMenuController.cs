using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private NetworkStartVars networkVarsSaver;
    [SerializeField] private TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartServer() {
        if (NetworkManager.Singleton.StartServer()) {

        } else {

        }
    }

    public void StartHost() {
        networkVarsSaver.IsHost = true;
        SceneManager.LoadScene(gameScene);

    }

    public void StartClient() {
        networkVarsSaver.IsHost = false;
        networkVarsSaver.joinCode = inputField.text;
        SceneManager.LoadScene(gameScene);
    }
}
