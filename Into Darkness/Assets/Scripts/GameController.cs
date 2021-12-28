using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameController : Singleton<GameController>
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkStartVars startData = FindObjectOfType<NetworkStartVars>();
        if (startData == null || startData.IsHost) {
            if (NetworkManager.Singleton.StartHost()) {
                Debug.Log("Host started");
            } else {
                Debug.Log("Host failed");
            }
        } else {
            if (NetworkManager.Singleton.StartClient()) {
                Debug.Log("Client Started");
            } else {
                Debug.Log("Client Failed");
            }
        }
        if (startData != null)
            Destroy(startData.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
